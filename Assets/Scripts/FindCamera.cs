using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCamera : MonoBehaviour
{
    private Camera camera;
    
    [SerializeField]
    private GameObject dialogBox;

    private void Start()
    {
        camera = GetComponent<Canvas>().worldCamera;
    }
    
    private void Update()
    {
        while (camera == null)
        {
            camera = GameObject.Find("PlayerCam").GetComponent<Camera>();
        }
    }
}
