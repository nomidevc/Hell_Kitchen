using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [FormerlySerializedAs("moveSpeed"),SerializeField] private float _moveSpeed = 5f;
    [FormerlySerializedAs("gameInput"),SerializeField] private GameInput _gameInput;
    
    private bool m_isWalking = false;
    
    void Update()
    {
        Vector2 inputVector = _gameInput.GetMovementVectorNormalized();
        
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        transform.position += moveDir * (Time.deltaTime * _moveSpeed);
        
        m_isWalking = moveDir != Vector3.zero;
        
        float rotationSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, rotationSpeed * Time.deltaTime);
    }
    
    public bool IsWalking()
    {
        return m_isWalking;
    }
}
