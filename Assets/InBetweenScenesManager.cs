using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InBetweenScenesManager : MonoBehaviour
{
    [SerializeField]
    private Vector3 startPositionEntreeSHG = new Vector3();
    [SerializeField]
    private Vector3 startPositionEntreeDesert = new Vector3();
    [SerializeField]
    private Vector3 startPositionSortieDesert = new Vector3();

    private void Awake()
    {
        Debug.Log("Entrance into new Scene Awake");
    }

    private void Start()
    {
        Debug.Log("Entrance into new Scene Start");
    }

    private void Update()
    {
        
    }
}
