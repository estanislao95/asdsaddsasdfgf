using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolAmmoPickUp : PickUpDestroy
{
    public int PistolAmmo = 0;
    public AudioClip sound;

    public override void OnTriggerEnter(Collider collision)
    {
        Shooting move = collision.GetComponent<Shooting>();

        if (move != null && move.pistolammo != move.pistolammoMax)
        {
            AudioSource.PlayClipAtPoint(sound, move.transform.position);
            move.pistolammo += PistolAmmo;
            base.OnTriggerEnter(collision);
        }



    }
}
