using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void HandlePlayButtonPress()
    {
        SceneManager.LoadScene("Game");
    }

    public void HandleQuitButtonPress()
    {
        Application.Quit();
    }
}
