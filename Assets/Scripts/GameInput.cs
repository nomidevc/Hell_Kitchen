using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    public event EventHandler OnAlternateInteractAction;
    
    PlayerInputAction m_playerInputAction;

    void Awake()
    {
        m_playerInputAction = new PlayerInputAction();
        m_playerInputAction.Player.Enable();
        
        m_playerInputAction.Player.Interact.performed += InteractOnperformed;
        m_playerInputAction.Player.InteractAlternative.performed += AlternateInteractOnPerformed;
    }
    void AlternateInteractOnPerformed(InputAction.CallbackContext obj)
    {
        OnAlternateInteractAction?.Invoke(this, EventArgs.Empty);
    }
    void InteractOnperformed(InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }
    
    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = m_playerInputAction.Player.Move.ReadValue<Vector2>();
       
        inputVector = inputVector.normalized;
        return inputVector;
    }
}
