using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void LoadMainScene()
    {
        SceneManager.LoadScene("Scenes/MainScene");
    }

    public void LoadTutorialScene()
    {
        SceneManager.LoadScene("Scenes/TutorialScene");
    }
}
