using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
	[SerializeField]
	private string sceneName;

    private RectTransform rectTransform;


    [SerializeField]
    private GameObject mainCanvas;

    [SerializeField]
    private GameObject controlsCanvas;

    [SerializeField]
    private GameObject creditsCanvas;

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

    public void Controls()
    {
        controlsCanvas.SetActive(true);
        mainCanvas.SetActive(false);
    }

    public void Credits()
    {
        creditsCanvas.SetActive(true);
        mainCanvas.SetActive(false);
    }

    public void Back()
    {
        mainCanvas.SetActive(true);
        controlsCanvas.SetActive(false);
        creditsCanvas.SetActive(false);
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
