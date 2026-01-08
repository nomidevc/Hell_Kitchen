using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayingClockUI : MonoBehaviour
{
    [SerializeField] private Image m_clockImage;
    
    void Update()
    {
        float normalizedTime = GameManager.Instance.GetGamePlayingTimerNormalized();
        m_clockImage.fillAmount = normalizedTime;
    }
}
