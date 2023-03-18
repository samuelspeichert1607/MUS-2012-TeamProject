using Cinemachine;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;
    private CinemachineFreeLook cinemachineFreeLook;

    public float rotationSpeed;

    private void Awake()
    {
        cinemachineFreeLook = GetComponent<CinemachineFreeLook>();

        if (player == null)
        {
            player = GameObject.Find("Player(Clone)").transform;

            if (orientation == null)
            {
                orientation = GameObject.Find("Orientation").transform;
            }

            if (rb == null)
            {
                rb = player.GetComponent<Rigidbody>();
            }

            if(cinemachineFreeLook.Follow == null)
            {
                cinemachineFreeLook.Follow = player;
            }

            if (cinemachineFreeLook.LookAt == null)
            {
                cinemachineFreeLook.LookAt = player;
            }

            if (playerObj == null)
            {
                playerObj = GameObject.Find("PlayerObj").transform;
            }
        }
        
    }


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // rotate orientation
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        // roate player object
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (inputDir != Vector3.zero)
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);

    }
}
