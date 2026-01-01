using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCounterVisual : MonoBehaviour
{
    [SerializeField] private PlatesCounter _platesCounter;
    
    [SerializeField] private Transform _counterTopPoint;
    [SerializeField] private Transform _plateVisualPrefab;
    
    private List<GameObject> m_platesSpawned;

    void Awake()
    {
        m_platesSpawned = new List<GameObject>();
    }

    void Start()
    {
        _platesCounter.OnPlateSpawned += PlatesCounter_OnPlateSpawned;
        _platesCounter.OnPlatePickedUp += PlatesCounter_OnPlatePickedUp;
    }
    void PlatesCounter_OnPlatePickedUp(object sender, EventArgs e)
    {
        GameObject plate = m_platesSpawned[m_platesSpawned.Count - 1];
        m_platesSpawned.RemoveAt(m_platesSpawned.Count - 1);
        Destroy(plate);
    }
    void PlatesCounter_OnPlateSpawned(object sender, EventArgs e)
    {
        Transform plateTransform = Instantiate(_plateVisualPrefab, _counterTopPoint);
        
        float plateOffsetY = 0.1f;
        plateTransform.localPosition = new Vector3(0f, plateOffsetY * m_platesSpawned.Count, 0f);
        m_platesSpawned.Add(plateTransform.gameObject);
    }
}
