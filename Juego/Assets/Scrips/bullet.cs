using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bullet : MonoBehaviour
{

    public int timetilldead;

    public float timer;

    public int damage = 0;


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;


        if (timer >= timetilldead)
        {
            Destroy(this.gameObject);
        }

    }


    void kill()
    {
        

    }

    private void OnTriggerEnter(Collider collision)
    {
        basicenemy myenemy = collision.GetComponent<basicenemy>();


        if (collision.gameObject.layer == 6)
        {
            Destroy(this.gameObject);

        }


        if (myenemy != null)
        {
            myenemy.life -= damage;
            Destroy(this.gameObject);

        }

    }

}
