using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleCheck : MonoBehaviour {

    Rigidbody2D rbody;
 

    // Gdy dotykasz przeszkody
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Hero")
        {
            other.gameObject.GetComponent<Animator>().SetTrigger("fail");
        }

    }



}
