using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    public int Armore = 0;
    public AudioClip sound;

    private void OnTriggerEnter(Collider collision)
    {
        move player = collision.GetComponent<move>();
        if (player != null && player.currentarmor != player.maxarmor)
        {
            player.currentarmor += Armore;
            AudioSource.PlayClipAtPoint(sound, transform.position);
            Destroy(this.gameObject);
        }
    }
}
