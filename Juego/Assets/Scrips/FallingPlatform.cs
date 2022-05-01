using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField]
    private float timer = 25;
    private float count = 0;

    private bool dead;

    private bool trigger;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {


        if (trigger == true && dead == false)
        {
            if (count < timer)
            {
                count += Time.deltaTime;
               
            }
            else
            {
                dead = true;
                rb.useGravity = true;
            }
        }



    }

    private void OnTriggerEnter(Collider collision)
    {
        move move = collision.GetComponent<move>();


        if (move != null)
        {
            trigger = true;



        }



    }

}
