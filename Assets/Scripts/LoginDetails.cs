using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginDetails : MonoBehaviour
{
    public GameObject rb;
    public GameObject username;
    public GameObject userinput;
    public GameObject password;
    public GameObject passwordInput;
    public GameObject oginbutton;

    public void LoginButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void registreButton()
    {
        rb.SetActive(true);
    }

    public void QuitLog()
    {
        Application.Quit();
    }

    public void credentials()
    {
        if (userinput == username && passwordInput == password)
        {
            oginbutton.SetActive(true);

        }
    }

}
