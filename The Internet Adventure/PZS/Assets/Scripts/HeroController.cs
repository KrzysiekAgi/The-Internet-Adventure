using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour {

    Animator anim;
    Rigidbody2D rbody;
    public float hspeed;
    public float jumpForce;
    public int jumpCounter { get; set; }
    private bool Jump;
    public  bool grounded { get; set; }


    // Use this for initialization
    void Start () {

        anim = GetComponent<Animator> ();
        rbody = GetComponent<Rigidbody2D>();
        Jump = false;

    }

    // Update is called once per frame
    void FixedUpdate() {

        float horizontalDir = Input.GetAxis("Horizontal");
        anim.SetFloat("horizontalDir", Mathf.Abs(horizontalDir));

        rbody.velocity = new Vector2(horizontalDir * hspeed, rbody.velocity.y);

        if (horizontalDir < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (horizontalDir > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }


        if(Jump)
        {
            anim.SetTrigger("jump");
            Jump = false;
            rbody.velocity = new Vector2(rbody.velocity.x, jumpForce);
            //rbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }


    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCounter < 2)
        {
            Jump = true;
            jumpCounter++;
        }

        

    }
    



}


