using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPoint : MonoBehaviour
{

    public float speed;
    public Transform waypoints;
    int currentindex;

    public bool trigger = false;

    void Start()
    {
        
    }


    void Update()
    {

        if (trigger == true)
        {
            Vector3 dir = waypoints.position - transform.position;
            dir.Normalize();


            transform.position += dir * speed * Time.deltaTime;

        }

        if (transform.position == waypoints.position)
        {
            trigger = false;
        }

       // Vector3 myPos = transform.position;
       // myPos.x = 0;
       // myPos.y = 0;
       // myPos.z = 0;
       // Vector3 waypointPos = waypoints[currentindex].position;
       // waypointPos.x = 0;
       // waypointPos.y = 0;
       // waypointPos.z = 0;

        //float distance = Vector3.Distance(waypointPos, myPos);



    }
}
