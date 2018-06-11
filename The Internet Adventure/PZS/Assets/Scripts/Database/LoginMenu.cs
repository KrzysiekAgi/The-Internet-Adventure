using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoginMenu : MonoBehaviour {


    public void LogInMenu()
    {
        transform.Find("Login").gameObject.GetComponent<TextMeshProUGUI>().text = "";
        transform.Find("Register").gameObject.SetActive(false);
        transform.Find("guest").gameObject.SetActive(false);
        transform.Find("exit").gameObject.SetActive(false);
        transform.parent.Find("Game name").gameObject.SetActive(false);
        transform.GetChild(0).Find("LoginUsername").gameObject.SetActive(true);
        transform.GetChild(0).Find("LoginPassword").gameObject.SetActive(true);
        transform.GetChild(0).Find("LoginButton").gameObject.SetActive(true);
        transform.GetChild(0).Find("BackButton").gameObject.SetActive(true);
        transform.GetChild(0).Find("Error").gameObject.SetActive(true);
        transform.GetChild(0).Find("Error").gameObject.GetComponent<TextMeshProUGUI>().text = "";
    }

    public void LogInBack()
    {
        transform.Find("Login").gameObject.GetComponent<TextMeshProUGUI>().text = "Login";
        transform.Find("Register").gameObject.SetActive(true);
        transform.Find("guest").gameObject.SetActive(true);
        transform.Find("exit").gameObject.SetActive(true);
        transform.parent.Find("Game name").gameObject.SetActive(true);
        transform.GetChild(0).Find("LoginUsername").gameObject.SetActive(false);
        transform.GetChild(0).Find("LoginPassword").gameObject.SetActive(false);
        transform.GetChild(0).Find("LoginButton").gameObject.SetActive(false);
        transform.GetChild(0).Find("BackButton").gameObject.SetActive(false);
        transform.GetChild(0).Find("Error").gameObject.SetActive(false);
    }

    public void RegisterMenu()
    {
        transform.Find("Register").gameObject.GetComponent<TextMeshProUGUI>().text = "";
        transform.Find("Login").gameObject.SetActive(false);
        transform.Find("guest").gameObject.SetActive(false);
        transform.Find("exit").gameObject.SetActive(false);
        transform.parent.Find("Game name").gameObject.SetActive(false);
        transform.GetChild(1).Find("RegisterLogin").gameObject.SetActive(true);
        transform.GetChild(1).Find("RegisterPassword").gameObject.SetActive(true);
        transform.GetChild(1).Find("RegisterSecondPassword").gameObject.SetActive(true);
        transform.GetChild(1).Find("RegisterEmail").gameObject.SetActive(true);
        transform.GetChild(1).Find("RegisterBack").gameObject.SetActive(true);
        transform.GetChild(1).Find("RegisterDropdown").gameObject.SetActive(true);
        transform.GetChild(1).Find("RegisterNickname").gameObject.SetActive(true);
        transform.GetChild(1).Find("RegisterButton").gameObject.SetActive(true);
        transform.GetChild(1).Find("Error").gameObject.SetActive(true);
        transform.GetChild(1).Find("Error").gameObject.GetComponent<TextMeshProUGUI>().text = "";
    }

    public void RegisterBack()
    {
        transform.Find("Register").gameObject.GetComponent<TextMeshProUGUI>().text = "Register";
        transform.Find("Login").gameObject.SetActive(true);
        transform.Find("guest").gameObject.SetActive(true);
        transform.Find("exit").gameObject.SetActive(true);
        transform.parent.Find("Game name").gameObject.SetActive(true);
        transform.GetChild(1).Find("RegisterLogin").gameObject.SetActive(false);
        transform.GetChild(1).Find("RegisterPassword").gameObject.SetActive(false);
        transform.GetChild(1).Find("RegisterSecondPassword").gameObject.SetActive(false);
        transform.GetChild(1).Find("RegisterEmail").gameObject.SetActive(false);
        transform.GetChild(1).Find("RegisterBack").gameObject.SetActive(false);
        transform.GetChild(1).Find("RegisterDropdown").gameObject.SetActive(false);
        transform.GetChild(1).Find("RegisterNickname").gameObject.SetActive(false);
        transform.GetChild(1).Find("RegisterButton").gameObject.SetActive(false);
        transform.GetChild(1).Find("Error").gameObject.SetActive(false);

    }

    public void GuesEnter()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LogIN()
    {
        string login, password;
        bool isLogged = false;
        login = GameObject.Find("LoginUsername").gameObject.GetComponent<InputField>().text;
        password = GameObject.Find("LoginPassword").gameObject.GetComponent<InputField>().text;

        isLogged = GameObject.Find("_mysql").gameObject.GetComponent<DatabaseHandler>().Login(login, password);


        if (isLogged)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            transform.GetChild(0).Find("Error").gameObject.GetComponent<TextMeshProUGUI>().text = "Wrong username or password";
        }

    }

    public void Register()
    {
        string login, password, secondpassword, email, sex, nick;
        string pattern;
        bool registeredDone = false;

        login = transform.GetChild(1).Find("RegisterLogin").gameObject.GetComponent<InputField>().text;
        password = transform.GetChild(1).Find("RegisterPassword").gameObject.GetComponent<InputField>().text;
        secondpassword = transform.GetChild(1).Find("RegisterSecondPassword").gameObject.GetComponent<InputField>().text;
        email = transform.GetChild(1).Find("RegisterEmail").gameObject.GetComponent<InputField>().text;
        nick = transform.GetChild(1).Find("RegisterNickname").gameObject.GetComponent<InputField>().text;

        if (transform.GetChild(1).Find("RegisterDropdown").gameObject.GetComponent<Dropdown>().value == 0)
        {
            sex = "M";
        }
        else
        {
            sex = "F";
        }

        if (login.Equals("") || password.Equals("") || secondpassword.Equals("") || email.Equals("") || nick.Equals(""))
        {
            transform.GetChild(1).Find("Error").gameObject.GetComponent<TextMeshProUGUI>().text = "All fields must be entered";
            ClearInput();
            return;
        }

        pattern = "^(?=.{4,20}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$";
        if(!Regex.IsMatch(login,pattern))
        {
            transform.GetChild(1).Find("Error").gameObject.GetComponent<TextMeshProUGUI>().text = "Login must be beetewen 4-20 characters (a-z,A-Z,0-9)";
            ClearInput();
            return;
        }
        pattern = "^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{5,}$";
        if (!Regex.IsMatch(password, pattern))
        {
            transform.GetChild(1).Find("Error").gameObject.GetComponent<TextMeshProUGUI>().text = "Password must be at least 5 characters (one letter, one number)";
            ClearInput();
            return;
        }
        if(!IsValidEmail(email))
        {
            transform.GetChild(1).Find("Error").gameObject.GetComponent<TextMeshProUGUI>().text = "Email is not valid";
            ClearInput();
            return;
        }
        pattern = "^(?=.{4,20}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$";
        if (!Regex.IsMatch(login, pattern))
        {
            transform.GetChild(1).Find("Error").gameObject.GetComponent<TextMeshProUGUI>().text = "Nickname must be beetewen 4-20 characters (a-z,A-Z,0-9)";
            ClearInput();
            return;
        }

        if (password.Equals(secondpassword))
        {
            
            registeredDone = GameObject.Find("_mysql").gameObject.GetComponent<DatabaseHandler>().Register(login, password, email, sex, nick);
            if (registeredDone)
            {
                transform.GetChild(1).Find("Error").gameObject.GetComponent<TextMeshProUGUI>().text = "Registration Complete";
            }
            else
            {
                transform.GetChild(1).Find("Error").gameObject.GetComponent<TextMeshProUGUI>().text = "User Exist";
            }
        }
        else
        {
            transform.GetChild(1).Find("Error").gameObject.GetComponent<TextMeshProUGUI>().text = "Password doesn't match";
        }

        

        transform.GetChild(1).Find("RegisterLogin").gameObject.GetComponent<InputField>().text = "";
        transform.GetChild(1).Find("RegisterPassword").gameObject.GetComponent<InputField>().text = "";
        transform.GetChild(1).Find("RegisterSecondPassword").gameObject.GetComponent<InputField>().text = "";
        transform.GetChild(1).Find("RegisterEmail").gameObject.GetComponent<InputField>().text = "";
        transform.GetChild(1).Find("RegisterNickname").gameObject.GetComponent<InputField>().text = "";

    }

    bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    void ClearInput()
    {
        transform.GetChild(1).Find("RegisterLogin").gameObject.GetComponent<InputField>().text = "";
        transform.GetChild(1).Find("RegisterPassword").gameObject.GetComponent<InputField>().text = "";
        transform.GetChild(1).Find("RegisterSecondPassword").gameObject.GetComponent<InputField>().text = "";
        transform.GetChild(1).Find("RegisterEmail").gameObject.GetComponent<InputField>().text = "";
        transform.GetChild(1).Find("RegisterNickname").gameObject.GetComponent<InputField>().text = "";
    }

}
