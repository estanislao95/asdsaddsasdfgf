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

    private void Start()
    {

        rb = GetComponent<Rigidbody>();

    }

    void CheckW()
    {
        Wl = Physics.Raycast(transform.position, -orientation.right, out Lwallhit, wallD);

        WR = Physics.Raycast(transform.position, orientation.right, out Rwallhit, wallD); 
    }

    bool CWallRun()
    {
        return !Physics.Raycast(transform.position, Vector3.down, MinJumpHeight);
    }


    void Update()
    {
        CheckW();

        if (CWallRun())
        {
            if (Wl)
            {
                StartWR();
                Debug.Log("left"); 
            }
            else if (WR)
            {
                StartWR();
                Debug.Log("right");
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