using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InBetweenScenesManager : MonoBehaviour
{
    private bool spawnOnce = false;


    [SerializeField]
    private Vector3 startPositionEntreeSHG = new Vector3();

    public Vector3 startPositionEntreeDesert = new Vector3();
    [SerializeField]
    private Vector3 startPositionSortieDesert = new Vector3();


    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject canvas;

    [SerializeField]
    private GameObject CMFreeLook1;

    [SerializeField]
    private GameObject CameraHolder;


    private void Awake()
    {
        Debug.Log("Entrance into new Scene Awake");

        if (!spawnOnce)
        {
            Instantiate(player);
            Instantiate(CMFreeLook1);
            Instantiate(CameraHolder);
            Instantiate(canvas);
            spawnOnce = true;
        }
    }

    private void Start()
    {
        Debug.Log("Entrance into new Scene Start");
    }
    


}
