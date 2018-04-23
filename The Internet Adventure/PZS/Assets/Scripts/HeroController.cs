using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroController : MonoBehaviour {

    Animator anim;
    Rigidbody2D rbody;
    public float hspeed;
    public float jumpForce;
    public int jumpCounter { get; set; }
    private bool Jump;
    private bool started;
    public  bool grounded { get; set; }
    public bool canStick;
    public Vector2 onDownPosition;
    public Vector2 deltaPosition;

    public bool ifStarted()
    {
        return started;
    }


    // Use this for initialization
    void Start () {

        anim = GetComponent<Animator> ();
        rbody = GetComponent<Rigidbody2D>();
        Jump = false;
        canStick = true;
        started = false;
        Camera_controler.setHeroController(this);
    }

    // Update is called once per frame
    void FixedUpdate() {

        float horizontalDir = Input.GetAxis("Horizontal");
        anim.SetFloat("horizontalDir", Mathf.Abs(horizontalDir));

        if(anim.GetCurrentAnimatorStateInfo(0).IsName("obstacleContact"))
        {
            rbody.velocity = Vector2.zero;
            return;
        }

        rbody.velocity = new Vector2(horizontalDir * hspeed, rbody.velocity.y);


        /*if (rbody.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (rbody.velocity.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }*/

        if (rbody.velocity.x < 0) transform.localScale = new Vector3(-1f, 1f, 1f);
        if (horizontalDir > 0) transform.localScale = new Vector3(1f, 1f, 1f);


        if (Jump)
        {
            anim.SetTrigger("jump");
            Jump = false;
            started = true;
            //if (deltaPosition.x > 5)
            //    deltaPosition.x = 5;
            //if (deltaPosition.y > 10)
            //    deltaPosition.y = 10;

            //rbody.velocity = deltaPosition;


            rbody.velocity = new Vector2(rbody.velocity.x, jumpForce);


            //rbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }


    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCounter < 1)
        {
            GetComponent<Rigidbody2D>().isKinematic = false;
            Jump = true;
            jumpCounter++;
            StartCoroutine(Stick());
        }


        if (Input.GetMouseButtonDown(0))
        {
            onDownPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if (Input.GetMouseButtonUp(0))
        {
            float x = 0;
            float y = 0;
            x = (Input.mousePosition.x - onDownPosition.x) / 20;
            y = (Input.mousePosition.y - onDownPosition.y) / 10;

            if (x > 5) x = 5;
            if (x < -5) x = -5;
            if (y > 10) y = 10;
            if (y < -10) y = -10;

            deltaPosition = new Vector2(x, y);
            Jump = true;
        }
    }

    IEnumerator Stick()
    {
        canStick = false;
        yield return new WaitForSeconds(0.3F);
        canStick = true;
    }


    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
    }

}


