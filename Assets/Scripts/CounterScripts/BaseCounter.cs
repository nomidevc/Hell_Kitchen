using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent
{
    public static event EventHandler OnPlacedSomethingOnCounter;
    
    [SerializeField] private Transform _counterTopPoint;
    
    private KitchenObject m_kitchenObject;
    
    public virtual void Interact(Player player)
    {
        Debug.LogError("BaseCounter Interact get called");
    }

    public virtual void AlternateInteract(Player player)
    {
        Debug.LogError("BaseCounter Alternate Interact get called");
    }
    
    public Transform GetKitchenObjectFollowTransform()
    {
        return _counterTopPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        m_kitchenObject = kitchenObject;
        if (m_kitchenObject != null)
        {
            OnPlacedSomethingOnCounter?.Invoke(this, EventArgs.Empty);
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
