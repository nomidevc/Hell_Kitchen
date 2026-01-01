using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{
    [Serializable]
    public struct KitchenObjectSO_GameObjectPair
    {
        public KitchenObjectSO kitchenObjectSO;
        public GameObject gameObject;
    }
    
    [SerializeField] private PlateKitchenObject _plateKitchenObject;
    [SerializeField] private KitchenObjectSO_GameObjectPair[] _kitchenObjectSOGameObjectPairs;

    void Start()
    {
        _plateKitchenObject.OnRecipeAdded += PlateKitchenObject_OnRecipeAdded;

        foreach (KitchenObjectSO_GameObjectPair kitchenObjectSoGameObjectPair in _kitchenObjectSOGameObjectPairs)
        {
            kitchenObjectSoGameObjectPair.gameObject.SetActive(false);
        }
    }
    void PlateKitchenObject_OnRecipeAdded(object sender, PlateKitchenObject.OnRecipeAddedEventArgs e)
    {
        foreach (KitchenObjectSO_GameObjectPair kitchenObjectSoGameObjectPair in _kitchenObjectSOGameObjectPairs)
        {
            if (kitchenObjectSoGameObjectPair.kitchenObjectSO == e.recipeAddedkitchenObjectSO)
            {
                kitchenObjectSoGameObjectPair.gameObject.SetActive(true);
            }
        }
    }
}
