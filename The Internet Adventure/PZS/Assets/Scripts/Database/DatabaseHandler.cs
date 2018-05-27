using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        connectionString = "Database=" + database + ";Data Source=" + host + ";User Id=" + user + ";Password=" + password + ";";

        /*connectionString = "Server=" + host + "Database=" + database + "User=" + user + "Password=" + password + "Polling=";
        if(pooling)
        {
            connectionString += "true;";
        } else
        {
            connectionString += "false;";
        }*/



        //Register("Pitrex","kappa", "pitrex111@interia.pl", "M", "PITREX");
        //Login("Pitreax", "kappa");
        //UpdateLastGame("10000", "5.5", "200", "0", "KRzych");

        //SceneManager.LoadScene("login_menu");

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

    public bool Login(string login, string password)
    {
        Connect();
        string loginString = "Select count(*) from USER where login like '" + login + "' and password like '" + password + "';";
        MySqlCommand cmdLogin = con.CreateCommand();
        cmdLogin.CommandType = CommandType.Text;
        cmdLogin.CommandText = loginString;
        if (Convert.ToInt32(cmdLogin.ExecuteScalar()) == 1)
        {
            Debug.Log("Logged in");
            con.Close();
            return true;
        }
        Debug.Log("Wrong login or password");
        con.Close();
        return false;

    }

    public bool Register(string login,string password, string email, string sex, string nick)
    {
        Connect();
        int cos = 0;
        string checkString = "Select count(*) from USER where login like '"+login+"' or email like '"+email+"' or nick like '"+nick+"';";
        //string checkString = "Select count(*) from USER where false;";
        MySqlCommand cmdCheck = con.CreateCommand();
        cmdCheck.CommandType = CommandType.Text;
        cmdCheck.CommandText = checkString;
        cos = Convert.ToInt32(cmdCheck.ExecuteScalar());

        if (cos != 0)
        {
            con.Close();
            return false; // TODO zamien cos na madra nazwe i dopisz dlaczego false
        }
        //cmd.ExecuteNonQuery();
        //DataTable dt = new DataTable();
        //MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
        //adapter.Fill(dt);
        //cos = Convert.ToInt32(dt.);

        string creatingString = "Insert into USER Values( null, '" + login + "', '" + password + "', '" + email + "', null, 1, '" + sex + "', '" + nick + "');"; //TODO dopisz numer przy kolejnych takich samych nickach
        MySqlCommand cmdCreate = con.CreateCommand();
        cmdCreate.CommandType = CommandType.Text;
        cmdCreate.CommandText = creatingString;
        if(cmdCreate.ExecuteNonQuery()==1) Debug.Log("Created account: " + login);

        Debug.Log("cos: " + cos);

        con.Close();

        return true;
    }

    public void UpdateLastGame (string score, string time, string gold, string number_of_memes, string login)
    {
        Connect();
        string statisticString = "Update LAST_GAME L, USER U Set L.score ="+score+", L.time="+time+",L.gold ="+gold+", L.number_of_mems=0 where L.user_id = U.id and U.login like '"+login+"';";
        MySqlCommand cmdUpdate = con.CreateCommand();
        cmdUpdate.CommandType = CommandType.Text;
        cmdUpdate.CommandText = statisticString;
        cmdUpdate.ExecuteNonQuery();

        con.Close();
    }


    public string[][] ViewRanking ()
    {
        Connect();
        string rankingString = "Select * from RANKING;";
        MySqlDataReader reader;
        MySqlCommand cmdRank = con.CreateCommand();
        cmdRank.CommandType = CommandType.Text;
        cmdRank.CommandText = rankingString;
        reader = cmdRank.ExecuteReader();
        try
        {
            while (reader.Read())
            {
                Debug.Log(reader.GetString(0));
            }
        }
        finally { }
        
        reader.Close();
        con.Close();
    

        return null;
    }

    public void DeleteAccount(string login)
    {
        Connect();
        string deleteString = "Delete from USER where login like '" +login+"';";
        MySqlCommand cmdDelete = con.CreateCommand();
        cmdDelete.CommandType = CommandType.Text;
        if (cmdDelete.ExecuteNonQuery() == 1) Debug.Log("Deleted account: " + login);
        con.Close();
    }

    private void Connect()
    {
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
}
