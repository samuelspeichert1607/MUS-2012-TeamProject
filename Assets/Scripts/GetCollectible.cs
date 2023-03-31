using UnityEngine;

public class GetCollectible : MonoBehaviour
{
    private GameObject ui;
    private GameObject globalObject;

    [SerializeField]
    private string itemName;
    private ItemDatabase database;
    private CollectibleItemSet collectibleItemSet;
    private UniqueID uniqueID;

    private void Start()
    {
        ui = GameObject.Find("PartitionsRamasseesText");
        globalObject = GameObject.Find("GlobalObject");

        uniqueID = GetComponent<UniqueID>();
        database = FindObjectOfType<ItemDatabase>();
        collectibleItemSet = FindObjectOfType<CollectibleItemSet>();
        if (collectibleItemSet.CollectedItems.Contains(uniqueID.ID))
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Debug.Log("Doublon potentiel de " + uniqueID.ID );
        }

    }

    private void Update()
    {
        if (ui == null)
        {
            ui = GameObject.Find("PartitionsRamasseesText");
        }

        transform.Rotate(Vector3.right * 50 * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ui.GetComponentInChildren<PartitionCounter>().AddPartition();
            ui.GetComponent<AudioSource>().Play();
            collectibleItemSet.CollectedItems.Add(uniqueID.ID);
            globalObject.GetComponentInParent<Inventory>().AddItem(itemName);
            gameObject.SetActive(false);
        }
    }
}
