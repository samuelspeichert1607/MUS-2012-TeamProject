using UnityEngine;

public class HittedByPlayer : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        { // vérifier si velocité est en chute OU voir tutoriel en ligne.
            if(gameObject.transform.position.y  < collision.gameObject.transform.position.y)
            {
                Destroy(gameObject);
            }
        }
    }
}
