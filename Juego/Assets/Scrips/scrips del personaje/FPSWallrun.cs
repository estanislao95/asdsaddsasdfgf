using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSWallrun : MonoBehaviour
{

    [SerializeField]
    Transform orientation;

    [SerializeField]
    float wallD = 0.5f;
    [SerializeField]
    float MinJumpHeight = 1.5f;

    bool Wl = false;
    bool WR = false;

    private Rigidbody rb;

    [SerializeField]
    private float WRGravity;

    [SerializeField]
    private float WRJumpForce;

    RaycastHit Lwallhit;
    RaycastHit Rwallhit;

    [SerializeField] private Camera cam;
    [SerializeField] private float Fov;
    [SerializeField] private float WRFov;
    [SerializeField] private float WRFovTime;
    [SerializeField] private float CamTilt;
    [SerializeField] private float CamTiltTime;

    [HideInInspector]
    public float tilt = 0;

    [HideInInspector]
    public int Gh = 0;

    public LayerMask Walls;

    move move;

    //int freezemove = 0;
    //int cfreezed = 0;
    //bool triggered = false;

    private void Start()
    {
        move = GetComponent<move>();
        rb = GetComponent<Rigidbody>();

    }

    void CheckW()
    {
        Wl = Physics.Raycast(transform.position, -orientation.right, out Lwallhit, wallD, Walls);

        WR = Physics.Raycast(transform.position, orientation.right, out Rwallhit, wallD, Walls); 
    }

    bool CWallRun()
    {
        return !Physics.Raycast(transform.position, Vector3.down, MinJumpHeight);
    }


    void Update()
    {

        CheckW();

        if (CWallRun() && rb.velocity.magnitude <= 23f)
        {

            if (Wl)
            {
                StartWR();

            }
            else if (WR)
            {
                StartWR();

            }
            else
            {
                EndWR();
            }
        }
        else
        {
            EndWR();
        }
    }


    void StartWR()
    {
        rb.useGravity = false;



        

        rb.AddForce(Vector3.down * WRGravity, ForceMode.Force);

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, WRFov, WRFovTime * Time.deltaTime);

        if (Wl)
            tilt = Mathf.Lerp(tilt, -CamTilt, CamTiltTime * Time.deltaTime);
        else if (WR)
            tilt = Mathf.Lerp(tilt, CamTilt, CamTiltTime * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Wl)
            {
                Vector3 WrJumpD = transform.up + Lwallhit.normal;
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.AddForce(WrJumpD * WRJumpForce * 100, ForceMode.Force);

            }
            else if (true)
            {
                Vector3 WrJumpD = transform.up + Rwallhit.normal;
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.AddForce(WrJumpD * WRJumpForce * 100, ForceMode.Force);
            }
        }
    }
    void EndWR()
    {
        rb.useGravity = true;

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, Fov, WRFovTime * Time.deltaTime);

        tilt = Mathf.Lerp(tilt, 0, CamTiltTime * Time.deltaTime);

    }

}
