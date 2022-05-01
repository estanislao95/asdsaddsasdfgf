using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunPickUp : PickUpDestroy
{
    public int MachineGunAmmo = 0;
    public AudioClip sound;

    public override void OnTriggerEnter(Collider collision)
    {
        Shooting move = collision.GetComponent<Shooting>();

        if (move != null && move.machinegunammo != move.machinegunammoMax)
        {
            AudioSource.PlayClipAtPoint(sound, move.transform.position);
            move.machinegunammo += MachineGunAmmo;
            base.OnTriggerEnter(collision);
        }



    }
}
