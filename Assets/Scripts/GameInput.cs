using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    PlayerInputAction m_playerInputAction;

    void Awake()
    {
        m_playerInputAction = new PlayerInputAction();
        m_playerInputAction.Player.Enable();
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = m_playerInputAction.Player.Move.ReadValue<Vector2>();
       
        inputVector = inputVector.normalized;
        return inputVector;
    }
}
