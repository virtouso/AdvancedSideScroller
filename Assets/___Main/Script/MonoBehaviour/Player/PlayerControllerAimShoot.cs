using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public partial class PlayerController : BasePlayerController
{
    [Inject] private PoolManager _poolManager;
    [SerializeField] private PlayerAimIkHandler _playerAimIkHandler;
    [SerializeField] private List<WeaponAimingOffset> _aimingOffsets;
    [SerializeField] private float _pistolFireRate;
    [SerializeField] private float _rifleFireRate;
    [SerializeField] private float _knifeDuration;
    [SerializeField] private float _knifeCrossFadeDuration;

    private Dictionary<WeaponType, float> _aimingOffsetDictionary;
    private WeaponAimingOffset _currentAimingOffset;

    private bool _aiming;
    private float _aimingWeight;
    private Vector3 _aimingPosition;


    private void InitPlayerControllerAim()
    {
        _aimingOffsetDictionary = new Dictionary<WeaponType, float>(3);
        foreach (var item in _aimingOffsets)
        {
            _aimingOffsetDictionary.Add(item.WeaponType, item.Offset);
        }
    }


    private void Aim(float playerInput)
    {
        if (playerInput > 0.5)
            AimStarted();
        else
            AimFinished();
    }

    private void OnAimPosition(Vector2 aimPositionInput)
    {
        Vector3 shoulderPosition = _characterAnimator.GetBoneTransform(HumanBodyBones.RightShoulder).position;

        Ray ray = Camera.main.ScreenPointToRay(_sharedComponent.ControllerSettings.LookDirectionControl.Value);
        RaycastHit inputRaycastHit;
        Physics.Raycast(ray, out inputRaycastHit, _inputHelperLayerMask);

        Vector3 direction = shoulderPosition + (inputRaycastHit.point - shoulderPosition).normalized * _aimingOffsetDictionary[_playerCurrentState.CurrentHandlingWeapon];

        Debug.DrawRay(shoulderPosition, direction, Color.red);
        SetAimingPosition(_playerCurrentState.CurrentHandlingWeapon, direction);
    }


    private void SetAimingPosition(WeaponType weaponType, Vector3 aimingPosition)
    {
        _aimingPosition = aimingPosition;
    }

    private void AimStarted()
    {
        _sharedComponent.ControllerSettings.DisableInputForAim();
        _aimingWeight = 1;
        _aiming = true;
    }

    private void AimFinished()
    {
        _sharedComponent.ControllerSettings.EnableInputAfterAim();
        _aimingWeight = 0;
        _aiming = false;
        if (_pistolCoroutine != null) StopCoroutine(_pistolCoroutine);
        if (_rifleCouroutine != null) StopCoroutine(_rifleCouroutine);
        StartCoroutine(FinishStabbing());
    }




    private System.Action<float> _fightAction;
    private void Shoot(float inputValue)
    {
        if (!_aiming) return;
        _fightAction?.Invoke(inputValue);
    }
    private void StabKnife(float inputValue)
    {
        print("knife input value" + inputValue);
        if (inputValue > 0.5)
        {
            print("stab knife called");
            _sharedComponent.ControllerSettings.DisableInputsForKnifeStab();
            _aimingWeight = 0;
            //_characterAnimator.CrossFade(PlayerAnimatorStringReferences.Stab2Animation, _knifeCrossFadeDuration);
            _characterAnimator.Play(PlayerAnimatorStringReferences.Stab2Animation);

            _weaponPlacementDictionary[WeaponType.Knife].Weapon.GetComponent<BoxCollider>().enabled = true;
            StartCoroutine(FinishStabbing());
        }
    }


    IEnumerator FinishStabbing()
    {
        yield return new WaitForSeconds(_knifeDuration);
        _sharedComponent.ControllerSettings.EnableInputsAfterKnifeStab();
        _weaponPlacementDictionary[WeaponType.Knife].Weapon.GetComponent<BoxCollider>().enabled = false;
        _characterAnimator.CrossFade(PlayerAnimatorStringReferences.KnifeIdleAnimation, _knifeCrossFadeDuration);
    }


    private Coroutine _pistolCoroutine;
    private void ShootPistol(float inputValue)
    {
        if (inputValue > 0.5)
        {
            _sharedComponent.ControllerSettings.DisableInputForShoot();
            _pistolCoroutine = StartCoroutine(ShootPistol());
        }
        else
        {
            _sharedComponent.ControllerSettings.EnableInputAfterShoot();
            StopCoroutine(_pistolCoroutine);
        }
    }

    private IEnumerator ShootPistol()
    {
        while (true)
        {
            WeaponDirectShootBase weapon = _weaponPlacementDictionary[WeaponType.Pistol].Weapon
                .GetComponent<WeaponDirectShootBase>();

            _poolManager.ShootBullet(weapon.ShootMuzzle.position, weapon.transform.rotation, weapon.transform.forward);
            yield return new WaitForSeconds(_pistolFireRate);
        }
    }


    private Coroutine _rifleCouroutine;
    private void ShootAutomaticRifle(float inputValue)
    {
        if (inputValue > 0.5)
        {
            _sharedComponent.ControllerSettings.DisableInputForShoot();
            _rifleCouroutine = StartCoroutine(ShootRifle());
        }
        else
        {
            _sharedComponent.ControllerSettings.EnableInputAfterShoot();
            StopCoroutine(_rifleCouroutine);
        }

    }


    private IEnumerator ShootRifle()
    {
        while (true)
        {
            WeaponDirectShootBase weapon = _weaponPlacementDictionary[WeaponType.Rifle].Weapon
                .GetComponent<WeaponDirectShootBase>();

            _poolManager.ShootBullet(weapon.ShootMuzzle.position, weapon.transform.rotation, weapon.transform.forward);
            yield return new WaitForSeconds(_rifleFireRate);
        }
    }


}
