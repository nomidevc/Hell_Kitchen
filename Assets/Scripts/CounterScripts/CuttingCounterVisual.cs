using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounterVisual : MonoBehaviour
{
    private const string CUT = "Cut";
    
    [SerializeField] private CuttingCounter _cuttingCounter;
    
    private Animator m_animator;

    void Awake()
    {
        m_animator = GetComponent<Animator>();
    }

    void Start()
    {
        _cuttingCounter.OnCutting += CuttingCounter_OnCutting;
    }
    void CuttingCounter_OnCutting(object sender, EventArgs e)
    {
        m_animator.SetTrigger(CUT);
    }
}
