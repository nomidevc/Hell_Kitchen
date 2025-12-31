using UnityEngine;
namespace ScriptableObjectScripts
{
    [CreateAssetMenu()]
    public class BurningRecipeSO : ScriptableObject
    {
        [SerializeField] private KitchenObjectSO _input;
        [SerializeField] private KitchenObjectSO _output;

        public float burningTimerMax;
    
        public KitchenObjectSO Input => _input;
        public KitchenObjectSO Output => _output;
    }
}
