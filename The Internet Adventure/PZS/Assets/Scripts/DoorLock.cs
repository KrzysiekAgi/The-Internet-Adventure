using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorLock : MonoBehaviour {

    public GameObject door;
    public Sprite unlocked;
    public AudioClip clip;

    void OnTriggerEnter2D()
    {
        door.SendMessage("OpenDoor");
        AudioSource.PlayClipAtPoint(clip, transform.position);
        GetComponent<SpriteRenderer>().sprite = unlocked;
    }
}
