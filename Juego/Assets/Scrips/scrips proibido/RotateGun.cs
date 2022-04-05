using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGun : MonoBehaviour
{
    public FPSGrapplegun grappling;

    private Quaternion rotation;
    public float Rspeed = 5f;


    void Update()
    {
        if (!grappling.isgrapling())
        {
            rotation = transform.parent.rotation;
        }
        else
        {
            rotation = Quaternion.LookRotation(grappling.CurrentGp() - transform.position);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * Rspeed);
    }
}
