using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateRecipeIconUI : MonoBehaviour
{
    [SerializeField] private PlateKitchenObject _plateKitchenObject;
    [SerializeField] private Transform _iconRecipeTemplate;

    void Awake()
    {
        _iconRecipeTemplate.gameObject.SetActive(false);
    }

    void Start()
    {
        _plateKitchenObject.OnRecipeAdded += PlateKitchenObject_OnRecipeAdded;
    }
    void PlateKitchenObject_OnRecipeAdded(object sender, PlateKitchenObject.OnRecipeAddedEventArgs e)
    {
        UpdateRecipeAddedIcons();
    }
    private void UpdateRecipeAddedIcons()
    {
        ResetVisual();
        foreach (KitchenObjectSO recipeAddedKitchenObjSO in _plateKitchenObject.GetKitchenObjectSOList())
        {
            Transform iconRecipeTransform = Instantiate(_iconRecipeTemplate, transform);
            iconRecipeTransform.gameObject.SetActive(true);
            iconRecipeTransform.GetComponent<RecipeIconUI>().SetRecipeIcon(recipeAddedKitchenObjSO);
        }
    }
    
    private void ResetVisual()
    {
        foreach (Transform child in transform)
        {
            if (child == _iconRecipeTemplate) continue;
            Destroy(child.gameObject);
        }
    }
}
