using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_controler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    const float speed = 1.0f;
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * speed,transform.position.z);
	}
}
