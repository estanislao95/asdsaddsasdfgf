using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    [SerializeField]
    FPSWallrun wallrun;

    [SerializeField]
    private float sensx;
    [SerializeField]
    private float sensy;

    Camera cam;

    float mX;
    float mY;

    float Mul = 0.01f;

    float RotX;
    float RotY;


    void Start()
    {

        cam = GetComponentInChildren<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {
        Camcontoler();

        cam.transform.localRotation = Quaternion.Euler(RotX, 0, wallrun.tilt);
        transform.rotation = Quaternion.Euler(0, RotY, 0);
    }

    void Camcontoler()
    {

        mY = Input.GetAxisRaw("Mouse Y");
        mX = Input.GetAxisRaw("Mouse X");


        RotY += mX * sensx * Mul;
        RotX -= mY * sensy * Mul;


        RotX = Mathf.Clamp(RotX,-90f,90f);

    }
     
}
