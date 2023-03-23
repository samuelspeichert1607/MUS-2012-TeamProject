using UnityEngine;
using UnityEngine.SceneManagement;

public class WrapToLevel : MonoBehaviour
{
    [SerializeField]
    private string LevelToWrap;

    [SerializeField]
    private Vector3 positionToWrap;

    private GameObject globalObject; 

    private void Awake()
    {
        globalObject = GameObject.Find("GlobalObject");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player(Clone)")
        {
            collision.gameObject.transform.position = positionToWrap;
            SceneManager.LoadScene(LevelToWrap, LoadSceneMode.Single);
        }
    }
}