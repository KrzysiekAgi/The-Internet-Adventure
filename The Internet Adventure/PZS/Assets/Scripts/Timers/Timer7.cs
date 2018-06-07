using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer7 : MonoBehaviour {

    public Text currentTime, recordTime7;
    public float time;


    // Use this for initialization
    void Start()
    {
        time = 0.0f;
        InvokeRepeating("TimeCount", 0f, 0.1f);
        // PlayerPrefs.SetFloat("recordTime7", time);

        if (PlayerPrefs.HasKey("recordTime7"))
            recordTime7.text = PlayerPrefs.GetFloat("recordTime7").ToString("F2") + "s";

    }

    public void TimeCount()
    {
        time += 0.1f;
        currentTime.text = time.ToString("F2") + "s";
    }

    public void CompareTimes()
    {
        CancelInvoke("TimeCount");
        if (PlayerPrefs.HasKey("recordTime7"))
        {
            if (time < PlayerPrefs.GetFloat("recordTime7") && PlayerPrefs.GetFloat("recordTime7") > 0.1)
            {
                recordTime7.text = time.ToString("F2") + "s";
                PlayerPrefs.SetFloat("recordTime7", time);
            }
        }
        //if (PlayerPrefs.GetFloat("recordTime7") < 0.1)
        else
        {
            PlayerPrefs.SetFloat("recordTime7", time);
            recordTime7.text = time.ToString("F2") + "s";
        }
    }
}
