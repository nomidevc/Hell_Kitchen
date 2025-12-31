using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private GameObject _hasProgressGameObject;
    [SerializeField] private Image _progressBarImg;

    private IHasProgress m_hasProgress;
    
    void Start()
    {
        m_hasProgress = _hasProgressGameObject.GetComponent<IHasProgress>();
        if (m_hasProgress == null)
        {
            Debug.LogError("No IHasProgress found");
        }
        
        m_hasProgress.OnProgressChanged += HasProgressOnProgressChanged;
        _progressBarImg.fillAmount = 0f;
        
        HideProgressBar();
    }
    void HasProgressOnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
    {
        _progressBarImg.fillAmount = e.progressNormalized;
        
        if (e.progressNormalized >= 1f || e.progressNormalized <= 0f)
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
