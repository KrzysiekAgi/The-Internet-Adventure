using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using UnityEngine;

public class DatabaseHandler : MonoBehaviour {

    public string host, database, user, password;
    public bool pooling = true;

    private string connectionString;
    private MySqlConnection con = null;
    private MySqlCommand cmd = null;
    private MySqlDataReader reader = null;

    private MD5 _md5Hash;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        connectionString = "Server=" + host + "Database=" + database + "User=" + user + "Password=" + password + "Polling=";
        if(pooling)
        {
            connectionString += "true;";
        } else
        {
            connectionString += "false;";
        }

        try
        {
            con = new MySqlConnection(connectionString);
            con.Open();
            Debug.Log("Mysql State: " + con.State);
        } catch(Exception e)
        {
            Debug.Log(e);
        }

    }

    private void OnApplicationQuit()
    {
        if(con != null)
        {
            if(con.State.ToString() != "Closed")
            {
                con.Close();
                Debug.Log("MySql Connection closed");
            }
            con.Dispose();
        }
    }

    public string GetConnectionState()
    {
        return con.State.ToString();
    }

}
