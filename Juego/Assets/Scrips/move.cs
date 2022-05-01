using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    [HideInInspector]
    public float WallR;

    public AudioSource walking;



    bool walk = false;
    bool wallrs = false;

    [HideInInspector]
    public bool onwallr = false;

    FPSWallrun FPSwallrun;

    // Start is called before the first frame update
    void Start()
    {
        currentlife = maxlife;
        currentarmor = maxarmor;

        FPSwallrun = GetComponent<FPSWallrun>();
    }



    public void hitdect()
    {
      Fw =  Physics.Raycast(transform.position, orientation.forward, distance, Ground);

      Rw = Physics.Raycast(transform.position, -orientation.forward, distance, Ground);


      Lw = Physics.Raycast(transform.position, orientation.right, distance + WallR, Ground);

      Riw = Physics.Raycast(transform.position, -orientation.right, distance + WallR, Ground);

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

        if (currentlife <= 0)
        {
            SceneManager.LoadScene("muerte");
        }



    }

    public void hit(float damage)
    {
        if (currentarmor <= 0)
        {
            currentlife -= damage;
        }
        else
        {
            currentarmor -= damage / 2;
        }




    }




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
            if (Input.GetAxis("Horizontal") < 0 && onwallr == false)
            {
                inputVector.x = Input.GetAxis("Horizontal");
            }
            else
            {
                inputVector.x = 0;
            }
            wallrs = true;
        }
        else if (Riw)
        {
            if (Input.GetAxis("Horizontal") > 0 && onwallr == false)
            {
                inputVector.x = Input.GetAxis("Horizontal");
            }
            else
            {
                inputVector.x = 0;
            }
            wallrs = true;
        }
        else
        {
            inputVector.x = Input.GetAxis("Horizontal");
            wallrs = false;
        }


        inputVector.z = 0f;




        if (speedboost == 1)
        {
            speedtimer += Time.deltaTime;


            inputVector.y += run;

            if (speedtimer >= 4)
                speedboost = 0;
        }

    }



    private void FixedUpdate()
    {
        movement();
        if (inputVector.magnitude > 0)
        {
            rigid.MovePosition(rigid.position + (transform.right
           * inputVector.x + transform.forward * inputVector.y)
           * walkpseed * Time.deltaTime);

            if (walk == false && onair == false && wallrs == false)
            {
                walking.Play();
                walk = true;
            }
            else if (walk == true && onair == true) 
            {
                walking.Stop();
                walk = false;
            }
            else if (walk == true && wallrs == true)
            {
                walking.Stop();
                walk = false;
            }


        }
        else
        {
            walk = false;
            walking.Stop();
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
            if (jumpamount == 2)
            {
                isjump = false;
            }

        }
    }



    private void OnCollisionEnter(Collision collision)
    {



        if (collision.gameObject.layer == 6)
        {
            isjump = true;
            jumpamount = 0;
            onair = false;
            FPSwallrun.WrCount = 0;
        }

        if  (collision.gameObject.layer == 9)
        {
            isjump = true;
            jumpamount = 0;
            onair = false;
        }

    }



 


}
