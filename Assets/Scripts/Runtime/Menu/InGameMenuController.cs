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
        if (ShouldToggleMenu())
            ToggleMenu();
    }

    private static bool ShouldToggleMenu()
    {
        return OVRInput.GetDown(OVRInput.Button.Start) || OVRInput.GetDown(OVRInput.Button.One);
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

    private void ToggleMenu()
    {
        if (canvas.enabled)
        {
            HideMenu();
        } 
        else
        {
            ShowMenu();
        }
    }

    private void ShowMenu()
    {
        canvas.enabled = true;
    }

    private void HideMenu()
    {
        canvas.enabled = false;
    }
}
