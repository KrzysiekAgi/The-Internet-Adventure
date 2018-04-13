using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCoin : MonoBehaviour
{

    CounterController counterController;

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
            counterController.IncrementCounter();
        }
    }
}
