using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{

    public float timeDestruction;

    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, timeDestruction);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
