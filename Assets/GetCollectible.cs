using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCollectible : MonoBehaviour
{
    private GameObject ui;

    private void Awake()
    {
        ui = GameObject.Find("PartitionsRamasseesText");
    }

    private void Update()
    {
        transform.Rotate(Vector3.right * 50 * Time.deltaTime, Space.World);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            ui.GetComponent<PartitionCounter>().AddPartition();
            ui.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
    }
}
