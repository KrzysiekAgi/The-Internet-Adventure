using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer3 : MonoBehaviour {

    public Text currentTime, recordTime3;
    public float time;


    // Use this for initialization
    void Start()
    {
        time = 0.0f;
        InvokeRepeating("TimeCount", 0f, 0.1f);
        // PlayerPrefs.SetFloat("recordTime3", time);

        if (PlayerPrefs.HasKey("recordTime3"))
            recordTime3.text = PlayerPrefs.GetFloat("recordTime3").ToString("F2") + "s";

    }

    public void TimeCount()
    {
        time += 0.1f;
        currentTime.text = time.ToString("F2") + "s";
    }

    public void CompareTimes()
    {
        CancelInvoke("TimeCount");
        if (PlayerPrefs.HasKey("recordTime3"))
        {
            if (time < PlayerPrefs.GetFloat("recordTime3") && PlayerPrefs.GetFloat("recordTime3") > 0.1)
            {
                recordTime3.text = time.ToString("F2") + "s";
                PlayerPrefs.SetFloat("recordTime3", time);
            }
        }
        //if (PlayerPrefs.GetFloat("recordTime3") < 0.1)
        else
        {
            PlayerPrefs.SetFloat("recordTime3", time);
            recordTime3.text = time.ToString("F2") + "s";
        }
    }
}

