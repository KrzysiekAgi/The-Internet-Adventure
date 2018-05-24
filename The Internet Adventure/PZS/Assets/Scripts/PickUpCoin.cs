using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCoin : MonoBehaviour
{

    CounterController counterController;
    public AudioClip clip;

    // Use this for initialization
    void Start()
    {
        counterController = GameObject.Find("Manager").GetComponent<CounterController>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Hero")
        {
            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(clip, transform.position);
            counterController.IncrementCounter();
        }
    }
}
