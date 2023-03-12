using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WrapToLevel : MonoBehaviour
{
    [SerializeField]
    private string LevelToWrap;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene(LevelToWrap, LoadSceneMode.Additive);
            Destroy(collision.gameObject);
        }
    }
}
