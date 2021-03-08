using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;


public abstract class BasePlayerController : MonoBehaviour
{

    #region Unity References
    [SerializeField] protected CharacterController _controller;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] protected LayerMask _inputHelperLayerMask;
    [SerializeField] protected Animator _characterAnimator;
    [SerializeField] private PlayerSpeed _playerSpeed;

    [SerializeField] private float _speedCoefficient;
    [SerializeField] protected ControllerSettings _controllerSettings;
    [SerializeField] protected PlayerStateHolder _playerCurrentState;
    #endregion


    #region public functions
    private float _moveSpeed;
    public void UpdatePlayerMoveMode(PlayerMoveMode playerMoveMode)
    {
        switch (playerMoveMode)
        {
            case PlayerMoveMode.Crouch:
                _characterAnimator.SetFloat(PlayerAnimatorStringReferences.MoveState, _playerSpeed.CrouchSpeed);
                _moveSpeed = _playerSpeed.CrouchSpeed;
                break;
            case PlayerMoveMode.Walk:
                _characterAnimator.SetFloat(PlayerAnimatorStringReferences.MoveState, _playerSpeed.WalkSpeed);
                _moveSpeed = _playerSpeed.WalkSpeed;
                break;
            case PlayerMoveMode.Run:
                _characterAnimator.SetFloat(PlayerAnimatorStringReferences.MoveState, _playerSpeed.RunSpeed);
                _moveSpeed = _playerSpeed.RunSpeed;
                break;

        }
    }


    #endregion

    #region private functions

    private float _gravity;
    private void ApplyPlayerGravity()
    {
        _gravity = Physics.gravity.y * Time.deltaTime;
        _controller.Move(new Vector3(0, _gravity, 0));
        if (_controller.isGrounded) _gravity = 0;
    }

    private int AnimatorDirectionCoeficient = 0;

    private void ApplyPlayerRotation()
    {
        Ray ray = Camera.main.ScreenPointToRay(_controllerSettings.LookDirectionControl.Value);
        RaycastHit inputRaycastHit;
        Physics.Raycast(ray, out inputRaycastHit, _inputHelperLayerMask);

        if (inputRaycastHit.point.z > transform.position.z)
        {
            transform.rotation =
                Quaternion.LerpUnclamped(transform.rotation, Quaternion.Euler(0, 0, 0), _rotationSpeed);
            AnimatorDirectionCoeficient = 1;
        }
        else
        {
            AnimatorDirectionCoeficient = -1;
            transform.rotation =
                Quaternion.LerpUnclamped(transform.rotation, Quaternion.Euler(0, 180, 0), _rotationSpeed);
        }
    }

    private void ApplyPlayerMove()
    {
        _controller.Move(new Vector3(0, 0, _controllerSettings.MoveControl.Value * _moveSpeed * _speedCoefficient));
        _characterAnimator.SetFloat(PlayerAnimatorStringReferences.SpeedState,
            _controllerSettings.MoveControl.Value * AnimatorDirectionCoeficient);
    }

    private void ApplyPlayerMoveState()
    {
        if (_controllerSettings.CrouchControl.Value > 0)
        {
            UpdatePlayerMoveMode(PlayerMoveMode.Crouch);
            return;
        }

        if (_controllerSettings.RunControl.Value > 0)
        {
            UpdatePlayerMoveMode(PlayerMoveMode.Run);
            return;
        }

        UpdatePlayerMoveMode(PlayerMoveMode.Walk);
    }



    #endregion


    #region Input Callbacks
    public void OnShoot(InputValue input)
    {
        if (!_controllerSettings.AllControls.Enabled) return;
        if (!_controllerSettings.ShootControl.Enabled) return;
        _controllerSettings.ShootControl.Value = input.Get<float>();
        _controllerSettings.ShootControl.Action?.Invoke(input.Get<float>());
    }

    public void OnVault(InputValue input)
    {
        if (!_controllerSettings.AllControls.Enabled) return;
        if (!_controllerSettings.VaultControl.Enabled) return;
        _controllerSettings.VaultControl.Value = input.Get<float>();
        _controllerSettings.VaultControl.Action?.Invoke(input.Get<float>());
    }



    public void OnAim(InputValue input)
    {
        if (!_controllerSettings.AllControls.Enabled) return;
        if (!_controllerSettings.AimControl.Enabled) return;
        _controllerSettings.AimControl.Value = input.Get<float>();
        _controllerSettings.AimControl.Action?.Invoke(input.Get<float>());
    }

    public void OnLookDirection(InputValue input)
    {
        if (!_controllerSettings.AllControls.Enabled) return;
        if (!_controllerSettings.LookDirectionControl.Enabled) return;
        _controllerSettings.LookDirectionControl.Value = input.Get<Vector2>();
        _controllerSettings.LookDirectionControl.Action?.Invoke(input.Get<Vector2>());
    }

    public void OnMove(InputValue input)
    {
        if (!_controllerSettings.AllControls.Enabled) return;
        if (!_controllerSettings.MoveControl.Enabled) return;
        _controllerSettings.MoveControl.Value = input.Get<float>();
        _controllerSettings.MoveControl.Action?.Invoke(input.Get<float>());
    }

    public void OnCrouch(InputValue input)
    {
        if (!_controllerSettings.AllControls.Enabled) return;
        if (!_controllerSettings.CrouchControl.Enabled) return;
        _controllerSettings.CrouchControl.Value = input.Get<float>();
        _controllerSettings.CrouchControl.Action?.Invoke(input.Get<float>());

    }

    public void OnRun(InputValue input)
    {
        if (!_controllerSettings.AllControls.Enabled) return;
        if (!_controllerSettings.RunControl.Enabled) return;
        _controllerSettings.RunControl.Value = input.Get<float>();
        _controllerSettings.RunControl.Action?.Invoke(input.Get<float>());
    }

    public void OnReload(InputValue input)
    {
        if (!_controllerSettings.AllControls.Enabled) return;
        if (!_controllerSettings.ReloadControl.Enabled) return;
        _controllerSettings.ReloadControl.Value = input.Get<float>();
        _controllerSettings.ReloadControl.Action?.Invoke(input.Get<float>());
    }

    public void OnInteract(InputValue input)
    {
        if (!_controllerSettings.AllControls.Enabled) return;
        if (!_controllerSettings.InteractControl.Enabled) return;
        _controllerSettings.InteractControl.Value = input.Get<float>();
        _controllerSettings.InteractControl.Action?.Invoke(input.Get<float>());
    }


    public void OnSelectPrimary(InputValue input)
    {
        if (!_controllerSettings.AllControls.Enabled) return;
        if (!_controllerSettings.SelectPrimaryControl.Enabled) return;
        _controllerSettings.SelectPrimaryControl.Value = input.Get<float>();
        _controllerSettings.SelectPrimaryControl.Action?.Invoke(input.Get<float>());
    }

    public void OnSelectSecondary(InputValue input)
    {
        if (!_controllerSettings.AllControls.Enabled) return;
        if (!_controllerSettings.SelectPrimaryControl.Enabled) return;
        _controllerSettings.SelectSecondaryControl.Value = input.Get<float>();
        _controllerSettings.SelectSecondaryControl.Action?.Invoke(input.Get<float>());
    }

    public void OnSelectMelee(InputValue input)
    {
        if (!_controllerSettings.AllControls.Enabled) return;
        if (!_controllerSettings.SelectMeleeControl.Enabled) return;
        _controllerSettings.SelectMeleeControl.Value = input.Get<float>();
        _controllerSettings.SelectMeleeControl.Action?.Invoke(input.Get<float>());
    }
    #endregion


    #region Unity Callbacks



    protected virtual void Awake()
    {

    }


    protected virtual void Update()
    {
        ApplyPlayerGravity();
        ApplyPlayerRotation();
        ApplyPlayerMove();
        ApplyPlayerMoveState();
    }

    #endregion


}



