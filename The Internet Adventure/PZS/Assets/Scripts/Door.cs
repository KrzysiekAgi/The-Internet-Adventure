using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public Sprite  openedDoor;

	// Use this for initialization
	void Start () {
		
	}
	
    public void OpenDoor()
    {
        GetComponent<SpriteRenderer>().sprite = openedDoor;
        GetComponent<BoxCollider2D>().enabled = true;
    }

}
