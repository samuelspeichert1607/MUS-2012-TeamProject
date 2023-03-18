using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
	[SerializeField]
	private string sceneName;
	
    public void Play(){
		SceneManager.LoadScene(sceneName);
	}

    public void Quit()
    {
        Application.Quit();
    }
}
