using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    [SerializeField] private List<KitchenObjectSO> _validKitchenObjectSORecipeList;
    private List<KitchenObjectSO> m_kitchenObjectSOList;

    void Awake()
    {
        m_kitchenObjectSOList = new List<KitchenObjectSO>();
    }
    
    public bool TryAddRecipeToPlate(KitchenObjectSO kitchenObjectSO)
    {
        if (!_validKitchenObjectSORecipeList.Contains(kitchenObjectSO))
        {
            Debug.Log("Invalid Recipe for plate" + kitchenObjectSO.objectName);
            return false;
        }
        if (m_kitchenObjectSOList.Contains(kitchenObjectSO))
        {
            Debug.Log("Plate already has this recipe");
            return false;
        }
        m_kitchenObjectSOList.Add(kitchenObjectSO);
        return true;
    }
}
