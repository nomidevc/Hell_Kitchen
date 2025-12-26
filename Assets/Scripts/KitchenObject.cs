using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private ClearCounter m_clearCounter;
    
    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }
    
    public void SetClearCounter(ClearCounter clearCounter)
    {
        if (this.m_clearCounter != null)
        {
            m_clearCounter.ClearKitchenObject();
        }
        
        m_clearCounter = clearCounter;
        if (clearCounter.HasKitchenObject())
        {
            Debug.LogError("Counter already has a kitchen object!");
        }
        
        m_clearCounter.SetKitchenObject(this);
        transform.parent = clearCounter.GetKitcherObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public ClearCounter GetClearCounter()
    {
        return this.m_clearCounter;
    }
}
