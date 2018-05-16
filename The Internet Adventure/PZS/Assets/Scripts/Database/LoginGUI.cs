using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginGUI : MonoBehaviour {

    public DatabaseHandler mysqlHandler;

    public void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 300, 30),"Connection state: "+ mysqlHandler.GetConnectionState());
    }

}
