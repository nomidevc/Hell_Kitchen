using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class CuttingRecipeSO : ScriptableObject
{
    [SerializeField] private KitchenObjectSO _input;
    [SerializeField] private KitchenObjectSO _output;

    public int cuttingProgressMax;
    
    public KitchenObjectSO Input => _input;
    public KitchenObjectSO Output => _output;
}
