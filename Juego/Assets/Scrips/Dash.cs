using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{


    public float dash_timer = 0;
    public int dash_amount = 0;
    int dash_amount_max = 0;
    public int dashon = 0;
    public float dashtimer = 0;
    public float refilltimer = 0;
    public float refilltimermax = 0;

    public float dashspeed = 0;

    move player;

    void Start()
    {
        player = GetComponent<move>();
        dash_amount_max = dash_amount = 0;
    }


    void Update()
    {
        dash();
    }


    void dash()
    {
        if (dashon == 1)
        {
            refilltimer += Time.deltaTime;

            if (refilltimer >= refilltimermax)
            {
                dashon = 0;
                refilltimer = 0;

            }

        }

        Debug.Log(dashon);

        if (Input.GetKeyDown(KeyCode.LeftShift) && dashon == 0 
            && Input.GetKey(KeyCode.W) && dashtimer >= dash_timer)
        {
            dashtimer += Time.deltaTime;


            dashon = 1;

        }




    }


}
