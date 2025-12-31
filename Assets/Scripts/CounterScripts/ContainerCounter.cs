using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContainerCounter : BaseCounter
{
    public event EventHandler OnPlayerInteractEvent;
    
    [SerializeField] private KitchenObjectSO _kitchenObjectSo;
    
    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject())
        {
            KitchenObject.SpawnKitchenObject(_kitchenObjectSo, player);
        
            OnPlayerInteractEvent?.Invoke(this, EventArgs.Empty);
        }
    }
    
}
