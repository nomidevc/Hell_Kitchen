using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public event EventHandler OnStateChanged;
    public event EventHandler OnGamePaused;
    public event EventHandler OnGameUnpaused;
    private enum State
    {
        WaitingToStart,
        CountdownToStart,
        GamePlaying,
        GameOver,
    }
    
    private State m_state;
    private float m_waitingToStartTimer = 1f;
    private float m_countdownToStartTimer = 3f;
    private float m_startToGameOverTimer;
    private float m_startToGameOverTimerMax = 20f;
    private bool m_isGamePaused = false;
    
    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("[GameManager] More than one instance of GameManager found!");
        }
        Instance = this;
        m_state = State.WaitingToStart;
    }

    void Start()
    {
        GameInput.Instance.OnPauseAction += GameInput_OnPauseAction;
    }
    void GameInput_OnPauseAction(object sender, EventArgs e)
    {
        OnPauseOrUnpauseGame();
    }

    void Update()
    {
        switch (m_state)
        {
            case State.WaitingToStart:
                m_waitingToStartTimer -= Time.deltaTime;
                if(m_waitingToStartTimer < 0f)
                {
                    m_state = State.CountdownToStart;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.CountdownToStart:
                m_countdownToStartTimer -= Time.deltaTime;
                if(m_countdownToStartTimer < 0f)
                {
                    m_state = State.GamePlaying;
                    m_startToGameOverTimer = m_startToGameOverTimerMax;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GamePlaying:
                m_startToGameOverTimer -= Time.deltaTime;
                if(m_startToGameOverTimer < 0f)
                {
                    m_state = State.GameOver;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GameOver:
                break;
        }
        Debug.Log(m_state);
    }
    
    public bool IsGamePlaying()
    {
        return m_state == State.GamePlaying;
    }
    
    public bool IsCountdownToStartActive()
    {
        return m_state == State.CountdownToStart;
    }

    public bool IsGameOverActive()
    {
        return m_state == State.GameOver;
    }
    
    public float GetCountdownToStartTimer()
    {
        return m_countdownToStartTimer;
    }
    
    public float GetGamePlayingTimerNormalized()
    {
        return (m_startToGameOverTimer / m_startToGameOverTimerMax);
    }
    
    public void OnPauseOrUnpauseGame()
    {
        m_isGamePaused = !m_isGamePaused;
        if (m_isGamePaused)
        {
            Time.timeScale = 0f;
            OnGamePaused?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            Time.timeScale = 1f;
            OnGameUnpaused?.Invoke(this, EventArgs.Empty);
        }
    }
}