#region Helper Stuff

public enum WeaponType { Knife, Pistol, Rifle }

[System.Serializable]
public class PlayerStateHolder
{
    public void UpdatePlayerState(bool isChanging, bool isReloading, bool isAiming, WeaponType currentHandlingWeapon)
    {
        IsChanging = isChanging;
        IsReloading = isReloading;
        IsAiming = isAiming;
        CurrentHandlingWeapon = currentHandlingWeapon;
    }

    public bool IsChanging;
    public bool IsReloading;
    public bool IsAiming;
    public WeaponType CurrentHandlingWeapon;
}


[System.Serializable]
public struct PlayerSpeed
{
    public float CrouchSpeed;
    public float WalkSpeed;
    public float RunSpeed;

}
public enum PlayerMoveMode { Crouch, Walk, Run }


[System.Serializable]
public class Control
{
    [SerializeField] public bool Enabled;
}

[System.Serializable]
public sealed class ControlFloat : Control
{
    [ReadOnly] public float Value;
    [ReadOnly] public System.Action<float> Action;
}
[System.Serializable]
public sealed class ControlVector2 : Control
{
    [ReadOnly] public Vector2 Value;
    [ReadOnly] public System.Action<Vector2> Action;
}

[System.Serializable]
public class ControllerSettings
{
    [SerializeField] public Control AllControls;
    [SerializeField] public ControlFloat ShootControl;
    [SerializeField] public ControlFloat AimControl;
    [SerializeField] public ControlFloat MoveControl;
    [SerializeField] public ControlFloat CrouchControl;
    [SerializeField] public ControlFloat RunControl;
    [SerializeField] public ControlVector2 LookDirectionControl;
    [SerializeField] public ControlFloat InteractControl;
    [SerializeField] public ControlFloat ReloadControl;
    [SerializeField] public ControlFloat SelectPrimaryControl;
    [SerializeField] public ControlFloat SelectSecondaryControl;
    [SerializeField] public ControlFloat SelectMeleeControl;
    [SerializeField] public ControlFloat VaultControl;


