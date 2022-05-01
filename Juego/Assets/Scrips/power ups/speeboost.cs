using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speeboost : MonoBehaviour
{




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
            player.speedboost = 1;

            Destroy(this.gameObject);
        }



    }

}
