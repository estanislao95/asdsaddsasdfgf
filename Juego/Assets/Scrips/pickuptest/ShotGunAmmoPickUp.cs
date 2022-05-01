using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunAmmoPickUp : PickUpDestroy
{
    public int ShotGunAmmo = 0;
    public AudioClip sound;

    public override void OnTriggerEnter(Collider collision)
    {
        Shooting move = collision.GetComponent<Shooting>();

        if (move != null && move.Shotgungunammo != move.ShotgungunammoMax)
        {
            AudioSource.PlayClipAtPoint(sound, move.transform.position);
            move.Shotgungunammo += ShotGunAmmo;
            base.OnTriggerEnter(collision);
        }



    }
}
