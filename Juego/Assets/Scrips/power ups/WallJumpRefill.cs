using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumpRefill : MonoBehaviour
{

    public int RefillCount = 0;


    private void OnTriggerEnter(Collider collision)
    {
        FPSWallrun player = collision.GetComponent<FPSWallrun>();

        if (player != null)
        {
            player.WrCount = 0;

            Destroy(this.gameObject);
        }
    }
}
