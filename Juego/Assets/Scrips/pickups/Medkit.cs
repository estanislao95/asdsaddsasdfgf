using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    public int Heal = 0;

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


        if (player != null && player.currentlife != player.maxlife)
        {

            player.currentlife += Heal;

            Destroy(this.gameObject);
        }



    }
}
