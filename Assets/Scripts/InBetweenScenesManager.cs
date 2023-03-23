using UnityEngine;

public class InBetweenScenesManager : MonoBehaviour
{
    public static GameObject Instance { get; private set; }

    private static bool spawnOnce = false;
    
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject canvas;

    [SerializeField]
    private GameObject CMFreeLook;

    [SerializeField]
    private GameObject CameraHolder;
    
    [SerializeField]
    private GameObject ItemDatabase;

    private void Awake()
    {
        Debug.Log("Entrance into new Scene Awake");

        if (!spawnOnce)
        {
            Instantiate(player);
            Instantiate(canvas);
            Instantiate(CMFreeLook);
            Instantiate(CameraHolder);
            Instantiate(ItemDatabase);
            spawnOnce = true;
        }

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = gameObject;
        }
    }

    private void Start()
    {
        Debug.Log("Entrance into new Scene Start");
    }
    


}
