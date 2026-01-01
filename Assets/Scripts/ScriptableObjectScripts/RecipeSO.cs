using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class RecipeSO : ScriptableObject
{
    [SerializeField] private string _foodName;
    [SerializeField] private List<KitchenObjectSO> _recipeKitchenObjectSOList;
    
    public string FoodName => _foodName;
    public List<KitchenObjectSO> RecipeKitchenObjectSOList => _recipeKitchenObjectSOList;
}
