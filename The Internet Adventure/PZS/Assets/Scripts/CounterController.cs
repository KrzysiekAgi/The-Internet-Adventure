using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterController : MonoBehaviour
{

    int numberOfCoin;
    Text counterView;

    // Use this for initialization
    void Start()
    {
        ResetCounter();
    }

    public void IncrementCounter()
    {
        numberOfCoin++;
        counterView.text = numberOfCoin.ToString();
    }
    public void ResetCounter()
    {
        numberOfCoin = 0;
        counterView.text = numberOfCoin.ToString();
    }
}
