using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{

    public int jumpbonus = 0;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        move player = collision.GetComponent<move>();


        if (player != null)
        {
            player.jumpamount -= jumpbonus;
            player.isjump = true;

            Destroy(this.gameObject);
        }



    } 
}
