using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {


    // Kiedy dotykach platformy, możesz skakać i jesteś uziemiony
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Platform")
        {
            transform.parent.GetComponent<HeroController>().grounded = true;
            transform.parent.GetComponent<HeroController>().jumpCounter = 0;
        }
    }

    // Kiedy jesteś w powietrzu, nie możesz skakać;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Platform")
        {
            transform.parent.GetComponent<HeroController>().grounded = false;
            
        }
    }
}
