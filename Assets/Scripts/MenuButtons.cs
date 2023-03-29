using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
	[SerializeField]
	private string sceneName;

    RectTransform rectTransform;

    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void Play(){
		SceneManager.LoadScene(sceneName);
	}

    public void Quit()
    {
        Application.Quit();
    }

    private void OnMouseEnter()
    {
        rectTransform.localScale = new Vector3(
            rectTransform.localScale.x * 2, 
            rectTransform.localScale.y * 2, 
            rectTransform.localScale.z * 2);
    }

    private void OnMouseExit()
    {
        rectTransform.localScale = new Vector3(
        rectTransform.localScale.x / 2,
        rectTransform.localScale.y / 2,
        rectTransform.localScale.z / 2);
    }
}
