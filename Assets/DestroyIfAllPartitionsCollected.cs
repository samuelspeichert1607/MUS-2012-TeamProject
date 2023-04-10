using UnityEngine;

public class DestroyIfAllPartitionsCollected : MonoBehaviour
{
    private GameObject globalObject;

    void Update()
    {
        if(globalObject == null)
        {
            globalObject = GameObject.Find("GlobalObject");
        }
        else
        {
            Inventory inventory = globalObject.GetComponent<Inventory>();

            if(inventory.Items.Count >= 5)
            {
                Destroy(gameObject);
            }
        }
    }
}
