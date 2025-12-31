using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterVisual : MonoBehaviour
{
    [SerializeField] private StoveCounter _stoveCounter;
    [SerializeField] private GameObject _stoveOnViusal;
    [SerializeField] private GameObject _particleEffectVisual;

    void Start()
    {
        _stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
    }
    void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStateChangedEventArgs e)
    {
        bool showVisual = (e.state == StoveCounter.State.Frying || e.state == StoveCounter.State.Fried);
        _stoveOnViusal.SetActive(showVisual);
        _particleEffectVisual.SetActive(showVisual);
    }

}
