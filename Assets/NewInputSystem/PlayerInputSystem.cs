//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/NewInputSystem/PlayerInputSystem.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputSystem: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputSystem()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputSystem"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""3b98883e-b465-4f7b-9c40-a5e36a1f5388"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""68fe2b88-0c20-4a96-aaef-e1c930041246"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""ca687023-92ce-44b0-9159-023871861f04"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Target"",
                    ""type"": ""Button"",
                    ""id"": ""be393b6a-f376-4b80-8f8a-ca8b01e2b082"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dodge"",
                    ""type"": ""Button"",
                    ""id"": ""58b58186-2a39-433d-8bcb-7d19c2cf64af"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Recovery"",
                    ""type"": ""Button"",
                    ""id"": ""bdbbb04e-72a0-4747-9182-5b038726a984"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SpellUp"",
                    ""type"": ""Button"",
                    ""id"": ""ec971125-33c1-45f2-9e1a-821b555cf8e7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SpellLeft"",
                    ""type"": ""Button"",
                    ""id"": ""83c9c642-bd8f-4c83-a65c-3d517b1ca511"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SpellRight"",
                    ""type"": ""Button"",
                    ""id"": ""b1306460-11c4-405b-8ebc-77c59b3bee94"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SpellDown"",
                    ""type"": ""Button"",
                    ""id"": ""37b36df8-d741-4b4f-a80c-920da20f2696"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""5f4a867e-2646-4056-84b5-2b8dff3f2b08"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e7b70b4d-bb2a-457d-9ab2-101bf5f6aab3"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3c801568-5284-4afe-9ebe-fb66b87e2225"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""467a6c50-114a-4e35-b71c-17487528a104"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Target"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""98ba8aa6-cbed-4915-92f2-03659ad7cfaa"",
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
                    ""id"": ""d4fc8af5-5b82-4c22-8d64-d05b138816b4"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Recovery"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""One Modifier"",
                    ""id"": ""d8e5eeee-4fff-4c65-8354-c8311a4cfd39"",
                    ""path"": ""OneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpellUp"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""abab49e2-40db-414e-8977-aba5ccb02cd8"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpellUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""binding"",
                    ""id"": ""7ea7e667-cfd1-4c33-a6d2-855e50db58c8"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpellUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""One Modifier"",
                    ""id"": ""5add8032-9654-4d5d-9233-cdf9f395fbdd"",
                    ""path"": ""OneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpellLeft"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""68eea499-b1cc-443b-b756-d535a992b1ff"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpellLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""binding"",
                    ""id"": ""d2335123-93c3-4b30-973c-ce1c2f53286e"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpellLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""One Modifier"",
                    ""id"": ""60bdbf91-d7ab-4b57-8918-703e38b0252c"",
                    ""path"": ""OneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpellRight"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""852caa2d-3539-472f-8670-1b489088400a"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpellRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""binding"",
                    ""id"": ""2ca1449a-e1ad-4e01-8119-6bcd74d2fd4f"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpellRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""One Modifier"",
                    ""id"": ""26447033-a74e-423d-b9e4-1c61407625df"",
                    ""path"": ""OneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpellDown"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""0338c659-2c26-4c58-b638-cd610a2c535c"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpellDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""binding"",
                    ""id"": ""02bc68d1-1070-42ff-be2b-b2908a8e2543"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpellDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""5014f754-7fed-4ded-9a7a-a5968d453863"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Move = m_Movement.FindAction("Move", throwIfNotFound: true);
        m_Movement_Look = m_Movement.FindAction("Look", throwIfNotFound: true);
        m_Movement_Target = m_Movement.FindAction("Target", throwIfNotFound: true);
        m_Movement_Dodge = m_Movement.FindAction("Dodge", throwIfNotFound: true);
        m_Movement_Recovery = m_Movement.FindAction("Recovery", throwIfNotFound: true);
        m_Movement_SpellUp = m_Movement.FindAction("SpellUp", throwIfNotFound: true);
        m_Movement_SpellLeft = m_Movement.FindAction("SpellLeft", throwIfNotFound: true);
        m_Movement_SpellRight = m_Movement.FindAction("SpellRight", throwIfNotFound: true);
        m_Movement_SpellDown = m_Movement.FindAction("SpellDown", throwIfNotFound: true);
        m_Movement_Attack = m_Movement.FindAction("Attack", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Movement
    private readonly InputActionMap m_Movement;
    private List<IMovementActions> m_MovementActionsCallbackInterfaces = new List<IMovementActions>();
    private readonly InputAction m_Movement_Move;
    private readonly InputAction m_Movement_Look;
    private readonly InputAction m_Movement_Target;
    private readonly InputAction m_Movement_Dodge;
    private readonly InputAction m_Movement_Recovery;
    private readonly InputAction m_Movement_SpellUp;
    private readonly InputAction m_Movement_SpellLeft;
    private readonly InputAction m_Movement_SpellRight;
    private readonly InputAction m_Movement_SpellDown;
    private readonly InputAction m_Movement_Attack;
    public struct MovementActions
    {
        private @PlayerInputSystem m_Wrapper;
        public MovementActions(@PlayerInputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Movement_Move;
        public InputAction @Look => m_Wrapper.m_Movement_Look;
        public InputAction @Target => m_Wrapper.m_Movement_Target;
        public InputAction @Dodge => m_Wrapper.m_Movement_Dodge;
        public InputAction @Recovery => m_Wrapper.m_Movement_Recovery;
        public InputAction @SpellUp => m_Wrapper.m_Movement_SpellUp;
        public InputAction @SpellLeft => m_Wrapper.m_Movement_SpellLeft;
        public InputAction @SpellRight => m_Wrapper.m_Movement_SpellRight;
        public InputAction @SpellDown => m_Wrapper.m_Movement_SpellDown;
        public InputAction @Attack => m_Wrapper.m_Movement_Attack;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void AddCallbacks(IMovementActions instance)
        {
            if (instance == null || m_Wrapper.m_MovementActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MovementActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Look.started += instance.OnLook;
            @Look.performed += instance.OnLook;
            @Look.canceled += instance.OnLook;
            @Target.started += instance.OnTarget;
            @Target.performed += instance.OnTarget;
            @Target.canceled += instance.OnTarget;
            @Dodge.started += instance.OnDodge;
            @Dodge.performed += instance.OnDodge;
            @Dodge.canceled += instance.OnDodge;
            @Recovery.started += instance.OnRecovery;
            @Recovery.performed += instance.OnRecovery;
            @Recovery.canceled += instance.OnRecovery;
            @SpellUp.started += instance.OnSpellUp;
            @SpellUp.performed += instance.OnSpellUp;
            @SpellUp.canceled += instance.OnSpellUp;
            @SpellLeft.started += instance.OnSpellLeft;
            @SpellLeft.performed += instance.OnSpellLeft;
            @SpellLeft.canceled += instance.OnSpellLeft;
            @SpellRight.started += instance.OnSpellRight;
            @SpellRight.performed += instance.OnSpellRight;
            @SpellRight.canceled += instance.OnSpellRight;
            @SpellDown.started += instance.OnSpellDown;
            @SpellDown.performed += instance.OnSpellDown;
            @SpellDown.canceled += instance.OnSpellDown;
            @Attack.started += instance.OnAttack;
            @Attack.performed += instance.OnAttack;
            @Attack.canceled += instance.OnAttack;
        }

        private void UnregisterCallbacks(IMovementActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Look.started -= instance.OnLook;
            @Look.performed -= instance.OnLook;
            @Look.canceled -= instance.OnLook;
            @Target.started -= instance.OnTarget;
            @Target.performed -= instance.OnTarget;
            @Target.canceled -= instance.OnTarget;
            @Dodge.started -= instance.OnDodge;
            @Dodge.performed -= instance.OnDodge;
            @Dodge.canceled -= instance.OnDodge;
            @Recovery.started -= instance.OnRecovery;
            @Recovery.performed -= instance.OnRecovery;
            @Recovery.canceled -= instance.OnRecovery;
            @SpellUp.started -= instance.OnSpellUp;
            @SpellUp.performed -= instance.OnSpellUp;
            @SpellUp.canceled -= instance.OnSpellUp;
            @SpellLeft.started -= instance.OnSpellLeft;
            @SpellLeft.performed -= instance.OnSpellLeft;
            @SpellLeft.canceled -= instance.OnSpellLeft;
            @SpellRight.started -= instance.OnSpellRight;
            @SpellRight.performed -= instance.OnSpellRight;
            @SpellRight.canceled -= instance.OnSpellRight;
            @SpellDown.started -= instance.OnSpellDown;
            @SpellDown.performed -= instance.OnSpellDown;
            @SpellDown.canceled -= instance.OnSpellDown;
            @Attack.started -= instance.OnAttack;
            @Attack.performed -= instance.OnAttack;
            @Attack.canceled -= instance.OnAttack;
        }

        public void RemoveCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMovementActions instance)
        {
            foreach (var item in m_Wrapper.m_MovementActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MovementActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MovementActions @Movement => new MovementActions(this);
    public interface IMovementActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnTarget(InputAction.CallbackContext context);
        void OnDodge(InputAction.CallbackContext context);
        void OnRecovery(InputAction.CallbackContext context);
        void OnSpellUp(InputAction.CallbackContext context);
        void OnSpellLeft(InputAction.CallbackContext context);
        void OnSpellRight(InputAction.CallbackContext context);
        void OnSpellDown(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
    }
}