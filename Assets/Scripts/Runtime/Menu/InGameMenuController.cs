using System;
using System.Collections;
using System.Collections.Generic;
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
        if (OVRInput.GetDown(OVRInput.Button.Start))
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

    public void ShowMenu()
    {
        canvas.enabled = true;
    }

    public void HideMenu()
    {
        canvas.enabled = false;
    }
}
