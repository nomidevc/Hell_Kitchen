using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO _kitchenObjectSo;
    [SerializeField] private Transform _counterTopPoint;
    [SerializeField] private ClearCounter _otherCounter;
    
    private KitchenObject m_kitchenObject;
    public bool testing;

    void Update()
    {
        if(testing && Input.GetKeyDown(KeyCode.T))
        {
            if (m_kitchenObject != null)
            {
                m_kitchenObject.SetClearCounter(_otherCounter);
            }
        }
    }

    public void Interact()
    {
        if (m_kitchenObject == null)
        {
            Transform kitchenObjectPrefab = Instantiate(_kitchenObjectSo.prefab, _counterTopPoint);
            kitchenObjectPrefab.GetComponent<KitchenObject>().SetClearCounter(this);
        }
        else
        {
            Debug.Log(m_kitchenObject.GetClearCounter());
        }
    }
    
    public Transform GetKitcherObjectFollowTransform()
    {
        return _counterTopPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        m_kitchenObject = kitchenObject;
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
