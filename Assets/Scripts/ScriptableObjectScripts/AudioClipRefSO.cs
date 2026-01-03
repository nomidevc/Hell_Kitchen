using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AudioClipRefSO : ScriptableObject
{
    [SerializeField] private AudioClip[] _audioChop;
    public  AudioClip[] AudioChop => _audioChop;
    
    [SerializeField] private AudioClip[] _audioDeliverySuccess;
    public  AudioClip[] AudioDeliverySuccess => _audioDeliverySuccess;
    
    [SerializeField] private AudioClip[] _audioDeliveryFail;
    public  AudioClip[] AudioDeliveryFail => _audioDeliveryFail;
    
    [SerializeField] private AudioClip[] _audioFootstep;
    public  AudioClip[] AudioFootstep => _audioFootstep;
    
    [SerializeField] private AudioClip[] _audioObjectDrop;
    public  AudioClip[] AudioObjectDrop => _audioObjectDrop;
    
    [SerializeField] private AudioClip[] _audioObjectPickup;
    public  AudioClip[] AudioObjectPickup => _audioObjectPickup;
    
    [SerializeField] private AudioClip[] _audioTrash;
    public  AudioClip[] AudioTrash => _audioTrash;
    
    [SerializeField] private AudioClip[] _audioCountdownWarning;
    public  AudioClip[] AudioCountdownWarning => _audioCountdownWarning;
    
    [SerializeField] private AudioClip[] _audioStoveSizzle;
    public  AudioClip[] AudioStoveSizzle => _audioStoveSizzle;
    
}
