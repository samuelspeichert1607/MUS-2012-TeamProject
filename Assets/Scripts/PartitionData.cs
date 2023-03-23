using UnityEngine;

public class PartitionData : MonoBehaviour
{
    public bool HasBeenTaken = false;
    public Vector3 positionExpected;
    
    private void Start()
    {
        positionExpected = transform.position;
    }

    private void Update()
    {
        
    }
}
