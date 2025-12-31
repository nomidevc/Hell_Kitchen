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
                // Nothing happens
            }
            else
            {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
    
}
