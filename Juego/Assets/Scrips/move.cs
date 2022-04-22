using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class move : MonoBehaviour
{
    public float walkpseed = 4f;
    public float roatationspeed = 180;
    public Rigidbody rigid;
    public float jumpspeed = 10;

    public float maxlife = 0;
    public float currentlife = 0;

    public float maxarmor = 0;
    public float currentarmor = 0;

    public float MaxAirSpeed = 2;


    [HideInInspector]
    public bool isjump = true;
    [HideInInspector]
    public bool onair = true;

    [HideInInspector]
    public int speedboost = 0;
    [HideInInspector]
    float speedtimer = 0;

    [SerializeField]
    Transform orientation;

    public float run = 0;

    public int jumpamount = 0;


    public Image lifebar;
    public Image armor;

    [HideInInspector]
    public Vector3 inputVector;




    public float distance = 1;

    bool Fw = false;
    bool Rw = false;
    bool Lw = false;
    bool Riw = false;

    public LayerMask Ground;

    //public Rigidbody cam;



    // public float dash_timer = 0;
    // public int dash_amount = 0;
    // int dash_amount_max = 0;
    // public int dashon = 0;
    // public float dashtimer = 0;
    // public float refilltimer = 0;
    // public float refilltimermax = 0;





    // Start is called before the first frame update
    void Start()
    {
        currentlife = maxlife;
        currentarmor = maxarmor;

    }



    public void hitdect()
    {
      Fw =  Physics.Raycast(transform.position, orientation.forward, distance, Ground);

      Rw = Physics.Raycast(transform.position, -orientation.forward, distance, Ground);


      Lw = Physics.Raycast(transform.position, orientation.right, distance, Ground);

      Riw = Physics.Raycast(transform.position, -orientation.right, distance, Ground);

    }





    void Update()
    {
        hitdect();
        jumplogic();
        //dash();

        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;

        currentlife = currentlife > maxlife ? maxlife : currentlife;
        currentarmor = currentarmor > maxarmor ? maxarmor : currentarmor;


        lifebar.fillAmount = (currentlife / maxlife);
        armor.fillAmount = (currentarmor / maxarmor);





    }
    




    // void dash()
    // {
    //     if (dashon == 1)
    //     {
    //         refilltimer += Time.deltaTime;
    //         inputVector.y += dash_amount;
    //
    //         if (refilltimer >= refilltimermax)
    //         {
    //             dashon = 0;
    //             refilltimer = 0;
    //
    //         }
    //
    //     }
    //
    //     Debug.Log(dashon);
    //
    //     if (Input.GetKeyDown(KeyCode.LeftShift) && dashon == 0
    //     && Input.GetKey(KeyCode.W))
    //     {
    //
    //         dashon = 1;
    //
    //     }
    //
    //
    //
    //
    // }




    void movement()
    {





       if (Fw)
       {
           if (Input.GetAxis("Vertical") < 0)
           {
               inputVector.y = Input.GetAxis("Vertical");
           }
           else
           {
               inputVector.y = 0;
           }
       }
       else if (Rw)
       {
           if (Input.GetAxis("Vertical") > 0)
           {
               inputVector.y = Input.GetAxis("Vertical");
           }
           else
           {
               inputVector.y = 0;
           }
       }
       else
       {
           inputVector.y = Input.GetAxis("Vertical");
       }



        if (Lw)
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                inputVector.x = Input.GetAxis("Horizontal");
            }
            else
            {
                inputVector.x = 0;
            }
        }
        else if (Riw)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                inputVector.x = Input.GetAxis("Horizontal");
            }
            else
            {
                inputVector.x = 0;
            }
        }
        else
        {
            inputVector.x = Input.GetAxis("Horizontal");
        }





        //inputVector.y = Input.GetAxis("Vertical");
        //inputVector.x = Input.GetAxis("Horizontal");
        inputVector.z = 0f;












        //Debug.Log(inputVector);

        //Airmovement(inputVector);

        //  Vector3 mouseinputVector;
        //
        // mouseinputVector.x = Input.GetAxis("Mouse X");
        // mouseinputVector.y = Input.GetAxis("Mouse Y");
        // mouseinputVector.z = 0f;


        if (speedboost == 1)
        {
            speedtimer += Time.deltaTime;


            inputVector.y += run;

            if (speedtimer >= 4)
                speedboost = 0;
        }

        //transform.position += inputVector * walkpseed * Time.deltaTime;
        // transform.position += (transform.right * inputVector.y //+
        //                        //transform.forward * inputVector.x
        //                        ) 
        //                        * walkpseed * Time.deltaTime;



       // rigid.MoveRotation(rigid.rotation * Quaternion.Euler(0, mouseinputVector.x *
       //                                     roatationspeed * Time.deltaTime, 0));

    }



    private void FixedUpdate()
    {
        movement();
        if (inputVector.magnitude > 0)
        {
            rigid.MovePosition(rigid.position + (transform.right
           * inputVector.x + transform.forward * inputVector.y)
           * walkpseed * Time.deltaTime);


            


        }


    }




    void jumplogic()
    {





        if (Input.GetButtonDown("Jump") && isjump == true && jumpamount != 2)
        {
            if (onair == true)
            {
                rigid.AddForce(Vector3.up * jumpspeed * 1.05f, ForceMode.Impulse);
            }
            else
            {
                rigid.AddForce(Vector3.up * jumpspeed, ForceMode.Impulse);
            }



            jumpamount++;
            onair = true;

            //Debug.Log(jumpamount);

            if (jumpamount == 2)
            {
                isjump = false;
            }

        }

      //  if (Input.GetButtonDown("Jump") && isjump == false && doublejump == true)
      //  {
      //      Debug.Log("input");
      //      rigid.AddForce(Vector3.up * jumpspeed * 2, ForceMode.Impulse);
      //      doublejump = false;
      //  }
    }




   // void Airmovement(Vector3 Pmove)
   // {
   //
   //     Vector3 projvel = Vector3.Project(GetComponent<Rigidbody>().velocity, Pmove);
   //
   //     bool isAway = Vector3.Dot(Pmove, projvel) <= 0;
   //
   //
   //     if (projvel.magnitude < MaxAirSpeed || isAway)
   //     {
   //         Vector3 AirStrafeForce =  (0,0,0);
   //         Vector3 vc = Vector3.Normalize * AirStrafeForce;
   //
   //
   //     }
   //
   // }










    private void OnCollisionEnter(Collision collision)
    {



        if (collision.gameObject.layer == 6)
        {
            isjump = true;
            jumpamount = 0;
            onair = false;
        }

        if  (collision.gameObject.layer == 9)
        {
            isjump = true;
            jumpamount = 0;
            onair = false;
        }

    }




}
