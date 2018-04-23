using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour {

    public static bool paused = false;
    public string LevelName;
    public string newLevelName;
    public GameObject WinMenuUI;
    private string sceneName = "MainMenu";


	// Update is called once per frame
	/*void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}*/

    public void TryAgain()
    {
        WinMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Application.LoadLevel(LevelName);
    }


    public void Next()
    {
        WinMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Application.LoadLevel(newLevelName);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
