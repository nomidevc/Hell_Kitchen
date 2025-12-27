using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] BaseCounter _baseCounter;
    [SerializeField] GameObject[] _visualGameObjectArray;
    void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }
    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if (e.selectedCounter == _baseCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }
    void Show()
    {
        foreach (GameObject _visualGameObject in _visualGameObjectArray)
        {
            _visualGameObject.SetActive(true);
        }
    }

    private void Hide()
    {
        foreach (var _visualGameObject in _visualGameObjectArray)
        {
            _visualGameObject.SetActive(false);
        }
    }
}
