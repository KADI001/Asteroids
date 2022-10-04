//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.2
//     from Assets/Source/Input/UnityShipInput.inputactions
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

public partial class @UnityShipInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @UnityShipInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""UnityShipInput"",
    ""maps"": [
        {
            ""name"": ""Ship"",
            ""id"": ""afacd474-d849-44b6-8c7f-bff0b23bebf5"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""b2dcedb1-be3b-4fa3-83b6-87ea072c5af3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""e5d4245d-499a-43b3-a841-98fc26fe8a85"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""FirstGunShoot"",
                    ""type"": ""Button"",
                    ""id"": ""b9961e26-89ac-41fd-8fd3-aa905db9ec00"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SecondGunShoot"",
                    ""type"": ""Button"",
                    ""id"": ""8c618f87-f510-4d8c-a560-07c1ee49f1dd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Direction"",
                    ""id"": ""68c171b2-43a3-41d1-8a17-5d819749f8fc"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""0321fa35-3017-4036-84f5-bfe35597ec6b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ec5c8093-0399-4175-846d-86b55275cb0d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1663bf7c-145a-44e1-a955-8a9e1c3aefac"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FirstGunShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea9cb0e5-3ec2-434c-9b13-9e865a070e89"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondGunShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Direction"",
                    ""id"": ""3b69dad5-43bd-499d-aec2-0c19a605e413"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c6e8cb21-5745-4ff6-b1a5-62f2da28ceba"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""94382682-d94e-4ed2-b79b-68b08a0c628b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Windows"",
            ""bindingGroup"": ""Windows"",
            ""devices"": []
        }
    ]
}");
        // Ship
        m_Ship = asset.FindActionMap("Ship", throwIfNotFound: true);
        m_Ship_Move = m_Ship.FindAction("Move", throwIfNotFound: true);
        m_Ship_Rotate = m_Ship.FindAction("Rotate", throwIfNotFound: true);
        m_Ship_FirstGunShoot = m_Ship.FindAction("FirstGunShoot", throwIfNotFound: true);
        m_Ship_SecondGunShoot = m_Ship.FindAction("SecondGunShoot", throwIfNotFound: true);
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

    // Ship
    private readonly InputActionMap m_Ship;
    private IShipActions m_ShipActionsCallbackInterface;
    private readonly InputAction m_Ship_Move;
    private readonly InputAction m_Ship_Rotate;
    private readonly InputAction m_Ship_FirstGunShoot;
    private readonly InputAction m_Ship_SecondGunShoot;
    public struct ShipActions
    {
        private @UnityShipInput m_Wrapper;
        public ShipActions(@UnityShipInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Ship_Move;
        public InputAction @Rotate => m_Wrapper.m_Ship_Rotate;
        public InputAction @FirstGunShoot => m_Wrapper.m_Ship_FirstGunShoot;
        public InputAction @SecondGunShoot => m_Wrapper.m_Ship_SecondGunShoot;
        public InputActionMap Get() { return m_Wrapper.m_Ship; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ShipActions set) { return set.Get(); }
        public void SetCallbacks(IShipActions instance)
        {
            if (m_Wrapper.m_ShipActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnMove;
                @Rotate.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnRotate;
                @FirstGunShoot.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnFirstGunShoot;
                @FirstGunShoot.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnFirstGunShoot;
                @FirstGunShoot.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnFirstGunShoot;
                @SecondGunShoot.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnSecondGunShoot;
                @SecondGunShoot.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnSecondGunShoot;
                @SecondGunShoot.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnSecondGunShoot;
            }
            m_Wrapper.m_ShipActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @FirstGunShoot.started += instance.OnFirstGunShoot;
                @FirstGunShoot.performed += instance.OnFirstGunShoot;
                @FirstGunShoot.canceled += instance.OnFirstGunShoot;
                @SecondGunShoot.started += instance.OnSecondGunShoot;
                @SecondGunShoot.performed += instance.OnSecondGunShoot;
                @SecondGunShoot.canceled += instance.OnSecondGunShoot;
            }
        }
    }
    public ShipActions @Ship => new ShipActions(this);
    private int m_WindowsSchemeIndex = -1;
    public InputControlScheme WindowsScheme
    {
        get
        {
            if (m_WindowsSchemeIndex == -1) m_WindowsSchemeIndex = asset.FindControlSchemeIndex("Windows");
            return asset.controlSchemes[m_WindowsSchemeIndex];
        }
    }
    public interface IShipActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnFirstGunShoot(InputAction.CallbackContext context);
        void OnSecondGunShoot(InputAction.CallbackContext context);
    }
}