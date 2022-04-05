using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    public int Armore = 0;

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


        if (player != null && player.currentarmor != player.maxarmor)
        {

            player.currentarmor += Armore;

            Destroy(this.gameObject);
        }



    }
}
