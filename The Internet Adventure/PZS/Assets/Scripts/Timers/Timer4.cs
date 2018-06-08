using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer4 : MonoBehaviour {


    public Text currentTime, recordTime4;
    public float time;


    // Use this for initialization
    void Start()
    {
        time = 0.0f;
        InvokeRepeating("TimeCount", 0f, 0.1f);
        // PlayerPrefs.SetFloat("recordTime4", time);

        if (PlayerPrefs.HasKey("recordTime4"))
            recordTime4.text = PlayerPrefs.GetFloat("recordTime4").ToString("F2") + "s";

    }

    public void TimeCount()
    {
        time += 0.1f;
        currentTime.text = time.ToString("F2") + "s";
    }

    public void CompareTimes()
    {
        CancelInvoke("TimeCount");
        if (PlayerPrefs.HasKey("recordTime4"))
        {
            if (time < PlayerPrefs.GetFloat("recordTime4") && PlayerPrefs.GetFloat("recordTime4") > 0.1)
            {
                recordTime4.text = time.ToString("F2") + "s";
                PlayerPrefs.SetFloat("recordTime4", time);
            }
        }
        //if (PlayerPrefs.GetFloat("recordTime4") < 0.1)
        else
        {
            PlayerPrefs.SetFloat("recordTime4", time);
            recordTime4.text = time.ToString("F2") + "s";
        }
    }
}
