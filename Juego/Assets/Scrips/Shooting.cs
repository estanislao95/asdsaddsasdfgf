using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{




    public Transform shotpivot;



    public int type = 0;
    
    float lastshoot = 0;

    public int pistolammo = 0;
    public int pistolammoMax = 0;
    public int PistolFirerate = 0;
    public int PistolRange = 0;

    public int machinegunammo = 0;
    public int machinegunammoMax = 0;
    public int machineGunFirerate = 0;
    public int mahcinegunRange = 0;

    [SerializeField]
    int currentgunfirerrate = 0;

    public Text ammo;
    public Text gunindicator;

    void Start()
    {

        machinegunammo = machinegunammoMax;
        pistolammo = pistolammoMax;
        type = 1;
        ammo.text = ("Pistol");
        gunindicator.text = ("Ammo " + pistolammo);

        currentgunfirerrate = PistolFirerate;

    }

    // Update is called once per frame
    void Update()
    {
        lastshoot += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            type = 1;
            ammo.text = ("Pistol");
            gunindicator.text = ("Ammo " + pistolammo);
            currentgunfirerrate = PistolFirerate;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            type = 2;
            ammo.text = ("Machine Gun");
            gunindicator.text = ("Ammo " + machinegunammo);
            currentgunfirerrate = machineGunFirerate;
        }
        // if (Input.GetKeyDown(KeyCode.Alpha3))
        // {
        //     type = 3;
        //
        // }


        if (Input.GetKey(KeyCode.Mouse0) && pistolammo >= 0 && type == 1)
        {
            Pshot();
        }

        if (Input.GetKey(KeyCode.Mouse0) && machinegunammo >= 0 && type == 2)
        {
            Pshot();
        }



















        // if (Input.GetKey(KeyCode.Mouse0) && type == 1 && pistolammo >= 0)
        // {
        //     fireratetimer += Time.deltaTime;
        //     gunindicator.text = ("Ammo " + pistolammo);
        //
        //     if (fireratetimer >= 0.3f)
        //     {
        //
        //         Rigidbody bulletClone = (Rigidbody)Instantiate(pistol, transform.position, transform.rotation);
        //
        //
        //
        //         bulletClone.transform.position = shotpivot.position;
        //         bulletClone.velocity = transform.forward * speed;
        //
        //         fireratetimer = 0;
        //         pistolammo--;
        //     }
        //
        //
        //
        //
        // }
        //
        // if (Input.GetKey(KeyCode.Mouse0) && type == 2 && machinegunammo >= 0)
        // {
        //     fireratetimer += Time.deltaTime;
        //     gunindicator.text = ("Ammo " + machinegunammo);
        //
        //     if (fireratetimer >= 0.1f)
        //     {
        //
        //         Rigidbody bulletClone1 = (Rigidbody)Instantiate(machinegun, transform.position, transform.rotation);
        //
        //
        //
        //         bulletClone1.transform.position = shotpivot.position;
        //         bulletClone1.transform.rotation = shotpivot.rotation;
        //         bulletClone1.velocity = transform.forward * speed;
        //
        //         fireratetimer = 0;
        //         machinegunammo--;
        //     }
        //
        //
        //
        //
        // }


        // if (Input.GetKeyDown(KeyCode.Mouse0) && type == 3)
        // {
        //     Rigidbody bulletClone = (Rigidbody)Instantiate(bullet, transform.position, transform.rotation);
        //
        //
        //
        //     bulletClone.transform.position = shotpivot.position;
        //     bulletClone.velocity = transform.right * speed;
        //
        //
        //
        // }

        machinegunammo = machinegunammo > machinegunammoMax ? machinegunammoMax : machinegunammo;
        pistolammo = pistolammo > pistolammoMax ? pistolammoMax : pistolammo;

    }

    private bool canshot() => lastshoot > 1f /(currentgunfirerrate / 60f);


    private void Pshot()
    {
        if (canshot())
        {
            Debug.Log("pew");
            if (Physics.Raycast(shotpivot.position, shotpivot.forward, out RaycastHit hitinfo, PistolRange))
            {
                Debug.Log(hitinfo.transform.name);

            }



            if (type == 1)
            {
                gunindicator.text = ("Ammo " + pistolammo);
                pistolammo--;
                lastshoot = 0;
            }
            if (type == 2)
            {
                gunindicator.text = ("Ammo " + machinegunammo);
                machinegunammo--;
                lastshoot = 0;
            }

        }


    }

}
