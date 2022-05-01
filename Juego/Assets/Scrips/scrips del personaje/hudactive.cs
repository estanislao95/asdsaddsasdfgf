using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hudactive : MonoBehaviour
{
    [SerializeField]
    private FPSGrapplegun gun;

    [SerializeField]
    private bool hud = false;

    void Start()
    {
       // gun = GetComponent<FPSGrapplegun>();

        if (gun == true)
        {
            gun.CrossHair.color = new Color32(0, 0, 0, 0);
        }
    }




    private void OnTriggerEnter(Collider collision)
    {
        move move = collision.GetComponent<move>();


        if (move != null)
        {
            gun.active = true;

            gun.CrossHair.color = new Color32(50, 50, 50, 255);
        }



    }


}
