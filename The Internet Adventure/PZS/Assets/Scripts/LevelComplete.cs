using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour {

    public string newLevelName;

	void OnTriggerEnter2D() {
        Application.LoadLevel (newLevelName);
		
	}
	
	
}
