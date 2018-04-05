using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text currentTime, recordTime;
    public float time;


	// Use this for initialization
	void Start () {
        time = 0.0f;
        InvokeRepeating("TimeCount", 0f , 0.1f );

        if (PlayerPrefs.HasKey("recordTime"))
             recordTime.text = PlayerPrefs.GetFloat("recordTime") + "s";

    }

    public void TimeCount()
    {
        time += 0.1f;
        currentTime.text = time.ToString("F2") + "s";
    }

    public void CompareTimes()
    {
        if (PlayerPrefs.HasKey("recordTime"))
        {
            CancelInvoke("TimeCount");
            if (time < PlayerPrefs.GetFloat("recordTime"))
            {
                PlayerPrefs.SetFloat("recordTime", time);
            }
        }
        else
        {
            PlayerPrefs.SetFloat("recordTime", time);
        }
    }

}
