using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammomachinegun : MonoBehaviour
{
    public int bullets = 0;
    public AudioClip sound;

    private void OnTriggerEnter(Collider collision)
    {
        Shooting bulletsy = collision.GetComponent<Shooting>();
        if (bulletsy != null && bulletsy.machinegunammo != bulletsy.machinegunammoMax)
        {

            bulletsy.machinegunammo += bullets;
            AudioSource.PlayClipAtPoint(sound, transform.position);
            Destroy(this.gameObject);
        }
    }
}
