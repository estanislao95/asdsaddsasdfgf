using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    public int Heal = 0;
    public AudioClip sound;

    private void OnTriggerEnter(Collider collision)
    {
        move player = collision.GetComponent<move>();
        if (player != null && player.currentlife != player.maxlife)
        {
            player.currentlife += Heal;
            AudioSource.PlayClipAtPoint(sound, transform.position);
            Destroy(this.gameObject);
        }
    }
}
