using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{

    public string newLevelName;
    private GameObject WinMenu;
    private GameObject CanvasWin;
    public GameObject Player;
    public AudioClip clip;

    void Start()
    {

        CanvasWin = GameObject.Find("CanvasWin");
        if (CanvasWin != null)
        {
            WinMenu = CanvasWin.transform.GetChild(0).gameObject;
        }
    }
    void OnTriggerEnter2D()
    {

        Player.SendMessage("CompareTimes");
        AudioSource.PlayClipAtPoint(clip, transform.position);
        WinMenu.SetActive(true);
        Time.timeScale = 0f; //freeze

        // Application.LoadLevel (newLevelName);

    }


}
