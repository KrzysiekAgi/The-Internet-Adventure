using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour {

    public GameObject[] groundPrefabs;
    public float maxStep;
    float PreviousGroundY = -3.44f;
    float newX;

    // Use this for initialization
    void Start () {
        InvokeRepeating("GenerateNewGround", 0.9f, 2);
	}
	
	void GenerateNewGround () {

        do
        {

            newX = Random.Range(-6.5f, 4.5f);

        } while (newX > maxStep + PreviousGroundY && newX < 2 * maxStep + PreviousGroundY);

        Vector3 targetPrefabPosition = new Vector3(newX, this.transform.position.y, this.transform.position.z);
        PreviousGroundY = targetPrefabPosition.x;

        Instantiate(groundPrefabs[Random.Range(0, groundPrefabs.Length)], targetPrefabPosition, Quaternion.identity);
	}
}
