using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumplatform : MonoBehaviour
{
    // Start is called before the first frame update
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


            player.rigid.AddForce(Vector3.up * player.jumpspeed * 4.2f, ForceMode.Impulse);



        }



    }



}
