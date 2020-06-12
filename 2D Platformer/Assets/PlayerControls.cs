// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""PlayerGameplay"",
            ""id"": ""4322e1e8-64f3-4bb9-a2c0-002eade19e00"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e4c50591-3f13-4919-b960-043a55f3a790"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""f755b640-4d9b-4d2b-b9e0-67400e79e425"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""0388982a-029b-416a-b024-36e349ab9f42"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dodge"",
                    ""type"": ""Button"",
                    ""id"": ""8f527197-07ff-46e3-83b4-288306acd743"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""da641fd6-0fe7-44e8-a52d-c8fa0ad420a4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Super"",
                    ""type"": ""Button"",
                    ""id"": ""95b50822-8746-4099-a97d-b7cf3ac835da"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""02a5f081-5bf9-4754-96b2-dea9822e0f88"",
                    ""path"": ""<Gamepad>/leftStick/"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""8eca58ec-3502-4fdb-bb64-525c39063623"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2a0e73a5-ac8d-499b-afb6-bf59c24b72ba"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""94ee6079-c9aa-4d04-acfa-96c5d78a1998"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""cacf9f02-f9a9-4502-aad7-6aafd57538e0"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3f072f1f-e7c0-421d-ba9e-caa485dae89e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""49d5b577-b1b4-4789-a017-860874d864e9"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""423e7c86-0a6d-4c2a-bcde-2fb4ffd83872"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""942cee78-7158-45e1-a5cf-039a0af8cbc7"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""495dac4b-6ba0-4118-82af-6929ce61726d"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2e62fab3-3591-447e-b23a-8dfc480b1f1e"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""233c0dd7-6de5-4f21-8e33-345de6432be0"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""77c997af-3f54-42dd-9e7b-d45066cce16e"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b531513a-7aac-486b-afbe-61797a6a225b"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c00165bb-ac75-416c-8bb4-7ec40e6002b7"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Super"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e7acaf31-2f24-45db-b698-68f93b82b2fc"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Super"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerGameplay
        m_PlayerGameplay = asset.FindActionMap("PlayerGameplay", throwIfNotFound: true);
        m_PlayerGameplay_Move = m_PlayerGameplay.FindAction("Move", throwIfNotFound: true);
        m_PlayerGameplay_Jump = m_PlayerGameplay.FindAction("Jump", throwIfNotFound: true);
        m_PlayerGameplay_Attack = m_PlayerGameplay.FindAction("Attack", throwIfNotFound: true);
        m_PlayerGameplay_Dodge = m_PlayerGameplay.FindAction("Dodge", throwIfNotFound: true);
        m_PlayerGameplay_Interact = m_PlayerGameplay.FindAction("Interact", throwIfNotFound: true);
        m_PlayerGameplay_Super = m_PlayerGameplay.FindAction("Super", throwIfNotFound: true);
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

    // PlayerGameplay
    private readonly InputActionMap m_PlayerGameplay;
    private IPlayerGameplayActions m_PlayerGameplayActionsCallbackInterface;
    private readonly InputAction m_PlayerGameplay_Move;
    private readonly InputAction m_PlayerGameplay_Jump;
    private readonly InputAction m_PlayerGameplay_Attack;
    private readonly InputAction m_PlayerGameplay_Dodge;
    private readonly InputAction m_PlayerGameplay_Interact;
    private readonly InputAction m_PlayerGameplay_Super;
    public struct PlayerGameplayActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerGameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerGameplay_Move;
        public InputAction @Jump => m_Wrapper.m_PlayerGameplay_Jump;
        public InputAction @Attack => m_Wrapper.m_PlayerGameplay_Attack;
        public InputAction @Dodge => m_Wrapper.m_PlayerGameplay_Dodge;
        public InputAction @Interact => m_Wrapper.m_PlayerGameplay_Interact;
        public InputAction @Super => m_Wrapper.m_PlayerGameplay_Super;
        public InputActionMap Get() { return m_Wrapper.m_PlayerGameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerGameplayActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerGameplayActions instance)
        {
            if (m_Wrapper.m_PlayerGameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerGameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerGameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerGameplayActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_PlayerGameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerGameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerGameplayActionsCallbackInterface.OnJump;
                @Attack.started -= m_Wrapper.m_PlayerGameplayActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PlayerGameplayActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PlayerGameplayActionsCallbackInterface.OnAttack;
                @Dodge.started -= m_Wrapper.m_PlayerGameplayActionsCallbackInterface.OnDodge;
                @Dodge.performed -= m_Wrapper.m_PlayerGameplayActionsCallbackInterface.OnDodge;
                @Dodge.canceled -= m_Wrapper.m_PlayerGameplayActionsCallbackInterface.OnDodge;
                @Interact.started -= m_Wrapper.m_PlayerGameplayActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerGameplayActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerGameplayActionsCallbackInterface.OnInteract;
                @Super.started -= m_Wrapper.m_PlayerGameplayActionsCallbackInterface.OnSuper;
                @Super.performed -= m_Wrapper.m_PlayerGameplayActionsCallbackInterface.OnSuper;
                @Super.canceled -= m_Wrapper.m_PlayerGameplayActionsCallbackInterface.OnSuper;
            }
            m_Wrapper.m_PlayerGameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Dodge.started += instance.OnDodge;
                @Dodge.performed += instance.OnDodge;
                @Dodge.canceled += instance.OnDodge;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Super.started += instance.OnSuper;
                @Super.performed += instance.OnSuper;
                @Super.canceled += instance.OnSuper;
            }
        }
    }
    public PlayerGameplayActions @PlayerGameplay => new PlayerGameplayActions(this);
    public interface IPlayerGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnDodge(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnSuper(InputAction.CallbackContext context);
    }
}
