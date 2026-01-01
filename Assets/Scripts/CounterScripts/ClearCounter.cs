using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO _kitchenObjectSo;

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
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
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject)) // Player has plate
                {
                    if (plateKitchenObject.TryAddRecipeToPlate(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().SelfDestroy();
                    }
                }
                else
                {
                    if(GetKitchenObject().TryGetPlate(out PlateKitchenObject counterPlateKitchenObject)) // Counter has plate
                    {
                        if (counterPlateKitchenObject.TryAddRecipeToPlate(player.GetKitchenObject().GetKitchenObjectSO()))
                        {
                            player.GetKitchenObject().SelfDestroy();
                        }
                    }
                }
            }
            else
            {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
