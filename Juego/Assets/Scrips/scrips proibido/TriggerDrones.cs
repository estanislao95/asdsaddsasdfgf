using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDrones : MonoBehaviour
{
    [SerializeField]
    private MovingPoint one;
    [SerializeField]
    private MovingPoint two;

    private void OnTriggerEnter(Collider collision)
    {
        move move = collision.GetComponent<move>();


        if (move != null)
        {
            one.trigger = true;
            two.trigger = true;

            Debug.Log("hit");
        }



    }


}
