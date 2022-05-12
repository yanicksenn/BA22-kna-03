using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenuController : MonoBehaviour
{
    [SerializeField] private Canvas canvas;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        HideMenu();
        
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start) || OVRInput.GetDown(OVRInput.Button.One))
            ShowMenu();
    }
    
    public void ExitScene()
    {
        SceneManager.LoadScene("Scenes/MainMenuScene");
    }

    public void ContinueScene()
    {
        HideMenu();
    }

    public void ReloadScene()
    {
        var currentScene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(currentScene.name);
    }

    public void ShowMenu()
    {
        canvas.enabled = true;
    }

    public void HideMenu()
    {
        canvas.enabled = false;
    }
}
