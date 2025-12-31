using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectScripts;
using UnityEngine;

public class StoveCounter : BaseCounter, IHasProgress
{
    public event EventHandler<IHasProgress.OnProgressChangedEventArgs> OnProgressChanged;
    public event EventHandler<OnStateChangedEventArgs> OnStateChanged;
    public class OnStateChangedEventArgs : EventArgs
    {
        public State state;
    }
    
    [SerializeField] private FryingRecipeSO[] _fryingRecipeSOArray;
    [SerializeField] private BurningRecipeSO[] _burningRecipeSOArray;
    
    public enum State
    {
        Idle,
        Frying,
        Fried,
        Burned
    }
    
    private State m_state;
    private float m_fryingTimer;
    private float m_burningTimer;
    private FryingRecipeSO m_fryingRecipe;
    private BurningRecipeSO m_burningRecipe;

    void Start()
    {
        m_state = State.Idle;
    }

    void Update()
    {
        if (HasKitchenObject())
        {
            switch (m_state)    
            {
                case State.Idle:
                    break;
                case State.Frying:
                    m_fryingTimer += Time.deltaTime;
                    OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs()
                    {
                        progressNormalized = m_fryingTimer / m_fryingRecipe.fryingTimerMax
                    });
                    if (m_fryingTimer >= m_fryingRecipe.fryingTimerMax)
                    {
                        KitchenObjectSO friedRecipeSO = m_fryingRecipe.Output;
                        GetKitchenObject().SelfDestroy();
                        KitchenObject.SpawnKitchenObject(friedRecipeSO, this);
                        m_state = State.Fried;
                        m_burningRecipe = GetBurningRecipeSOWithInput(friedRecipeSO);
                        m_burningTimer = 0f; 
                        
                        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs()
                        {
                            state = m_state
                        });
                    }
                    break;
                case State.Fried:
                    m_burningTimer += Time.deltaTime;
                    OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs()
                    {
                        progressNormalized = m_burningTimer / m_burningRecipe.burningTimerMax
                    });
                    if (m_burningTimer >= m_burningRecipe.burningTimerMax)
                    {
                        KitchenObjectSO burnedRecipeSO = m_burningRecipe.Output;
                        GetKitchenObject().SelfDestroy();
                        KitchenObject.SpawnKitchenObject(burnedRecipeSO, this);
                        m_state = State.Burned;
                        
                        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs()
                        {
                            state = m_state
                        });
                    }
                    break;
                case State.Burned:
                    OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs()
                    {
                        progressNormalized = 0f
                    });
                    break;
            }
        }
    }

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject() && HasFryableKitchenObject(player.GetKitchenObject().GetKitchenObjectSO()))
            {
                player.GetKitchenObject().SetKitchenObjectParent(this);
                m_fryingRecipe = GetFryingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());
                m_state = State.Frying;
                m_fryingTimer = 0f;
                OnStateChanged?.Invoke(this, new OnStateChangedEventArgs()
                {
                    state = m_state
                });
                
                OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs()
                {
                    progressNormalized = m_fryingTimer / m_fryingRecipe.fryingTimerMax
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
                m_state = State.Idle;
                OnStateChanged?.Invoke(this, new OnStateChangedEventArgs()
                {
                    state = m_state
                });
                OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs()
                {
                    progressNormalized = 0f
                });
            }
        }
    }
    
    private bool HasFryableKitchenObject(KitchenObjectSO input)
    {
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(input);
        return fryingRecipeSO != null;
    }
    
    private KitchenObjectSO GetOutputForInput(KitchenObjectSO input)
    {
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(input);
        if (fryingRecipeSO != null)
        {
            return fryingRecipeSO.Output;
        }
        return null;
    }
    
    private FryingRecipeSO GetFryingRecipeSOWithInput(KitchenObjectSO input)
    {
        foreach (FryingRecipeSO recipe in _fryingRecipeSOArray)
        {
            if(recipe.Input == input)
            {
                return recipe;
            }
        }

        return null;
    }
    
    private BurningRecipeSO GetBurningRecipeSOWithInput(KitchenObjectSO input)
    {
        foreach (BurningRecipeSO recipe in _burningRecipeSOArray)
        {
            if(recipe.Input == input)
            {
                return recipe;
            }
        }

        return null;
    }
}
