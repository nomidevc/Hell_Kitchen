using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private KitchenObjectSO _kitchenObjectSo;
    [SerializeField] private Transform _counterTopPoint;
    
    private KitchenObject m_kitchenObject;

    public void Interact(Player player)
    {
        if (m_kitchenObject == null)
        {
            Transform kitchenObjectPrefab = Instantiate(_kitchenObjectSo.prefab, _counterTopPoint);
            kitchenObjectPrefab.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        }
        else
        {
            m_kitchenObject.SetKitchenObjectParent(player);
        }
    }
    
    public Transform GetKitchenObjectFollowTransform()
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
