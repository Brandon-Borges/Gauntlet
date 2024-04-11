//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Scripts/PlayerInputs/ValkyrieInputs.inputactions
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

public partial class @ValkyrieInputs: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @ValkyrieInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ValkyrieInputs"",
    ""maps"": [
        {
            ""name"": ""Valkyrie"",
            ""id"": ""c64d8bfe-af0a-4964-b352-4e798ed0410f"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""651e48fc-dbb2-4b3f-bd86-93a56d5e9d5b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""TFGH"",
                    ""id"": ""15d3dbc7-4a9c-4928-8bf1-16577d4021ad"",
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
                    ""id"": ""40316865-639a-4caf-a363-5c1f8e629223"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0818470c-fff9-4773-90e6-da23d8f530d0"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""84c46517-cb90-4817-a9c5-a4d5e549fd5c"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""64b50af4-3fed-417b-86db-7d0263b2f4c5"",
                    ""path"": ""<Keyboard>/h"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Valkyrie
        m_Valkyrie = asset.FindActionMap("Valkyrie", throwIfNotFound: true);
        m_Valkyrie_Move = m_Valkyrie.FindAction("Move", throwIfNotFound: true);
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

    // Valkyrie
    private readonly InputActionMap m_Valkyrie;
    private List<IValkyrieActions> m_ValkyrieActionsCallbackInterfaces = new List<IValkyrieActions>();
    private readonly InputAction m_Valkyrie_Move;
    public struct ValkyrieActions
    {
        private @ValkyrieInputs m_Wrapper;
        public ValkyrieActions(@ValkyrieInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Valkyrie_Move;
        public InputActionMap Get() { return m_Wrapper.m_Valkyrie; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ValkyrieActions set) { return set.Get(); }
        public void AddCallbacks(IValkyrieActions instance)
        {
            if (instance == null || m_Wrapper.m_ValkyrieActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ValkyrieActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
        }

        private void UnregisterCallbacks(IValkyrieActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
        }

        public void RemoveCallbacks(IValkyrieActions instance)
        {
            if (m_Wrapper.m_ValkyrieActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IValkyrieActions instance)
        {
            foreach (var item in m_Wrapper.m_ValkyrieActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ValkyrieActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ValkyrieActions @Valkyrie => new ValkyrieActions(this);
    public interface IValkyrieActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
}
