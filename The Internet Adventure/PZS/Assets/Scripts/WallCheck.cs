using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour {

    Rigidbody2D rBody;

    private void Start()
    {
        rBody = transform.parent.GetComponent<Rigidbody2D>();

    }




    private void OnTriggerStay2D(Collider2D collision)
    {
        if (rBody.GetComponent<HeroController>().canStick == true && collision.tag == "Platform")
        {
            rBody.velocity = new Vector2(0F, 0F);
            rBody.GetComponent<HeroController>().jumpCounter = 0;
        }
    }
}
