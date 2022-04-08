using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicenemy : MonoBehaviour
{
    public int life;

    


    public void hit(int damage)
    {
        life -= damage;
    }




    void Update()
    {

       if (life <= 0)
       {
           Destroy(this.gameObject);
       }


    }

  // private void OnTriggerEnter(Collider collision)
  // {
  //     bullet bullety = collision.GetComponent<bullet>();
  //
  //     if (bullety != null)
  //     {
  //         life -= 10;
  //
  //     }
  //
  //
  // }



}
