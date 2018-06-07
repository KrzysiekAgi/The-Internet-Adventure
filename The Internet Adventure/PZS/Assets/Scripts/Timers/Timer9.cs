using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer9 : MonoBehaviour {

    public Text currentTime, recordTime9;
    public float time;


    // Use this for initialization
    void Start()
    {
        time = 0.0f;
        InvokeRepeating("TimeCount", 0f, 0.1f);
        // PlayerPrefs.SetFloat("recordTime9", time);

        if (PlayerPrefs.HasKey("recordTime9"))
            recordTime9.text = PlayerPrefs.GetFloat("recordTime9").ToString("F2") + "s";

    }

    public void TimeCount()
    {
        time += 0.1f;
        currentTime.text = time.ToString("F2") + "s";
    }

    public void CompareTimes()
    {
        CancelInvoke("TimeCount");
        if (PlayerPrefs.HasKey("recordTime9"))
        {
            if (time < PlayerPrefs.GetFloat("recordTime9") && PlayerPrefs.GetFloat("recordTime9") > 0.1)
            {
                recordTime9.text = time.ToString("F2") + "s";
                PlayerPrefs.SetFloat("recordTime9", time);
            }
        }
        //if (PlayerPrefs.GetFloat("recordTime9") < 0.1)
        else
        {
            PlayerPrefs.SetFloat("recordTime9", time);
            recordTime9.text = time.ToString("F2") + "s";
        }
    }
}
