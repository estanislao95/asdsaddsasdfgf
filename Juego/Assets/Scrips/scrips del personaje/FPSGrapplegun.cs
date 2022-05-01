using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FPSGrapplegun : MonoBehaviour
{

    //private LineRenderer Lr;
    public LineRenderer Lr;
    private Vector3 Gp;
    public LayerMask Glp;
    public Transform Guntip;
    public Transform cam;
    public Transform player;

    [SerializeField]
    private float MGdistance = 0;

    private SpringJoint joint;


    [SerializeField] private float spring = 0;
    [SerializeField] private float damper = 0;
    [SerializeField] private float masscale = 0;


    public FPSWallrun Wr;

    public RawImage CrossHair;


    public Color rojo;
    public Color negro;
    public Color verde;

    public bool active = true;


    void Update()
    {
        

        if (Input.GetMouseButtonDown(1))
        {
            StartGrap();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            StopGrap();
        }




        if (Physics.Raycast(cam.position, cam.forward, 999, Glp) && active)
        {
            if (Physics.Raycast(cam.position, cam.forward, MGdistance, Glp))
            {

                CrossHair.color = verde;
            }
            else
            {
                CrossHair.color = rojo;
            }
        }
        else
        {
            if (active == true)
            {
                CrossHair.color = negro;
            }

        }
    }

    private void LateUpdate()
    {
        drawrope();
    }

    void StartGrap()
    {
        //Wr.Gh = 1;
        RaycastHit hit;
        if (Physics.Raycast(cam.position, cam.forward, out hit, MGdistance, Glp))
        {
            Gp = hit.point;

            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = Gp;

            float DistanceFromP = Vector3.Distance(player.position, Gp);


            joint.maxDistance = DistanceFromP * 0.5f;
            joint.minDistance = DistanceFromP * 0.2f;


            joint.spring = spring;
            joint.damper = damper;
            joint.massScale = masscale;

            Lr.positionCount = 2;

        }



    }



    void drawrope()
    {
        if (!joint) return;

        Lr.SetPosition(0, Guntip.position);
        Lr.SetPosition(1, Gp);
    }



    public bool isgrapling()
    {
        return joint != null;
    }

    public Vector3 CurrentGp()
    {
        return Gp;
    }

    void StopGrap()
    {
        Destroy(joint);
        Lr.positionCount = 0;

    }

    private void OnCollisionEnter(Collision collision)
    {



        if (collision.gameObject.layer == 6)
        {

            Wr.Gh = 0;
        }



    }

}
