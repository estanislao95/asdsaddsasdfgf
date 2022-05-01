using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDestroy : MonoBehaviour
{
    protected bool trigger = false;


    public virtual void OnTriggerEnter(Collider collision)
    {
        move move = collision.GetComponent<move>();


        if (move != null)
        {
            Destroy(this.gameObject);
        }
    }

}
