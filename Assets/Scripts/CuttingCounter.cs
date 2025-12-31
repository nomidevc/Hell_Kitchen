using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private CuttingRecipeSO[] _cuttingInputRecipeObjectSo;
    
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject() && HasCutableKitchenObject(player.GetKitchenObject().GetKitchenObjectSO()))
            {
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                // Nothing happens
            }
        }
        else
        {
            if (player.HasKitchenObject())
            {
                // Nothing happens
            }
            else
            {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

    public override void AlternateInteract(Player player)
    {
        if (HasKitchenObject() && HasCutableKitchenObject(GetKitchenObject().GetKitchenObjectSO()))
        {
            KitchenObjectSO inputKitchenObjectSo = GetKitchenObject().GetKitchenObjectSO();
            KitchenObjectSO cutKitchenObjectSo = GetOutputForInput(inputKitchenObjectSo);
            GetKitchenObject().SelfDestroy();

            KitchenObject.SpawnKitchenObject(cutKitchenObjectSo, this);
        }
    }
    
    private bool HasCutableKitchenObject(KitchenObjectSO input)
    {
        foreach (CuttingRecipeSO recipe in _cuttingInputRecipeObjectSo)
        {
            if(recipe.Input == input)
            {
                return true;
            }
        }

        return false;
    }
    
    private KitchenObjectSO GetOutputForInput(KitchenObjectSO input)
    {
        foreach (CuttingRecipeSO recipe in _cuttingInputRecipeObjectSo)
        {
            if(recipe.Input == input)
            {
                return recipe.Output;
            }
        }

        return null;
    }
}
