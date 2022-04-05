using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammomachinegun : MonoBehaviour
{


    public int bullets = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider collision)
    {
        Shooting bulletsy = collision.GetComponent<Shooting>();


        if (bulletsy != null && bulletsy.machinegunammo != bulletsy.machinegunammoMax)
        {

            bulletsy.machinegunammo += bullets;

            Destroy(this.gameObject);
        }



    }
}
