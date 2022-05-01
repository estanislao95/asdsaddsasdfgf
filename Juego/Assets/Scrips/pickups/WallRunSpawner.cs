using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRunSpawner : MonoBehaviour
{
    [SerializeField]
    private float timer = 7;

    private float count = 0;
    private bool trigger = false;
    public WallJumpRefill WallJumpRefill;

    public AudioSource pop;



    void Update()
    {
        if (trigger == true)
            count += Time.deltaTime;


        if (timer <= count)
        {
            WallJumpRefill = Instantiate(WallJumpRefill);

            WallJumpRefill.transform.position = this.transform.position;
            trigger = false;
            count = 0;
        }




    }


    private void OnTriggerEnter(Collider collision)
    {
        move player = collision.GetComponent<move>();

        if (player != null && trigger == false)
        {
            trigger = true;
            pop.Play();
        }


    }
}
