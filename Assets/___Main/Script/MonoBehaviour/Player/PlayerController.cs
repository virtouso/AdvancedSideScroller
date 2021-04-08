using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public partial class PlayerController : BasePlayerController
{
    [SerializeField] private float _weaponChangeCrossFadeLength;
    [SerializeField] private float _reloadCrossFadeLength;
    [SerializeField] private float _stabCrossFadeLength;


    [SerializeField] private Transform _knifeSocket;
    [SerializeField] private Transform _pistolSocket;
    [SerializeField] private Transform _rifleSocket;
    [SerializeField] private Transform _rightHandSocket;
    [SerializeField] private Transform _leftHandSocket;

    [SerializeField] private WeaponList _weaponList;




    private Dictionary<WeaponType, WeaponPlacement> _weaponPlacementDictionary;



    private void Interact() { }





    #region Vault
    [Header("Vault Settings")]
    private bool _canVault;
    [SerializeField] private float _raycastYOffset;
    [SerializeField] private LayerMask _obstacleMask;
    [SerializeField] private float _permittedDistanceToVault;
    [SerializeField] private float _vaultMoveAmount;
    [SerializeField] private float _vaultMoveTime;
    [SerializeField] private float _vaultCrossFadeLength;
    [SerializeField] private PlayerFootIkHandler _playerFootIkHandler;
    [SerializeField] private GameObject _dronePrefab;
    [SerializeField] private Vector3 _droneInstantiationOffset;
    private void Vault(float inputValue)
    {
        if (inputValue < 1) return;
        if (!_canVault) return;
        StartCoroutine(Vaulting());
    }

    private IEnumerator Vaulting()
    {
       _sharedComponent. ControllerSettings.DisableAllControls();
        _characterAnimator.SetLayerWeight(3, 1);
        _characterAnimator.SetLayerWeight(1, 0);
        _characterAnimator.SetLayerWeight(2, 0);
        _characterAnimator.CrossFade(PlayerAnimatorStringReferences.Vault, _vaultCrossFadeLength);
        _controller.enabled = false;
        float counter = 0;
        _playerFootIkHandler.UppdateFootIk(0, FootIkState.DontApply);
    _sharedComponent.ControllerSettings.MoveControl.Value = 0;

        while (counter < _vaultMoveTime)
        {
            counter += Time.deltaTime;
            yield return new WaitForEndOfFrame();
            transform.position += transform.forward * _vaultMoveAmount;
        }

        _characterAnimator.SetLayerWeight(3, 0);
        _characterAnimator.SetLayerWeight(1, 1);
        _characterAnimator.SetLayerWeight(2, 1);

        _characterAnimator.CrossFade("New State", _vaultCrossFadeLength);

        _playerFootIkHandler.UppdateFootIk(1, FootIkState.Apply);
        _controller.enabled = true;
      _sharedComponent.  ControllerSettings.EnableAllControls();

    }

    private void CheckForVaultSituation()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position + new Vector3(0, _raycastYOffset, 0), transform.forward);
        _canVault = Physics.Raycast(ray, out hit, _permittedDistanceToVault, _obstacleMask);
        Debug.DrawRay(transform.position + new Vector3(0, _raycastYOffset, 0), transform.forward * _permittedDistanceToVault);
        if (_canVault) print("Can Vault");
    }

    #endregion




    #region Change Weapon

    private void InitWeaponsStates()
    {
        _putAwayWeapon = PutAwayKnife;
        _reloadAction = ReloadMelee;
        _playerCurrentState.UpdatePlayerState(false, false, false, WeaponType.Knife);
    }

    private void SelectKnife(float inputValue)
    {
        if (inputValue < 1) return;
        _fightAction = StabKnife;
        ChangeWeaponTo(WeaponType.Knife);
    }

    private void SelectPistol(float inputValue)
    {
        if (inputValue < 1) return;
        _fightAction = ShootPistol;
        ChangeWeaponTo(WeaponType.Pistol);
    }

    private void SelectRifle(float inputValue)
    {
        if (inputValue < 1) return;
        _fightAction = ShootAutomaticRifle;
        ChangeWeaponTo(WeaponType.Rifle);
    }

    private void ReleaseDrone(float inputValue)
    {
        Instantiate(_dronePrefab, _droneInstantiationOffset, Quaternion.identity);
    }

    private void ChangeWeaponTo(WeaponType weaponType)
    {
        switch (weaponType)
        {
            case WeaponType.Knife:
                _drawWeapon = DrawKnife;
                break;
            case WeaponType.Pistol:
                _drawWeapon = DrawPistol;
                break;
            case WeaponType.Rifle:
                _drawWeapon = DrawRifle;
                break;
        }

        StartCoroutine(ChangeWeapon());
    }


    private System.Func<WeaponType> _putAwayWeapon;
    private System.Action _drawWeapon;

    private IEnumerator ChangeWeapon()
    {
    _sharedComponent.ControllerSettings.DisableInputForChangeWeapon();
        yield return StartCoroutine(PutAwayWeapon());
        yield return StartCoroutine(DrawWeapon());
        _onWeaponReady?.Invoke();
       _sharedComponent.ControllerSettings.EnableInputAfterChangeWeapon();
    }

    private IEnumerator PutAwayWeapon()
    {
        WeaponType? weaponType = _putAwayWeapon?.Invoke();
        float timeToFinish = 1.5f; AnimationUtility.GetCurrentAnimatorTime(_characterAnimator, 1);
        print(timeToFinish);
        yield return new WaitForSeconds(timeToFinish);
        PutWeaponOnSocket(weaponType.Value);
    }

    private void PutWeaponOnSocket(WeaponType weaponType)
    {
        WeaponPlacement wp = _weaponPlacementDictionary[weaponType];
        wp.Weapon.transform.parent = wp.Socket;
        wp.Weapon.transform.localPosition = Vector3.zero;
        wp.Weapon.transform.localRotation = Quaternion.Euler(Vector3.zero);
    }
    private void PutWeaponOnHandSocket(WeaponType weaponType)
    {
        WeaponPlacement wp = _weaponPlacementDictionary[weaponType];
        wp.Weapon.transform.parent = _rightHandSocket;
        wp.Weapon.transform.localPosition = Vector3.zero;
        wp.Weapon.transform.localRotation = Quaternion.Euler(Vector3.zero);
    }


    private IEnumerator DrawWeapon()
    {
        _drawWeapon?.Invoke();
        float timeToFinish = 1.5f; AnimationUtility.GetCurrentAnimatorTime(_characterAnimator, 1);
        print(timeToFinish);
        yield return new WaitForSeconds(timeToFinish);

    }


    private WeaponType PutAwayKnife()
    {
        _characterAnimator.CrossFade(PlayerAnimatorStringReferences.PutAwayPistolAnimation, _weaponChangeCrossFadeLength);
        return WeaponType.Knife;
    }

    private WeaponType PutAwayPistol()
    {
        _characterAnimator.CrossFade(PlayerAnimatorStringReferences.PutAwayPistolAnimation, _weaponChangeCrossFadeLength);
        return WeaponType.Pistol;
    }

    private WeaponType PutAwayRifle()
    {
        _characterAnimator.CrossFade(PlayerAnimatorStringReferences.PutAwayRifleAnimation, _weaponChangeCrossFadeLength);
        return WeaponType.Rifle;
    }



    private System.Action _onWeaponReady;
    private void DrawKnife()
    {
        _putAwayWeapon = PutAwayKnife;
        _playerCurrentState.UpdatePlayerState(true, false, false, WeaponType.Knife);
        _characterAnimator.CrossFade(PlayerAnimatorStringReferences.DrawPistolAnimation, _weaponChangeCrossFadeLength);
        _onWeaponReady = OnKnifeReady;
        PutWeaponOnHandSocket(WeaponType.Knife);
        _reloadAction = ReloadMelee;
    }

    private void DrawPistol()
    {
        _putAwayWeapon = PutAwayPistol;
        _playerCurrentState.UpdatePlayerState(true, false, false, WeaponType.Pistol);
        _characterAnimator.CrossFade(PlayerAnimatorStringReferences.DrawPistolAnimation, _weaponChangeCrossFadeLength);
        _onWeaponReady = OnPistolReady;
        PutWeaponOnHandSocket(WeaponType.Pistol);
        _reloadAction = ReloadPistol;
    }

    private void DrawRifle()
    {
        _putAwayWeapon = PutAwayRifle;
        _playerCurrentState.UpdatePlayerState(true, false, false, WeaponType.Rifle);
        _characterAnimator.CrossFade(PlayerAnimatorStringReferences.DrawRifleAnimation, _weaponChangeCrossFadeLength);
        _onWeaponReady = OnRifleReady;
        PutWeaponOnHandSocket(WeaponType.Rifle);
        _reloadAction = ReloadRifle;
    }

    private void OnKnifeReady()
    {
        _characterAnimator.CrossFade(PlayerAnimatorStringReferences.KnifeIdleAnimation, _weaponChangeCrossFadeLength);

    }

    private void OnPistolReady()
    {
        _characterAnimator.CrossFade(PlayerAnimatorStringReferences.KnifeIdleAnimation, _weaponChangeCrossFadeLength);

    }

    private void OnRifleReady()
    {
        _characterAnimator.CrossFade(PlayerAnimatorStringReferences.KnifeIdleAnimation, _weaponChangeCrossFadeLength);
    }

    #endregion



    #region Reload

    private void Reload(float inputValue)
    {
        // todo check player can reload
        //todo temp
        if (_playerCurrentState.CurrentHandlingWeapon == WeaponType.Knife) return;
        _playerCurrentState.UpdatePlayerState(false, true, false, _playerCurrentState.CurrentHandlingWeapon);
      _sharedComponent.ControllerSettings.DisableInputForReload();
        _reloadAction?.Invoke(inputValue);
        StartCoroutine(ReloadWeapon());

    }
    private Action<float> _reloadAction;

    private IEnumerator ReloadWeapon()
    {
        //todo check for later animation length
        float animationLength = 2.5f;
        yield return new WaitForSeconds(animationLength);
        _characterAnimator.CrossFade(PlayerAnimatorStringReferences.KnifeIdleAnimation, _weaponChangeCrossFadeLength);
      _sharedComponent.  ControllerSettings.EnableInputAfterReload();
    }

    private void ReloadMelee(float inputValue)
    {

    }

    private void ReloadPistol(float inputValue)
    {
        _characterAnimator.CrossFade(PlayerAnimatorStringReferences.ReloadPistol, _reloadCrossFadeLength);

    }

    private void ReloadRifle(float inputValue)
    {
        _characterAnimator.CrossFade(PlayerAnimatorStringReferences.ReloadRifle, _reloadCrossFadeLength);

    }

    #endregion

    #region Initiation

    private void InitInputCallbacks()
    {
     _sharedComponent.ControllerSettings.SelectPrimaryControl.Action += SelectRifle;
     _sharedComponent.ControllerSettings.SelectSecondaryControl.Action += SelectPistol;
     _sharedComponent.ControllerSettings.SelectMeleeControl.Action += SelectKnife;
     _sharedComponent.ControllerSettings.ReloadControl.Action += Reload;
     _sharedComponent.ControllerSettings.VaultControl.Action += Vault;
     _sharedComponent.ControllerSettings.AimControl.Action += Aim;
     _sharedComponent.ControllerSettings.ShootControl.Action += Shoot;
     _sharedComponent.ControllerSettings.LookDirectionControl.Action += OnAimPosition;
     _sharedComponent.ControllerSettings.SelectDrone.Action += ReleaseDrone;
    }
    private void InitWeaponInstances()
    {
        _weaponPlacementDictionary = new Dictionary<WeaponType, WeaponPlacement>();

        WeaponKnife knife = Instantiate(_weaponList.GetWeaponList().Knife);
        knife.transform.parent = _rightHandSocket;
        knife.transform.localPosition = Vector3.zero;
        WeaponPlacement wk = new WeaponPlacement(_knifeSocket, knife);
        _weaponPlacementDictionary.Add(WeaponType.Knife, wk);

        WeaponPistol pistol = Instantiate(_weaponList.GetWeaponList().Pistol);
        pistol.transform.parent = _pistolSocket;
        pistol.transform.localPosition = Vector3.zero;
        pistol.transform.rotation = _pistolSocket.rotation;
        WeaponPlacement wp = new WeaponPlacement(_pistolSocket, pistol);
        _weaponPlacementDictionary.Add(WeaponType.Pistol, wp);

        WeaponRifle rifle = Instantiate(_weaponList.GetWeaponList().Rifle);
        rifle.transform.parent = _rifleSocket;
        rifle.transform.localPosition = Vector3.zero;
        rifle.transform.localRotation = _pistolSocket.rotation;
        WeaponPlacement wr = new WeaponPlacement(_rifleSocket, rifle);
        _weaponPlacementDictionary.Add(WeaponType.Rifle, wr);

    }


    #endregion


    #region Unity callbacks
    protected override void Awake()
    {
        base.Awake();
        InitWeaponsStates();
        InitInputCallbacks();
        InitWeaponInstances();
        InitPlayerControllerAim();
        _fightAction = StabKnife;
    }



    protected override void Update()
    {
        base.Update();
        CheckForVaultSituation();
        _playerAimIkHandler.UpdateValues(_aimingWeight, _aimingPosition);
    }
    #endregion
}


public class WeaponPlacement
{
    public WeaponPlacement(Transform socket, WeaponBase weapon)
    {
        Socket = socket;
        Weapon = weapon;
    }

    [SerializeField] public Transform Socket;
    [ReadOnly] public WeaponBase Weapon;

}

[System.Serializable]
public struct WeaponAimingOffset
{
    public WeaponType WeaponType;
    public float Offset;
}




