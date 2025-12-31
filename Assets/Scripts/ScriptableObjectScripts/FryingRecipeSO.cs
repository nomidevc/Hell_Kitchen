using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class FryingRecipeSO : ScriptableObject
{
    [SerializeField] private KitchenObjectSO _input;
    [SerializeField] private KitchenObjectSO _output;

    public float fryingTimerMax;
    
    public KitchenObjectSO Input => _input;
    public KitchenObjectSO Output => _output;
}
