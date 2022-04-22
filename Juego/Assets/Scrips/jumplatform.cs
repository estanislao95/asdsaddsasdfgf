using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumplatform : MonoBehaviour
{
    public float jumpPower = 0;

    private void OnTriggerEnter(Collider collision)
    {
        move player = collision.GetComponent<move>();


        if (player != null)
        {


            player.rigid.AddForce(Vector3.up * player.jumpspeed * jumpPower, ForceMode.Impulse);



        }



    }



}
