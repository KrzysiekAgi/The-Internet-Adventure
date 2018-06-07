using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer10 : MonoBehaviour {

    public Text currentTime, recordTime10;
    public float time;


    // Use this for initialization
    void Start()
    {
        time = 0.0f;
        InvokeRepeating("TimeCount", 0f, 0.1f);
        // PlayerPrefs.SetFloat("recordTime10", time);

        if (PlayerPrefs.HasKey("recordTime10"))
            recordTime10.text = PlayerPrefs.GetFloat("recordTime10").ToString("F2") + "s";

    }

    public void TimeCount()
    {
        time += 0.1f;
        currentTime.text = time.ToString("F2") + "s";
    }

    public void CompareTimes()
    {
        CancelInvoke("TimeCount");
        if (PlayerPrefs.HasKey("recordTime10"))
        {
            if (time < PlayerPrefs.GetFloat("recordTime10") && PlayerPrefs.GetFloat("recordTime10") > 0.1)
            {
                recordTime10.text = time.ToString("F2") + "s";
                PlayerPrefs.SetFloat("recordTime10", time);
            }
        }
        //if (PlayerPrefs.GetFloat("recordTime10") < 0.1)
        else
        {
            PlayerPrefs.SetFloat("recordTime10", time);
            recordTime10.text = time.ToString("F2") + "s";
        }
    }
}
