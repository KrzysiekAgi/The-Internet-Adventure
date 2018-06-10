using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer6 : MonoBehaviour {


    public Text currentTime, recordTime6;
    public float time;


    // Use this for initialization
    void Start()
    {
        time = 0.0f;
        InvokeRepeating("TimeCount", 0f, 0.1f);
        // PlayerPrefs.SetFloat("recordTime6", time);

        if (PlayerPrefs.HasKey("recordTime6"))
            recordTime6.text = PlayerPrefs.GetFloat("recordTime6").ToString("F2") + "s";

    }

    public void TimeCount()
    {
        time += 0.1f;
        currentTime.text = time.ToString("F2") + "s";
    }

    public void CompareTimes()
    {
        CancelInvoke("TimeCount");
        if (PlayerPrefs.HasKey("recordTime6"))
        {
            if (time < PlayerPrefs.GetFloat("recordTime6") && PlayerPrefs.GetFloat("recordTime6") > 0.1)
            {
                recordTime6.text = time.ToString("F2") + "s";
                PlayerPrefs.SetFloat("recordTime6", time);
            }
        }
        //if (PlayerPrefs.GetFloat("recordTime6") < 0.1)
        else
        {
            PlayerPrefs.SetFloat("recordTime6", time);
            recordTime6.text = time.ToString("F2") + "s";
        }
    }
}
