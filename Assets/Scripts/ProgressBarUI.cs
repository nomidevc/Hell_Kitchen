using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private CuttingCounter _cuttingCounter;
    [SerializeField] private Image _progressBarImg;

    void Start()
    {
        _cuttingCounter.OnCuttingProgressChanged += CuttingCounter_OnCuttingProgressChanged;
        _progressBarImg.fillAmount = 0f;
        
        HideProgressBar();
    }
    void CuttingCounter_OnCuttingProgressChanged(object sender, CuttingCounter.OnCuttingProgressChangedEventArgs e)
    {
        _progressBarImg.fillAmount = e.cuttingProgressNormalized;
        
        if (e.cuttingProgressNormalized >= 1f || e.cuttingProgressNormalized <= 0f)
        {
            HideProgressBar();
        }
        else
        {
            ShowProgressBar();
        }
    }

    private void ShowProgressBar()
    {
        gameObject.SetActive(true);
    }
    
    private void HideProgressBar()
    {
        gameObject.SetActive(false);
    }
}
