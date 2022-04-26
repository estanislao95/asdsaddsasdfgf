using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{



    public void StartGame()
    {
        SceneManager.LoadScene("tutorial");
        
    }

    public void Gototestplace()
    {
        SceneManager.LoadScene("SampleScene");

    }

    public void menu()
    {
        SceneManager.LoadScene("menu");

    }



    public void Salir()
    {
        Application.Quit();

    }
}
