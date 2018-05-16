using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginMenu : MonoBehaviour {

    public void LogInMenu()
    {
        transform.Find("Login").gameObject.GetComponent<Text>().text = "";
        transform.Find("Register").gameObject.SetActive(false);
        transform.GetChild(0).Find("LoginUsername").gameObject.SetActive(true);
        transform.GetChild(0).Find("LoginPassword").gameObject.SetActive(true);
        transform.GetChild(0).Find("LoginButton").gameObject.SetActive(true);
    }

    public void RegisterMenu()
    {
        transform.Find("Register").gameObject.GetComponent<Text>().text = "";
        transform.Find("Login").gameObject.SetActive(false);
        transform.GetChild(1).Find("RegisterUsername").gameObject.SetActive(true);
        transform.GetChild(1).Find("RegisterPassword").gameObject.SetActive(true);
        transform.GetChild(1).Find("RegisterPassword2").gameObject.SetActive(true);
        transform.GetChild(1).Find("RegisterEmail").gameObject.SetActive(true);
        transform.GetChild(1).Find("RegisterButton").gameObject.SetActive(true);
    }

}
