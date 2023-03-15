using UnityEngine;
using UnityEngine.UI;

public class PartitionCounter : MonoBehaviour
{
    private Text text;
    private int partitions;

    private void Start()
    {
        text = GetComponent<Text>();
        partitions = 0;
        text.text = "Partitions : " + partitions.ToString();
    }

    public void AddPartition()
    {
        partitions++;
        text.text = "Partitions : " + partitions.ToString();
    }

    public void RemovePartition()
    {
        partitions--;
        text.text = "Partitions : " + partitions.ToString();
    }
}
