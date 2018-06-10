using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer11 : MonoBehaviour {

    public Text currentTime, recordTime11;
    public float time;


    // Use this for initialization
    void Start()
    {
        time = 0.0f;
        InvokeRepeating("TimeCount", 0f, 0.1f);
        // PlayerPrefs.SetFloat("recordTime11", time);

        if (PlayerPrefs.HasKey("recordTime11"))
            recordTime11.text = PlayerPrefs.GetFloat("recordTime11").ToString("F2") + "s";

    }

    public void TimeCount()
    {
        time += 0.1f;
        currentTime.text = time.ToString("F2") + "s";
    }

    public void CompareTimes()
    {
        CancelInvoke("TimeCount");
        if (PlayerPrefs.HasKey("recordTime11"))
        {
            if (time < PlayerPrefs.GetFloat("recordTime11") && PlayerPrefs.GetFloat("recordTime11") > 0.1)
            {
                recordTime11.text = time.ToString("F2") + "s";
                PlayerPrefs.SetFloat("recordTime11", time);
            }
        }
        //if (PlayerPrefs.GetFloat("recordTime11") < 0.1)
        else
        {
            PlayerPrefs.SetFloat("recordTime11", time);
            recordTime11.text = time.ToString("F2") + "s";
        }
    }
}
