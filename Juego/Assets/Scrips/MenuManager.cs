using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MenuManager : MonoBehaviour
{
    public Animator cam;

    public Animator tittle;
    public Animator inicio;
    public Animator creditos;
    public Animator salir;
    //public Text title;
    //public Text button1;
    //public Text button2;
    //public Text button3;


    bool triggered = false;

    void Start()
    {
        cam = GetComponent<Animator>();

        tittle = GetComponent<Animator>();
        inicio = GetComponent<Animator>();
        creditos = GetComponent<Animator>();
        salir = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       // if (triggered == true)
       // {
       //     alpha = Mathf.Lerp(0, 255, 200 * Time.deltaTime);
       //
       //
       //     title.color = new Color32(0, 0, 0, Convert.ToByte(alpha));
       //     button1.color = new Color32(0, 0, 0, Convert.ToByte(alpha));
       //     button2.color = new Color32(0, 0, 0, Convert.ToByte(alpha));
       //     button3.color = new Color32(0, 0, 0, Convert.ToByte(alpha));
       // }




    }



    public void Gamestart()
    {
        triggered = true;

        cam.SetTrigger("getmad");

        tittle.SetTrigger("getmad");

        inicio.SetTrigger("getmad");

        creditos.SetTrigger("getmad");

        salir.SetTrigger("getmad");
    }
}
