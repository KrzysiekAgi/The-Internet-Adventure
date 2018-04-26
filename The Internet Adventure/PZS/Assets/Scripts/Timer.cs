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
       // PlayerPrefs.SetFloat("recordTime", time);

        if (PlayerPrefs.HasKey("recordTime"))
            recordTime.text = PlayerPrefs.GetFloat("recordTime").ToString("F2") + "s";

    }

    public void TimeCount()
    {
        time += 0.1f;
        currentTime.text = time.ToString("F2") + "s";
    }

    public void CompareTimes()
    {
        CancelInvoke("TimeCount");
        if (PlayerPrefs.HasKey("recordTime"))
        {
            if (time < PlayerPrefs.GetFloat("recordTime"))
            {
                recordTime.text = time.ToString("F2") + "s";
                PlayerPrefs.SetFloat("recordTime", time);
            }
        }
        if (PlayerPrefs.GetFloat("recordTime") < 0.1)
        {
            PlayerPrefs.SetFloat("recordTime", time);
            recordTime.text = time.ToString("F2") + "s";
        }
    }

}
