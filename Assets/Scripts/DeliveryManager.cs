using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    public event EventHandler OnRecipeSpawned;
    public event EventHandler OnRecipeCompleted;
    
    public event EventHandler OnDeliverySuccess;
    public event EventHandler OnDeliveryFailed;
    
    public static DeliveryManager Instance { get; private set; }
    
    [SerializeField] private RecipeListSO _recipeListSO;
    
    private List<RecipeSO> m_waitingRecipeSOList;
    
    private float m_spawmRecipeTimer;
    private float m_spawnRecipeTimerMax = 4f;
    
    private int m_maxWaitingRecipeCount = 4;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one DeliveryManager instance");
        }
        Instance = this;
        
        m_waitingRecipeSOList = new List<RecipeSO>();
    }

    void Update()
    {
        m_spawmRecipeTimer -= Time.deltaTime;
        if (m_spawmRecipeTimer <= 0)
        {
            m_spawmRecipeTimer = m_spawnRecipeTimerMax;
            
            if (m_waitingRecipeSOList.Count < m_maxWaitingRecipeCount)
            {
                RecipeSO waitingRecipeSO = _recipeListSO.recipes[UnityEngine.Random.Range(0, _recipeListSO.recipes.Count)];
                m_waitingRecipeSOList.Add(waitingRecipeSO);
                OnRecipeSpawned?.Invoke(this, EventArgs.Empty);
            }
            
        }
    }
    
    public void DeliverRecipe(PlateKitchenObject deliveredPlate)
    {
        for (int i = 0; i < m_waitingRecipeSOList.Count; i++)
        {
            RecipeSO waitingRecipeSO = m_waitingRecipeSOList[i];
            if (waitingRecipeSO.RecipeKitchenObjectSOList.Count == deliveredPlate.GetKitchenObjectSOList().Count)
            {
                bool foundMatchesPlate = true;
                foreach (KitchenObjectSO recipeKitchenObjSO in waitingRecipeSO.RecipeKitchenObjectSOList)
                {
                    bool foundMatchRecipe = false;
                    foreach (KitchenObjectSO recipeInPlate in deliveredPlate.GetKitchenObjectSOList())
                    {
                        if (recipeInPlate == recipeKitchenObjSO)
                        {
                            foundMatchRecipe = true;
                            break;
                        }
                    }
                    if (!foundMatchRecipe)
                    {
                        foundMatchesPlate = false;
                    }
                }
                if (foundMatchesPlate) // Delivered plate matches waiting recipe
                {
                    m_waitingRecipeSOList.RemoveAt(i);
                    OnRecipeCompleted?.Invoke(this, EventArgs.Empty);
                    OnDeliverySuccess?.Invoke(this, EventArgs.Empty);
                    return;
                }
            }
        }
        // No matches found
        OnDeliveryFailed?.Invoke(this, EventArgs.Empty);
        return;
    }
    
    public List<RecipeSO> GetWaitingRecipeSOList()
    {
        return m_waitingRecipeSOList;
    }

}
