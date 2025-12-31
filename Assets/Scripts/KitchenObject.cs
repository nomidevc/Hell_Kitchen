using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.TestTools;

public class KitchenObject : MonoBehaviour
{
    [FormerlySerializedAs("kitchenObjectSO"),SerializeField] private KitchenObjectSO _kitchenObjectSO;

    private IKitchenObjectParent m_kitchenObjectParent;
    
    public KitchenObjectSO GetKitchenObjectSO()
    {
        return _kitchenObjectSO;
    }
    
    public void SetKitchenObjectParent(IKitchenObjectParent kitchenObjectParent)
    {
        if (this.m_kitchenObjectParent != null)
        {
            m_kitchenObjectParent.ClearKitchenObject();
        }
        
        m_kitchenObjectParent = kitchenObjectParent;
        if (kitchenObjectParent.HasKitchenObject())
        {
            Debug.LogError("Counter already has a kitchen object!");
        }
        
        m_kitchenObjectParent.SetKitchenObject(this);
        transform.parent = kitchenObjectParent.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public IKitchenObjectParent GetKitchenObjectParent()
    {
        return this.m_kitchenObjectParent;
    }
    
    public void SelfDestroy()
    {
        m_kitchenObjectParent.ClearKitchenObject();
        Destroy(gameObject);
    }
    
    public static KitchenObject SpawnKitchenObject(KitchenObjectSO kitchenObjectToSpawn, IKitchenObjectParent kitchenObjectParent)
    {
        Transform kitchenObjectTransform = Instantiate(kitchenObjectToSpawn.prefab);
        KitchenObject kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
        kitchenObject.SetKitchenObjectParent(kitchenObjectParent);
        return kitchenObject;
    }
}
