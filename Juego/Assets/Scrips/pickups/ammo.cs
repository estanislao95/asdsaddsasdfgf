using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo : MonoBehaviour
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


        if (bulletsy != null && bulletsy.pistolammo != bulletsy.pistolammoMax)
        {

            bulletsy.pistolammo += bullets;

            Destroy(this.gameObject);
        }



    }

}
