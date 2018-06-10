using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer2 : MonoBehaviour {
    public Text currentTime, recordTime2;
    public float time;


    // Use this for initialization
    void Start()
    {
        time = 0.0f;
        InvokeRepeating("TimeCount", 0f, 0.1f);
        // PlayerPrefs.SetFloat("recordTime2", time);

        if (PlayerPrefs.HasKey("recordTime2"))
            recordTime2.text = PlayerPrefs.GetFloat("recordTime2").ToString("F2") + "s";

    }

    public void TimeCount()
    {
        time += 0.1f;
        currentTime.text = time.ToString("F2") + "s";
    }

    public void CompareTimes()
    {
        CancelInvoke("TimeCount");
        if (PlayerPrefs.HasKey("recordTime2"))
        {
            if (time < PlayerPrefs.GetFloat("recordTime2") && PlayerPrefs.GetFloat("recordTime2") > 0.1)
            {
                recordTime2.text = time.ToString("F2") + "s";
                PlayerPrefs.SetFloat("recordTime2", time);
            }
        }
        //if (PlayerPrefs.GetFloat("recordTime2") < 0.1)
        else
        {
            PlayerPrefs.SetFloat("recordTime2", time);
            recordTime2.text = time.ToString("F2") + "s";
        }
    }
}
