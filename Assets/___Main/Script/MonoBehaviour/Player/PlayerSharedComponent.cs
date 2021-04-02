using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSharedComponent : MonoBehaviour
{
    [SerializeField] public ControllerSettings ControllerSettings;
    [SerializeField] public PlayerController PlayerNormalState;
    [SerializeField] public PlayerClimbStateController PlayerClimbState;
    [SerializeField] public CharacterController CharacterController;
    [SerializeField] private LayerMask _climbLayer;
    [SerializeField] private float _distanceToCheckForClimb;

    private void CheckForClimbState(float input)
    {
        RaycastHit hitForward;
        RaycastHit hitDownward;
        bool climbableForward = Physics.Raycast(transform.position, transform.forward, out hitForward, _distanceToCheckForClimb, _climbLayer);
        bool climbableDownward = Physics.Raycast(transform.position, Vector3.down, out hitDownward, _distanceToCheckForClimb, _climbLayer);

        if (climbableDownward)
        {
            print("Ladder Found");
            PlayerClimbState.StartClimbDown(hitDownward.collider.gameObject.GetComponent<Ladder>());
            PlayerNormalState.enabled = false;
            PlayerClimbState.enabled = true;
        }

        if (climbableForward)
        {
            print("Ladder Found");
            print(hitForward.collider.gameObject.name);
            PlayerClimbState.StartClimbUp(hitForward.collider.gameObject.GetComponent<Ladder>());
            PlayerNormalState.enabled = false;
            PlayerClimbState.enabled = true;
        }

    }






    #region Input Callbacks
    public void OnShoot(InputValue input)
    {
        if (!ControllerSettings.AllControls.Enabled) return;
        if (!ControllerSettings.ShootControl.Enabled) return;
        ControllerSettings.ShootControl.Value = input.Get<float>();
        ControllerSettings.ShootControl.Action?.Invoke(input.Get<float>());
    }

    public void OnVault(InputValue input)
    {
        if (!ControllerSettings.AllControls.Enabled) return;
        if (!ControllerSettings.VaultControl.Enabled) return;
        ControllerSettings.VaultControl.Value = input.Get<float>();
        ControllerSettings.VaultControl.Action?.Invoke(input.Get<float>());
    }



    public void OnAim(InputValue input)
    {
        if (!ControllerSettings.AllControls.Enabled) return;
        if (!ControllerSettings.AimControl.Enabled) return;
        ControllerSettings.AimControl.Value = input.Get<float>();
        ControllerSettings.AimControl.Action?.Invoke(input.Get<float>());
    }

    public void OnLookDirection(InputValue input)
    {
        if (!ControllerSettings.AllControls.Enabled) return;
        if (!ControllerSettings.LookDirectionControl.Enabled) return;
        ControllerSettings.LookDirectionControl.Value = input.Get<Vector2>();
        ControllerSettings.LookDirectionControl.Action?.Invoke(input.Get<Vector2>());
    }

    public void OnMove(InputValue input)
    {
        if (!ControllerSettings.AllControls.Enabled) return;
        if (!ControllerSettings.MoveControl.Enabled) return;
        ControllerSettings.MoveControl.Value = input.Get<float>();
        ControllerSettings.MoveControl.Action?.Invoke(input.Get<float>());
    }

    public void OnMoveVertical(InputValue input)
    {
        if (!ControllerSettings.AllControls.Enabled) return;
        if (!ControllerSettings.VerticalMoveControl.Enabled) return;
        ControllerSettings.VerticalMoveControl.Value = input.Get<float>();
        ControllerSettings.VerticalMoveControl.Action?.Invoke(input.Get<float>());
    }


    public void OnCrouch(InputValue input)
    {
        if (!ControllerSettings.AllControls.Enabled) return;
        if (!ControllerSettings.CrouchControl.Enabled) return;
        ControllerSettings.CrouchControl.Value = input.Get<float>();
        ControllerSettings.CrouchControl.Action?.Invoke(input.Get<float>());

    }

    public void OnRun(InputValue input)
    {
        if (!ControllerSettings.AllControls.Enabled) return;
        if (!ControllerSettings.RunControl.Enabled) return;
        ControllerSettings.RunControl.Value = input.Get<float>();
        ControllerSettings.RunControl.Action?.Invoke(input.Get<float>());
    }

    public void OnReload(InputValue input)
    {
        if (!ControllerSettings.AllControls.Enabled) return;
        if (!ControllerSettings.ReloadControl.Enabled) return;
        ControllerSettings.ReloadControl.Value = input.Get<float>();
        ControllerSettings.ReloadControl.Action?.Invoke(input.Get<float>());
    }

    public void OnInteract(InputValue input)
    {
        if (!ControllerSettings.AllControls.Enabled) return;
        if (!ControllerSettings.InteractControl.Enabled) return;
        ControllerSettings.InteractControl.Value = input.Get<float>();
        ControllerSettings.InteractControl.Action?.Invoke(input.Get<float>());
    }


    public void OnSelectPrimary(InputValue input)
    {
        if (!ControllerSettings.AllControls.Enabled) return;
        if (!ControllerSettings.SelectPrimaryControl.Enabled) return;
        ControllerSettings.SelectPrimaryControl.Value = input.Get<float>();
        ControllerSettings.SelectPrimaryControl.Action?.Invoke(input.Get<float>());
    }

    public void OnSelectSecondary(InputValue input)
    {
        if (!ControllerSettings.AllControls.Enabled) return;
        if (!ControllerSettings.SelectPrimaryControl.Enabled) return;
        ControllerSettings.SelectSecondaryControl.Value = input.Get<float>();
        ControllerSettings.SelectSecondaryControl.Action?.Invoke(input.Get<float>());
    }

    public void OnSelectMelee(InputValue input)
    {
        if (!ControllerSettings.AllControls.Enabled) return;
        if (!ControllerSettings.SelectMeleeControl.Enabled) return;
        ControllerSettings.SelectMeleeControl.Value = input.Get<float>();
        ControllerSettings.SelectMeleeControl.Action?.Invoke(input.Get<float>());
    }


    private void OnSelectDrone(InputValue input)
    {
        if (!ControllerSettings.AllControls.Enabled) return;
        if (!ControllerSettings.SelectDrone.Enabled) return;
        ControllerSettings.SelectDrone.Value = input.Get<float>();
        ControllerSettings.SelectDrone.Action.Invoke(input.Get<float>());
    }

    #endregion

    #region Unity Callbacks

    private void Awake()
    {
        this.ControllerSettings.InteractControl.Action += CheckForClimbState;
    }
    #endregion



}
enum PlayerState { Normal, Climb }