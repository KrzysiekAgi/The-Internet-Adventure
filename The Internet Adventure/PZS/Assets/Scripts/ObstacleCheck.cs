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


      /*  if (collision.tag == "Obstacle")
        {
            //Destroy();
            Wait(30); // Doesn't work; why??
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        }*/
    }

   /* IEnumerator Wait(float seconds)
    {
        Debug.Log("asd\n");
        yield return new WaitForSeconds(seconds);
        Debug.Log("qwe\n");
    }*/

}
