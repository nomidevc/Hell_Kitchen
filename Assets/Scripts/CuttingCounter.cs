using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CuttingCounter : BaseCounter
{
    public event EventHandler<OnCuttingProgressChangedEventArgs> OnCuttingProgressChanged;
    public class OnCuttingProgressChangedEventArgs : EventArgs
    {
        public float cuttingProgressNormalized;
    }

    public event EventHandler OnCutting;
    
    [SerializeField] private CuttingRecipeSO[] _cuttingInputRecipeObjectSo;

    private int m_cuttingProgress;
    
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject() && HasCuttableKitchenObject(player.GetKitchenObject().GetKitchenObjectSO()))
            {
                player.GetKitchenObject().SetKitchenObjectParent(this);
                m_cuttingProgress = 0;
                
                CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());
                OnCuttingProgressChanged?.Invoke(this, new OnCuttingProgressChangedEventArgs()
                {
                    cuttingProgressNormalized = (float)m_cuttingProgress / cuttingRecipeSO.cuttingProgressMax
                });
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
        if (HasKitchenObject() && HasCuttableKitchenObject(GetKitchenObject().GetKitchenObjectSO()))
        {
            KitchenObjectSO inputKitchenObjectSo = GetKitchenObject().GetKitchenObjectSO();

            m_cuttingProgress++;
            CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(inputKitchenObjectSo);
            OnCutting?.Invoke(this, EventArgs.Empty);
            OnCuttingProgressChanged?.Invoke(this, new OnCuttingProgressChangedEventArgs()
            {
                cuttingProgressNormalized = (float)m_cuttingProgress / cuttingRecipeSO.cuttingProgressMax
            });
            
            if (m_cuttingProgress >= cuttingRecipeSO.cuttingProgressMax)
            {
                KitchenObjectSO cutKitchenObjectSo = GetOutputForInput(inputKitchenObjectSo);
                GetKitchenObject().SelfDestroy();

                KitchenObject.SpawnKitchenObject(cutKitchenObjectSo, this);
            }
        }
    }
    
    private bool HasCuttableKitchenObject(KitchenObjectSO input)
    {
        CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(input);
        return cuttingRecipeSO != null;
    }
    
    private KitchenObjectSO GetOutputForInput(KitchenObjectSO input)
    {
        CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(input);
        if (cuttingRecipeSO != null)
        {
            return cuttingRecipeSO.Output;
        }
        return null;
    }
    
    private CuttingRecipeSO GetCuttingRecipeSOWithInput(KitchenObjectSO input)
    {
        foreach (CuttingRecipeSO recipe in _cuttingInputRecipeObjectSo)
        {
            if(recipe.Input == input)
            {
                return recipe;
            }
        }

        return null;
    }
}
