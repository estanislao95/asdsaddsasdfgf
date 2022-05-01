using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class area : MonoBehaviour
{

    public TowerShoot tower;

    private void OnTriggerEnter(Collider collision)
    {
        move move = collision.GetComponent<move>();

        if (move != null)
        {
            tower.trigger = true;
        }
        else
        {
            tower.trigger = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        move move = other.GetComponent<move>();

        if (move != null)
        {
            tower.trigger = false;
        }
    }
}
