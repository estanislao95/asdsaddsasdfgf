using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPickUp : PickUpDestroy
{
    public int Armor = 0;
    public AudioClip sound;

    public override void OnTriggerEnter(Collider collision)
    {
        move move = collision.GetComponent<move>();

        if (move != null && move.currentarmor != move.maxarmor)
        {
            AudioSource.PlayClipAtPoint(sound, move.transform.position);
            move.currentarmor += Armor;
            base.OnTriggerEnter(collision);
        }



    }
}
