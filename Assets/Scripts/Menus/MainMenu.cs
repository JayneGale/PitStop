using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    int _thisSceneBuildIndex;

    private void Start()
    {
        _thisSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void PlayGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(_thisSceneBuildIndex + 1);
        //WinTrigger.isWin = false;
    }

    public void ReallyQuit()
    {
        Application.Quit();
    }

}
