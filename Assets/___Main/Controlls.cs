// GENERATED AUTOMATICALLY FROM 'Assets/___Main/Controlls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controlls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controlls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controlls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""ca13823c-1287-4a3f-9859-81a3d5f95c8c"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""a9feb133-2da9-4265-bb7b-6e01cc0b1ef8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""6043c883-8c3d-4b61-83d4-7d6a0a488a9f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""9d104766-b542-4161-abff-847e7a900343"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""MoveVertical"",
                    ""type"": ""Button"",
                    ""id"": ""3229b4b8-857a-4c41-8903-773d1ef08bcc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""LookDirection"",
                    ""type"": ""Value"",
                    ""id"": ""ccffc11d-b44c-40ac-98e1-617b762caa70"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""6c2fb6e2-e898-465c-a046-1e0a9d878fa2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""6f9a5308-fc34-47b2-a9a6-6516e80b0d19"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""a5742f20-6ae0-45a2-9686-b1ef883e50da"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""4356b71a-28dd-4080-88e3-d1b9cbf76140"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectPrimary"",
                    ""type"": ""Button"",
                    ""id"": ""9ae7991a-7663-4686-b562-097f68477d24"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectSecondary"",
                    ""type"": ""Button"",
                    ""id"": ""46726c6b-f07b-42e2-a065-93a7171f20ec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectMelee"",
                    ""type"": ""Button"",
                    ""id"": ""4f07b33c-1b40-4cd3-a1a6-c5dbe1ec95e9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectDrone"",
                    ""type"": ""Button"",
                    ""id"": ""314887df-8d3e-4989-a5f1-511f2b8a60e5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Vault"",
                    ""type"": ""Button"",
                    ""id"": ""7d00f677-d96d-4037-95c8-7cbd4f8c6984"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a876cb46-c3cb-4884-a139-076e1111f3f0"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""205aadc2-290c-4855-9f88-871765b564d7"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Move"",
                    ""id"": ""3057568f-1aed-42e2-bb6c-c48422177018"",
                    ""path"": ""1DAxis"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""b49e2013-c45e-4b8f-959a-68f8f38322ef"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ab5c2a49-b669-438f-948c-9f14ec51b61b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9c336b00-e0c8-40f7-a10a-771549cf500c"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""LookDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de12e8e1-3ebd-4787-b6ba-bf971644029f"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2fbf7fca-e8cd-4f99-99e5-82367baff365"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19288a1d-5562-4b11-b5c1-61e94f2a91b7"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3708e60d-c6a4-4d4e-8145-f6539f017fa1"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4e62b7d6-deb4-428d-9b95-cb488c444d4e"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SelectPrimary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1bcf24a1-2148-4a94-84e4-f1ef71f1cf81"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SelectSecondary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc6c2d87-e9c3-4677-8329-0b1054e5a282"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SelectMelee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""025492ee-7cc1-495a-8a87-711a94deeced"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vault"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a93a3c92-55f5-4ad9-b0cc-fa6d4e6f184f"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SelectDrone"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Move"",
                    ""id"": ""0eb2471a-569f-4ee5-92f5-737784306ffc"",
                    ""path"": ""1DAxis"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MoveVertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""47e46074-278d-4047-a221-4055d4fc4de0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MoveVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""1927657a-15a2-480a-8332-ba3673e9fdcd"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MoveVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Shoot = m_Player.FindAction("Shoot", throwIfNotFound: true);
        m_Player_Aim = m_Player.FindAction("Aim", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_MoveVertical = m_Player.FindAction("MoveVertical", throwIfNotFound: true);
        m_Player_LookDirection = m_Player.FindAction("LookDirection", throwIfNotFound: true);
        m_Player_Crouch = m_Player.FindAction("Crouch", throwIfNotFound: true);
        m_Player_Run = m_Player.FindAction("Run", throwIfNotFound: true);
        m_Player_Reload = m_Player.FindAction("Reload", throwIfNotFound: true);
        m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
        m_Player_SelectPrimary = m_Player.FindAction("SelectPrimary", throwIfNotFound: true);
        m_Player_SelectSecondary = m_Player.FindAction("SelectSecondary", throwIfNotFound: true);
        m_Player_SelectMelee = m_Player.FindAction("SelectMelee", throwIfNotFound: true);
        m_Player_SelectDrone = m_Player.FindAction("SelectDrone", throwIfNotFound: true);
        m_Player_Vault = m_Player.FindAction("Vault", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Shoot;
    private readonly InputAction m_Player_Aim;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_MoveVertical;
    private readonly InputAction m_Player_LookDirection;
    private readonly InputAction m_Player_Crouch;
    private readonly InputAction m_Player_Run;
    private readonly InputAction m_Player_Reload;
    private readonly InputAction m_Player_Interact;
    private readonly InputAction m_Player_SelectPrimary;
    private readonly InputAction m_Player_SelectSecondary;
    private readonly InputAction m_Player_SelectMelee;
    private readonly InputAction m_Player_SelectDrone;
    private readonly InputAction m_Player_Vault;
    public struct PlayerActions
    {
        private @Controlls m_Wrapper;
        public PlayerActions(@Controlls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_Player_Shoot;
        public InputAction @Aim => m_Wrapper.m_Player_Aim;
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @MoveVertical => m_Wrapper.m_Player_MoveVertical;
        public InputAction @LookDirection => m_Wrapper.m_Player_LookDirection;
        public InputAction @Crouch => m_Wrapper.m_Player_Crouch;
        public InputAction @Run => m_Wrapper.m_Player_Run;
        public InputAction @Reload => m_Wrapper.m_Player_Reload;
        public InputAction @Interact => m_Wrapper.m_Player_Interact;
        public InputAction @SelectPrimary => m_Wrapper.m_Player_SelectPrimary;
        public InputAction @SelectSecondary => m_Wrapper.m_Player_SelectSecondary;
        public InputAction @SelectMelee => m_Wrapper.m_Player_SelectMelee;
        public InputAction @SelectDrone => m_Wrapper.m_Player_SelectDrone;
        public InputAction @Vault => m_Wrapper.m_Player_Vault;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Shoot.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @Aim.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @MoveVertical.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveVertical;
                @MoveVertical.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveVertical;
                @MoveVertical.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveVertical;
                @LookDirection.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLookDirection;
                @LookDirection.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLookDirection;
                @LookDirection.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLookDirection;
                @Crouch.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @Run.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                @Reload.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReload;
                @Interact.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @SelectPrimary.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectPrimary;
                @SelectPrimary.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectPrimary;
                @SelectPrimary.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectPrimary;
                @SelectSecondary.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectSecondary;
                @SelectSecondary.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectSecondary;
                @SelectSecondary.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectSecondary;
                @SelectMelee.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectMelee;
                @SelectMelee.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectMelee;
                @SelectMelee.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectMelee;
                @SelectDrone.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectDrone;
                @SelectDrone.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectDrone;
                @SelectDrone.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectDrone;
                @Vault.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnVault;
                @Vault.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnVault;
                @Vault.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnVault;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @MoveVertical.started += instance.OnMoveVertical;
                @MoveVertical.performed += instance.OnMoveVertical;
                @MoveVertical.canceled += instance.OnMoveVertical;
                @LookDirection.started += instance.OnLookDirection;
                @LookDirection.performed += instance.OnLookDirection;
                @LookDirection.canceled += instance.OnLookDirection;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @SelectPrimary.started += instance.OnSelectPrimary;
                @SelectPrimary.performed += instance.OnSelectPrimary;
                @SelectPrimary.canceled += instance.OnSelectPrimary;
                @SelectSecondary.started += instance.OnSelectSecondary;
                @SelectSecondary.performed += instance.OnSelectSecondary;
                @SelectSecondary.canceled += instance.OnSelectSecondary;
                @SelectMelee.started += instance.OnSelectMelee;
                @SelectMelee.performed += instance.OnSelectMelee;
                @SelectMelee.canceled += instance.OnSelectMelee;
                @SelectDrone.started += instance.OnSelectDrone;
                @SelectDrone.performed += instance.OnSelectDrone;
                @SelectDrone.canceled += instance.OnSelectDrone;
                @Vault.started += instance.OnVault;
                @Vault.performed += instance.OnVault;
                @Vault.canceled += instance.OnVault;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnShoot(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnMoveVertical(InputAction.CallbackContext context);
        void OnLookDirection(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnSelectPrimary(InputAction.CallbackContext context);
        void OnSelectSecondary(InputAction.CallbackContext context);
        void OnSelectMelee(InputAction.CallbackContext context);
        void OnSelectDrone(InputAction.CallbackContext context);
        void OnVault(InputAction.CallbackContext context);
    }
}
