using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [SerializeField] private int VC = 0;
    void start()
    {
        //Lr = GetComponent<LineRenderer>();

        

    }


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


    }

    private void LateUpdate()
    {
        drawrope();
    }

    void StartGrap()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.position, cam.forward, out hit, MGdistance, Glp))
        {
            Gp = hit.point;

            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = Gp;

            float DistanceFromP = Vector3.Distance(player.position, Gp);


            //joint.maxDistance = DistanceFromP * 0.8f;
            joint.minDistance = DistanceFromP * 0.45f;


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
        Lr.positionCount = 0;
        Destroy(joint);
    }

}
