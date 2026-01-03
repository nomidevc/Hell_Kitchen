using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("[SoundManager] More than one instance of SoundManager found!");
        }
        Instance = this;
    }

    [SerializeField] private AudioClipRefSO _audioClipRefSo;
    
    void Start()
    {
        DeliveryManager.Instance.OnDeliverySuccess += DeliveryManager_OnDeliverySuccess;
        DeliveryManager.Instance.OnDeliveryFailed += DeliveryManager_OnDeliveryFailed;
        
        CuttingCounter.OnAnyCut += CuttingCounter_OnAnyCut;
        
        Player.Instance.OnPickedSomething += Player_OnPickedSomething;
        
        BaseCounter.OnPlacedSomethingOnCounter += BaseCounter_OnPlacedSomethingOnCounter;
        
        TrashCounter.OnAnyObjectTrashed += TrashCounter_OnAnyTrashedSomething;
    }
    private void TrashCounter_OnAnyTrashedSomething(object sender, EventArgs e)
    {
        TrashCounter trashCounter = sender as TrashCounter;
        PlaySoundEffect(_audioClipRefSo.AudioTrash, trashCounter.transform.position);
    }
    private void BaseCounter_OnPlacedSomethingOnCounter(object sender, EventArgs e)
    {
        BaseCounter baseCounter = sender as BaseCounter;
        PlaySoundEffect(_audioClipRefSo.AudioObjectDrop, baseCounter.transform.position);
    }
    private void Player_OnPickedSomething(object sender, EventArgs e)
    {
        Player player = sender as Player;
        PlaySoundEffect(_audioClipRefSo.AudioObjectPickup, player.transform.position);
    }
    private void CuttingCounter_OnAnyCut(object sender, EventArgs e)
    {
        CuttingCounter cuttingCounter = sender as CuttingCounter;
        PlaySoundEffect(_audioClipRefSo.AudioChop, cuttingCounter.transform.position);
    }
    private void DeliveryManager_OnDeliveryFailed(object sender, EventArgs e)
    {
        DeliveryCounter deliveryCounter = DeliveryCounter.Instance;
        PlaySoundEffect(_audioClipRefSo.AudioDeliveryFail, deliveryCounter.transform.position);
    }
    private void DeliveryManager_OnDeliverySuccess(object sender, EventArgs e)
    {
        DeliveryCounter deliveryCounter = DeliveryCounter.Instance;
        PlaySoundEffect(_audioClipRefSo.AudioDeliverySuccess, deliveryCounter.transform.position);
    }

    private void PlaySoundEffect(AudioClip[] audioClipArray,Vector3 position, float volume = 1f)
    {
        PlaySoundEffect(audioClipArray[UnityEngine.Random.Range(0, audioClipArray.Length)], position, volume);
    }
    
    private void PlaySoundEffect(AudioClip audioClip, Vector3 position, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volume);
    }
    
    public void PlayFootstepSound(Vector3 position, float volume)
    {
        PlaySoundEffect(_audioClipRefSo.AudioFootstep, position, volume);
    }
}
