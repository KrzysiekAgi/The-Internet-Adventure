using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour {

	public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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

}
