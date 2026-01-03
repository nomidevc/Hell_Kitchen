using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryManagerSingleUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _recipeNameText;
    [SerializeField] private Transform _iconContainerTransform;
    [SerializeField] private Transform _iconTemplateTransform;

    void Awake()
    {
        _iconTemplateTransform.gameObject.SetActive(false);
    }
    
    private void SetRecipeIconVisuals(RecipeSO recipeSO)
    {
        ResetVisuals();
        foreach (KitchenObjectSO kitchenObjectSO in recipeSO.RecipeKitchenObjectSOList)
        {
            Transform iconTransform = Instantiate(_iconTemplateTransform, _iconContainerTransform);
            iconTransform.gameObject.SetActive(true);
            iconTransform.GetComponent<Image>().sprite = kitchenObjectSO.objectSprite;
        }
    }
    
    private void ResetVisuals()
    {
        foreach (Transform child in _iconContainerTransform)
        {
            if (child == _iconTemplateTransform) continue;
            Destroy(child.gameObject);
        }
    }

    public void SetRecipeName(RecipeSO recipeSO)
    {
        _recipeNameText.text = recipeSO.FoodName;
        SetRecipeIconVisuals(recipeSO);
    }
}
