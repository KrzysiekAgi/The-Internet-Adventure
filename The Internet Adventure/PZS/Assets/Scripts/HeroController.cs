using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour {

    Animator anim;
    Rigidbody2D rbody;
    public float hspeed;
    public float jumpForce;
    private bool canJump;
    private bool Jump;
    public  bool grounded;


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
            rbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }


    }
    
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && grounded)
        {
            Jump = true;
        }

    }
    

    // Kiedy dotykach platformy, możesz skakać i jesteś uziemiony
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Platform")
        {
            grounded = true;
            canJump = true;
        }
    }

    // Kiedy jesteś w powietrzu, nie możesz skakać;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Platform")
        {
            grounded = false;
            canJump = false;
        }
    }

}


