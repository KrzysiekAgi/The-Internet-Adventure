using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer8 : MonoBehaviour {

    public Text currentTime, recordTime8;
    public float time;


    // Use this for initialization
    void Start()
    {
        time = 0.0f;
        InvokeRepeating("TimeCount", 0f, 0.1f);
        // PlayerPrefs.SetFloat("recordTime8", time);

        if (PlayerPrefs.HasKey("recordTime8"))
            recordTime8.text = PlayerPrefs.GetFloat("recordTime8").ToString("F2") + "s";

    }

    public void TimeCount()
    {
        time += 0.1f;
        currentTime.text = time.ToString("F2") + "s";
    }

    public void CompareTimes()
    {
        CancelInvoke("TimeCount");
        if (PlayerPrefs.HasKey("recordTime8"))
        {
            if (time < PlayerPrefs.GetFloat("recordTime8") && PlayerPrefs.GetFloat("recordTime8") > 0.1)
            {
                recordTime8.text = time.ToString("F2") + "s";
                PlayerPrefs.SetFloat("recordTime8", time);
            }
        }
        //if (PlayerPrefs.GetFloat("recordTime8") < 0.1)
        else
        {
            PlayerPrefs.SetFloat("recordTime8", time);
            recordTime8.text = time.ToString("F2") + "s";
        }
    }
}
