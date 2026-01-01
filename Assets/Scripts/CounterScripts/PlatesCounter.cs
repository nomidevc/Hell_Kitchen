using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounter : BaseCounter
{
    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlatePickedUp;
    
    [SerializeField] private KitchenObjectSO _plateKitchenObjectSO;
    
    private float m_spawnPlateTimer;
    private float m_spawnPlateTimerMax = 4f;
    
    private int m_plateSpawnedCount;
    private int m_plateSpawnedCountMax = 4;

    void Update()
    {
        m_spawnPlateTimer += Time.deltaTime;
        if (m_spawnPlateTimer >= m_spawnPlateTimerMax)
        {
            m_spawnPlateTimer = 0f;
            if (m_plateSpawnedCount < m_plateSpawnedCountMax)
            {
                m_plateSpawnedCount++;
                OnPlateSpawned?.Invoke(this, EventArgs.Empty);
                // KitchenObject.SpawnKitchenObject(_plateKitchenObjectSO, this);
            }
        }
    }

    public override void Interact(Player player)
    {
        if (m_plateSpawnedCount > 0)
        {
            if (!player.HasKitchenObject())
            {
                m_plateSpawnedCount -= 1;
                KitchenObject.SpawnKitchenObject(_plateKitchenObjectSO, player);
                
                OnPlatePickedUp?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
