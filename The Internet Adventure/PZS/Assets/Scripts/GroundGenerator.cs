using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour {

    public GameObject groundPrefab;


	// Use this for initialization
	void Start () {
        InvokeRepeating("GenerateNewGround", 0, 1.8f);
	}
	
	void GenerateNewGround () {

        Vector3 targetPrefabPosition = new Vector3(Random.Range(-6.5f, 4.5f), this.transform.position.y, this.transform.position.z);
        
        Instantiate(groundPrefab, targetPrefabPosition, Quaternion.identity);
	}
}
