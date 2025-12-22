using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO _kitchenObjectSo;
    [SerializeField] private Transform _counterTopPoint;
    
    
    public void Interact()
    {
       Transform kitchenObjectPrefab = Instantiate(_kitchenObjectSo.prefab, _counterTopPoint);
       kitchenObjectPrefab.localPosition = Vector3.zero;
       
       Debug.Log(kitchenObjectPrefab.GetComponent<KitchenObject>().GetKitchenObjectSO().objectName + " spawned on counter");
    }
}
