using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour {

    Animator anim;
    Rigidbody2D rbody;
    public float hspeed;
    public float jumpForce;

    // Use this for initialization
    void Start () {

        anim = GetComponent<Animator> ();
        rbody = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        float horizontalDir = Input.GetAxis ("Horizontal");
        anim.SetFloat("horizontalDir", Mathf.Abs( horizontalDir));

        rbody.velocity = new Vector2(horizontalDir * hspeed, rbody.velocity.y);

        if (horizontalDir < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if(horizontalDir > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("jump");
            rbody.AddForce(new Vector2(0f, jumpForce));
        }

	}
}
