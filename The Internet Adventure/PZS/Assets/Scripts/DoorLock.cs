using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour {

    public GameObject door;
    public Sprite unlocked;

    void OnTriggerEnter2D()
    {
        door.SendMessage("OpenDoor");
        GetComponent<SpriteRenderer>().sprite = unlocked;
    }
}
