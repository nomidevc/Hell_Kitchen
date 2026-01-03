using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _footstepVolume = 0.5f;
    
    private float m_timeSinceLastFootstep;
    private float m_footstepTimerMax = 0.2f;

    void Start()
    {
        _player = GetComponent<Player>();
    }

    void Update()
    {
        m_timeSinceLastFootstep -= Time.deltaTime;
        if (m_timeSinceLastFootstep <= 0)
        {
            m_timeSinceLastFootstep = m_footstepTimerMax;
            if (_player.IsWalking())
            {
                SoundManager.Instance.PlayFootstepSound(_player.transform.position, _footstepVolume);
            }
        }
    }
}
