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
                if (player.GetKitchenObject() is PlateKitchenObject) // Player has plate
                {
                    PlateKitchenObject plateKitchenObject = player.GetKitchenObject() as PlateKitchenObject;
                    plateKitchenObject.AddRecipeToPlate(GetKitchenObject().GetKitchenObjectSO());
                    GetKitchenObject().SelfDestroy();
                }
                else
                {
                    GetKitchenObject().SetKitchenObjectParent(player);
                }
            }
        }
    }
}
