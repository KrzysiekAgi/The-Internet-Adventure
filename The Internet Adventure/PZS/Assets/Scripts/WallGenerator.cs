using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour {

    public GameObject[] wallPrefabs;
    /*public float maxStep;
    float PreviousGroundY = -3.44f;-*/
   // float newX;

    // Use this for initialization
    void Start () {
        InvokeRepeating("GenerateNewGround", 5, 15);
	}
	
	void GenerateNewGround () {

     /*   do
        {

            newX = Random.Range(-6.5f, 4.5f);

        } while (newX > maxStep + PreviousGroundY && newX < 2 * maxStep + PreviousGroundY);*/

        Vector3 targetPrefabPositionRight = new Vector3(23.5f, this.transform.position.y, this.transform.position.z);
        Vector3 targetPrefabPositionLeft = new Vector3(-0.1f, this.transform.position.y, this.transform.position.z);
        // PreviousGroundY = targetPrefabPositionRight.y;

        Instantiate(wallPrefabs[0], targetPrefabPositionLeft, Quaternion.identity);
        Instantiate(wallPrefabs[1], targetPrefabPositionRight, Quaternion.identity);
    }
}
