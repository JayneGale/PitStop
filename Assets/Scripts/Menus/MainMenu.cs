using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    int _thisSceneBuildIndex;
    AudioSource source;

    private void Start()
    {
        _thisSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        source = GetComponent<AudioSource>();
        source.Play();      
    }

    public void PlayGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        source.Stop();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(_thisSceneBuildIndex + 1);
        //WinTrigger.isWin = false;
    }

    public void ReallyQuit()
    {
        Application.Quit();
    }

}
