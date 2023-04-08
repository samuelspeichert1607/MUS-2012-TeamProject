using System.Collections;
using UnityEngine;

public class GenerateTears : MonoBehaviour
{
    [SerializeField]
    private GameObject tear;

    [SerializeField]
    [Range(0.1f, 5f)]
    private float cryFrequency;

    private CryingPO cryingPO;
    
    private void Start()
    {
        cryingPO = GetComponentInParent<CryingPO>();
        StartCoroutine(CryTear());
    }
    
    private IEnumerator CryTear()
    {
        while (true)
        {
            yield return new WaitForSeconds(cryFrequency);
            Instantiate(tear, gameObject.transform.position, gameObject.transform.rotation, null);
        }
    }
}
