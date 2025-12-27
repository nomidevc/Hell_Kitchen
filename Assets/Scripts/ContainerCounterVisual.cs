using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounterVisual : MonoBehaviour
{
    private const string OPEN_CLOSE = "OpenClose";
    
    [SerializeField] private ContainerCounter _containerCounter;
    
    private Animator m_animator;

    void Awake()
    {
        m_animator = GetComponent<Animator>();
    }

    void Start()
    {
        _containerCounter.OnPlayerInteractEvent += ContainerCounter_OnPlayerInteractEvent;
    }
    void ContainerCounter_OnPlayerInteractEvent(object sender, EventArgs e)
    {
        m_animator.SetTrigger(OPEN_CLOSE);
    }
}
