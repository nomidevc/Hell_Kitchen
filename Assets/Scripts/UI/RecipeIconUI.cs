using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeIconUI : MonoBehaviour
{
    [SerializeField] private Image _recipeIconImage;
    
    public void SetRecipeIcon(KitchenObjectSO recipeKitchenObjectSO)
    {
        _recipeIconImage.sprite = recipeKitchenObjectSO.objectSprite;
    }
}
