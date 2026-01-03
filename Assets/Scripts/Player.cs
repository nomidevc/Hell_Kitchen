using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour, IKitchenObjectParent
{
    public static Player Instance { get; private set; }
    public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;
    public class OnSelectedCounterChangedEventArgs : EventArgs
    {
        public BaseCounter selectedCounter;
    }
    
    public event EventHandler OnPickedSomething;
    
    [FormerlySerializedAs("moveSpeed"),SerializeField] private float _moveSpeed = 5f;
    [FormerlySerializedAs("gameInput"),SerializeField] private GameInput _gameInput;
    [SerializeField] private LayerMask _counterInteractLayerMask;
    
    [SerializeField] private Transform _kitchenObjectHoldPoint;
    
    private bool m_isWalking = false;
    private Vector3 m_lastInteractDirection;
    private BaseCounter m_SelectedCounter;
    private KitchenObject m_kitchenObject;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of Player");
        }
        Instance = this;
    }

    void Start()
    {
        _gameInput.OnInteractAction += GameInputOnOnInteractAction;
        _gameInput.OnAlternateInteractAction += GameInputOnOnAlternateInteractAction;
    }
    void GameInputOnOnAlternateInteractAction(object sender, EventArgs e)
    {
        if (m_SelectedCounter != null)
        {
            m_SelectedCounter.AlternateInteract(this);
        }
    }
    void GameInputOnOnInteractAction(object sender, EventArgs e)
    {
        if (m_SelectedCounter != null)
        {
            m_SelectedCounter.Interact(this);
        }
    }

    void Update()
    {
        HandleMovement();
        HandleInteractions();
    }
    
    private void HandleInteractions()
    {
        Vector2 inputVector = _gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        if (moveDir != Vector3.zero)
        {
            m_lastInteractDirection = moveDir;
        }
        
        float interactDistance = 2f;
        if (Physics.Raycast(transform.position, m_lastInteractDirection, out RaycastHit hit, interactDistance, _counterInteractLayerMask))
        {
            if (hit.transform.TryGetComponent<BaseCounter>(out BaseCounter baseCounter))
            {
                if (m_SelectedCounter != baseCounter)
                {
                    SetSelectCounter(baseCounter);
                }
            }
            else
            {
                SetSelectCounter(null);
            }
        }
        else
        {
            SetSelectCounter(null);
        }
    }
    void SetSelectCounter(BaseCounter baseCounter)
    {

        m_SelectedCounter = baseCounter;
        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs
        {
            selectedCounter = m_SelectedCounter
        });
    }
    private void HandleMovement()
    {
        Vector2 inputVector = _gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        
        float moveDistance = Time.deltaTime * _moveSpeed;
        float playerHeight = 2f;
        float playerSize = .7f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight,
            playerSize, moveDir, moveDistance);

        if (!canMove) // Can not move in the moveDir
        {
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight,
                playerSize, new Vector3(moveDirX.x, 0, 0), moveDistance);
            if (canMove) // Can move only in the x dir
            {
                moveDir = moveDirX;
            }
            else
            {
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight,
                    playerSize, new Vector3(0, 0, moveDirZ.y), moveDistance);
                if (canMove) // Can move only in the z dir
                {
                    moveDir = moveDirZ;
                }
                else
                {
                    // Can not move in any dir
                }
            }
            
        }
        
        if (canMove)
        {
            transform.position += moveDir * moveDistance;
        }
        
        m_isWalking = moveDir != Vector3.zero;
        
        float rotationSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, rotationSpeed * Time.deltaTime);
    }

    public bool IsWalking()
    {
        return m_isWalking;
    }
    public Transform GetKitchenObjectFollowTransform()
    {
        return _kitchenObjectHoldPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        m_kitchenObject = kitchenObject;
        if(m_kitchenObject != null)
        {
            OnPickedSomething?.Invoke(this, EventArgs.Empty);
        }
    }

    public KitchenObject GetKitchenObject()
    {
        return m_kitchenObject;
    }
    
    public void ClearKitchenObject()
    {
        m_kitchenObject = null;
    }
    
    public bool HasKitchenObject()
    {
        return m_kitchenObject != null;
    }
}
