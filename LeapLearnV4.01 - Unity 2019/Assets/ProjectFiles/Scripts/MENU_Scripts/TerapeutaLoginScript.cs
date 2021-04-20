using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TerapeutaLoginScript : MonoBehaviour
{
    private string username = "terapeuta@login.com";
    private string password = "Terapeuta@pass";

    private string link = "https://docs.google.com/spreadsheets/d/1soIVlB6zk0gNDHNAtuxdGvQJJj548naTa2zACdga16s/edit#gid=1238069541";

    private string usernameInput;
    private string passwordInput;

    public GameObject loginFail;

    public GameObject usernameInputField;
    public GameObject passwordInputField;
    
   private void LogIn()
    {
        SceneManager.LoadScene(2);
        Debug.Log("Logado");
    }

    public void LoginCheck()
    {
        passwordInput = passwordInputField.GetComponent<InputField>().text;
        usernameInput = usernameInputField.GetComponent<InputField>().text;

        if (usernameInput == username && passwordInput == password)
        {
            LogIn();
        }
        else
        {
            loginFail.active = true;
            if (loginFail.active)
            {
                loginFail.GetComponent<Animation>().Play();
            }
        }
    }


    public void OpenSpreadSheet()
    {
        Application.OpenURL(link);
    }

}
