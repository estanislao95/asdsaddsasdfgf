using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpSpawner : MonoBehaviour
{

    [SerializeField]
    private float timer = 7;

    private float count = 0;
    private bool trigger = false;
    public powerup powerup;

    public AudioSource pop;
    //public AudioClip sound;


    void Update()
    {
        if (trigger == true)
            count += Time.deltaTime;


        if (timer <= count)
        {
            powerup doublejump = Instantiate(powerup);

            doublejump.transform.position = this.transform.position;
            trigger = false;
            count = 0;
        }




    }


    private void OnTriggerEnter(Collider collision)
    {
        move player = collision.GetComponent<move>();

        if (player != null)
        {
            trigger = true;
            pop.Play();
        }


    }

}
