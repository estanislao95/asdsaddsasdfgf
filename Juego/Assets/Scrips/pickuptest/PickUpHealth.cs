using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHealth : PickUpDestroy
{
    public int Life = 0;
    public AudioClip sound;

    public override void OnTriggerEnter(Collider collision)
    {
        move move = collision.GetComponent<move>();

        if (move != null && move.currentlife != move.maxlife)
        {
            AudioSource.PlayClipAtPoint(sound, move.transform.position);
            move.currentlife += Life;
            base.OnTriggerEnter(collision);
        }



    }

}
