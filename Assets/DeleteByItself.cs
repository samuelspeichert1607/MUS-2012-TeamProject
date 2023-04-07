using System.Collections;
using UnityEngine;

public class DeleteByItself : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Delete());
    }

    private IEnumerator Delete()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            Destroy(gameObject);
        }
    }
}
