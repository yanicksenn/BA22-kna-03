using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void LoadMainScene()
    {
        SceneManager.LoadScene("Scenes/MainScene");
    }
    
    public void LoadSandboxScene()
    {
        SceneManager.LoadScene("Scenes/SandboxScene");
    }

    public void LoadTutorialScene()
    {
        SceneManager.LoadScene("Scenes/TutorialScene");
    }
}
