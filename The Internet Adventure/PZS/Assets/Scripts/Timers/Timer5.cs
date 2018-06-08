using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer5 : MonoBehaviour {


    public Text currentTime, recordTime5;
    public float time;


    // Use this for initialization
    void Start()
    {
        time = 0.0f;
        InvokeRepeating("TimeCount", 0f, 0.1f);
        // PlayerPrefs.SetFloat("recordTime5", time);

        if (PlayerPrefs.HasKey("recordTime5"))
            recordTime5.text = PlayerPrefs.GetFloat("recordTime5").ToString("F2") + "s";

    }

    public void TimeCount()
    {
        time += 0.1f;
        currentTime.text = time.ToString("F2") + "s";
    }

    public void CompareTimes()
    {
        CancelInvoke("TimeCount");
        if (PlayerPrefs.HasKey("recordTime5"))
        {
            if (time < PlayerPrefs.GetFloat("recordTime5") && PlayerPrefs.GetFloat("recordTime5") > 0.1)
            {
                recordTime5.text = time.ToString("F2") + "s";
                PlayerPrefs.SetFloat("recordTime5", time);
            }
        }
        //if (PlayerPrefs.GetFloat("recordTime5") < 0.1)
        else
        {
            PlayerPrefs.SetFloat("recordTime5", time);
            recordTime5.text = time.ToString("F2") + "s";
        }
    }
}
