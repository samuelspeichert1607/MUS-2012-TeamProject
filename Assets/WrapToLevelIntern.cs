using UnityEngine;

public class WrapToLevelIntern : MonoBehaviour
{
    [SerializeField]
    private Vector3 positionToWrap;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player(Clone)")
        {
            collision.gameObject.transform.position = positionToWrap;
        }
    }
}
