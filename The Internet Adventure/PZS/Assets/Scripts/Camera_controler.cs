using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_controler : MonoBehaviour {

	// Use this for initialization
	void Start () {
        currentTime = 0.0f;
	}

    static HeroController hc=null;
    public static void setHeroController(HeroController hc)
    {
        Camera_controler.hc = hc;
    }

    const float speed = 1.5f;
    const float timeout = 1.0f;
    const float player_pivot = 0.0f;
    const float normal_speed_range = 2.0f;
    const float under_pivot_mult = 0.5f;
    const float over_pivot_mult = 2.0f;
    float currentTime;
    float extraSpeed;
	// Update is called once per frame
	void Update () {
        if (!hc.ifStarted()) return;
        currentTime += Time.deltaTime;
        if (currentTime < timeout) return;

        float diff = hc.transform.position.y-(transform.position.y + player_pivot);
        if (diff < -normal_speed_range)
        {
            extraSpeed = diff * under_pivot_mult;
        }
        else if (diff > normal_speed_range)
        {
            extraSpeed = diff * over_pivot_mult;
        }
        else
        {
            extraSpeed = 0;
        }
        float totalSpeed = speed +extraSpeed;
        if (totalSpeed < speed/2) totalSpeed = speed/2;
        transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * totalSpeed,transform.position.z);
	}
}
