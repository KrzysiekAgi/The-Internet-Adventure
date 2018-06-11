using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour {

    public bool isMute = false;

    public void Mute()
    {
        isMute = !isMute;
        AudioListener.volume = isMute ? 0 : 1;
        if (isMute) GameObject.Find("mute").transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText("music");
        else GameObject.Find("mute").transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText("mute");
    }

    public void PlayGame()
    {
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("quit\n");
        Application.Quit(); //this one works only in release
    }

    public void Ranking()
    {
        string[,] ranking = new string[10, 10];
        ranking = GameObject.Find("_mysql").GetComponent<DatabaseHandler>().ViewRanking();
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
        
            for(int j = 1;j<10;j++)
            {
               // Debug.Log(i+" "+j+" "+ranking[j, i]);
                GameObject.Find("ID").transform.GetChild(j).GetComponent<TextMeshProUGUI>().SetText(ranking[j-1,0]);
                GameObject.Find("SEX").transform.GetChild(j).GetComponent<TextMeshProUGUI>().SetText(ranking[j-1, 2]);
                GameObject.Find("NICK").transform.GetChild(j).GetComponent<TextMeshProUGUI>().SetText(ranking[j-1, 1]);
                GameObject.Find("LEVEL").transform.GetChild(j).GetComponent<TextMeshProUGUI>().SetText(ranking[j-1, 3]);
                GameObject.Find("SCORE").transform.GetChild(j).GetComponent<TextMeshProUGUI>().SetText(ranking[j-1, 4]);
                GameObject.Find("TIME").transform.GetChild(j).GetComponent<TextMeshProUGUI>().SetText(ranking[j-1, 5]);
                GameObject.Find("MONEY").transform.GetChild(j).GetComponent<TextMeshProUGUI>().SetText(ranking[j-1, 6]);
                GameObject.Find("MEMES").transform.GetChild(j).GetComponent<TextMeshProUGUI>().SetText(ranking[j-1, 7]);
            }
        
    }

    public void BackRanking()
    {
        transform.GetChild(2).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
    }

    public void BackPlay()
    {
        transform.GetChild(2).gameObject.SetActive(true);
        transform.GetChild(3).gameObject.SetActive(false);
    }

    public void PlayEndless()
    {
        SceneManager.LoadScene("LevelChallenge");
    }

    public void PlayLevel()
    {
        int lvl;
        try
        {
            lvl = Int32.Parse(GameObject.Find("SelectLevel").GetComponent<TMP_InputField>().text);
            if (lvl > 0 && lvl < 13) SceneManager.LoadScene("level" + lvl);
            else GameObject.Find("SelectLevel").GetComponent<TMP_InputField>().text = "Wrong number";
        } catch(FormatException)
        {
            GameObject.Find("SelectLevel").GetComponent<TMP_InputField>().text = "Only number!";
        }

    }

}