    public void DisableAllControls()
    {
        AllControls.Enabled = false;
    }

    public void EnableAllControls()
    {
        AllControls.Enabled = true;
    }

    public void DisableInputsForKnifeStab()
    {
        this.AllControls.Enabled = false;
    }

    public void EnableInputsAfterKnifeStab()
    {
        this.AllControls.Enabled = true;
    }


    public void DisableInputForChangeWeapon()
    {
        this.ShootControl.Enabled = false;
        this.AimControl.Enabled = false;
        this.InteractControl.Enabled = false;
        this.ReloadControl.Enabled = false;
        this.SelectMeleeControl.Enabled = false;
        this.SelectPrimaryControl.Enabled = false;
        this.SelectSecondaryControl.Enabled = false;
    }

    public void EnableInputAfterChangeWeapon()
    {
        this.ShootControl.Enabled = true;
        this.AimControl.Enabled = true;
        this.InteractControl.Enabled = true;
        this.ReloadControl.Enabled = true;
        this.SelectMeleeControl.Enabled = true;
        this.SelectPrimaryControl.Enabled = true;
        this.SelectSecondaryControl.Enabled = true;
    }


    public void DisableInputForReload()
    {
        this.ShootControl.Enabled = false;
        this.AimControl.Enabled = false;
        this.InteractControl.Enabled = false;
        this.ReloadControl.Enabled = false;
        this.SelectMeleeControl.Enabled = false;
        this.SelectPrimaryControl.Enabled = false;
        this.SelectSecondaryControl.Enabled = false;
    }

    public void EnableInputAfterReload()
    {
        this.ShootControl.Enabled = true;
        this.AimControl.Enabled = true;
        this.InteractControl.Enabled = true;
        this.ReloadControl.Enabled = true;
        this.SelectMeleeControl.Enabled = true;
        this.SelectPrimaryControl.Enabled = true;
        this.SelectSecondaryControl.Enabled = true;
    }

    public void DisableInputForAim()
    {
        this.ShootControl.Enabled = true;
        this.InteractControl.Enabled = false;
        this.ReloadControl.Enabled = false;
        this.SelectMeleeControl.Enabled = false;
        this.SelectPrimaryControl.Enabled = false;
        this.SelectSecondaryControl.Enabled = false;

    }

    public void EnableInputAfterAim()
    {
        this.ShootControl.Enabled = false;
        this.InteractControl.Enabled = true;
        this.ReloadControl.Enabled = true;
        this.SelectMeleeControl.Enabled = true;
        this.SelectPrimaryControl.Enabled = true;
        this.SelectSecondaryControl.Enabled = true;
    }

 

    public void DisableInputForShoot()
    {
       // this.AimControl.Enabled = false;
        this.InteractControl.Enabled = false;
        this.ReloadControl.Enabled = false;
        this.SelectMeleeControl.Enabled = false;
        this.SelectPrimaryControl.Enabled = false;
        this.SelectSecondaryControl.Enabled = false;
    }

    public void EnableInputAfterShoot()
    {
      //  this.AimControl.Enabled = false;
        this.InteractControl.Enabled = false;
        this.ReloadControl.Enabled = false;
        this.SelectMeleeControl.Enabled = false;
        this.SelectPrimaryControl.Enabled = false;
        this.SelectSecondaryControl.Enabled = false;
    } 

}


#endregion