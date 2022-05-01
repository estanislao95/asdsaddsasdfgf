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
    public int PistolDamage = 0;

    public int machinegunammo = 0;
    public int machinegunammoMax = 0;
    public int machineGunFirerate = 0;
    public int mahcinegunRange = 0;
    public int mahcinegunDamage = 0;

    public int Shotgungunammo = 0;
    public int ShotgungunammoMax = 0;
    public int ShotgunGunFirerate = 0;
    public int ShotgungunRange = 0;
    public int ShotgungunDamage = 0;



    [SerializeField]
    int currentgunfirerrate = 0;

    [SerializeField]
    int currentgundamage = 0;

    public Text ammo;
    public Text gunindicator;


    public AudioClip PistolSound;
    public AudioClip ShotgunSound;
    public AudioClip MachineGunSound;



    public AudioSource weapon;

    public bool PistolActive = true;
    public bool MachineGunActive = true;
    public bool ShotGunActive = true;


    public Animator anims;

    void Start()
    {
        anims = GetComponentInChildren<Animator>();
        anims.SetBool("PistolEquip", true);

        machinegunammo = machinegunammoMax;
        pistolammo = pistolammoMax;
        type = 1;
        ammo.text = ("Pistol");
        gunindicator.text = ("Ammo " + pistolammo);

        currentgunfirerrate = PistolFirerate;
        currentgundamage = PistolDamage;
        weapon.clip = PistolSound;

    }

    // Update is called once per frame
    void Update()
    {
        lastshoot += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Alpha1) && PistolActive == true)
        {
            type = 1;
            ammo.text = ("Pistol");
            gunindicator.text = ("Ammo " + pistolammo);
            currentgunfirerrate = PistolFirerate;
            currentgundamage = PistolDamage;
            weapon.clip = PistolSound;
            anims.SetBool("PistolEquip", true);
            anims.SetBool("RifleEquip", false);
            anims.SetBool("ShotGunEquip", false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && MachineGunActive == true)
        {
            type = 2;
            ammo.text = ("Machine Gun");
            gunindicator.text = ("Ammo " + machinegunammo);
            currentgunfirerrate = machineGunFirerate;
            currentgundamage = machineGunFirerate;
            weapon.clip = MachineGunSound;
            anims.SetBool("RifleEquip", true);
            anims.SetBool("PistolEquip", false);
            anims.SetBool("ShotGunEquip", false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && ShotGunActive == true)
        {
            type = 3;
            ammo.text = ("Shotgun Gun");
            gunindicator.text = ("Ammo " + Shotgungunammo);
            currentgunfirerrate = ShotgunGunFirerate;
            currentgundamage = ShotgungunDamage;
            weapon.clip = ShotgunSound;
            anims.SetBool("ShotGunEquip", true);
            anims.SetBool("RifleEquip", false);
            anims.SetBool("PistolEquip", false);

        }


        if (Input.GetKey(KeyCode.Mouse0) && pistolammo >= 0 && type == 1 && PistolActive == true)
        {
            Pshot();
            anims.SetBool("PistolShoot", true);
        }
        else
        {
            anims.SetBool("PistolShoot", false);
        }
        if (Input.GetKey(KeyCode.Mouse0) && machinegunammo >= 0 && type == 2 && MachineGunActive == true)
        {
            Pshot();
            anims.SetBool("RifleShoot", true);
        }
        else
        {
            anims.SetBool("RifleShoot", false);
        }
        if (Input.GetKey(KeyCode.Mouse0) && machinegunammo >= 0 && type == 3 && ShotGunActive == true)
        {
            Pshot();
            anims.SetBool("ShotGunShoot", true);
        }
        else
        {
            anims.SetBool("ShotGunShoot", false);
        }

        machinegunammo = machinegunammo > machinegunammoMax ? machinegunammoMax : machinegunammo;
        pistolammo = pistolammo > pistolammoMax ? pistolammoMax : pistolammo;

    }

    private bool canshot() => lastshoot > 1f /(currentgunfirerrate / 60f);


    private void Pshot()
    {
        if (canshot()) //aqui se empieza el disparo
        {
            
            weapon.Play();
            //aqui esta para añadir nuevos enemigos
            if (Physics.Raycast(shotpivot.position, shotpivot.forward, out RaycastHit hitinfo, PistolRange))
            {
                basicenemy enemy = hitinfo.transform.GetComponent<basicenemy>();
                enemy?.hit(currentgundamage);
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
            if (type == 3)
            {
                gunindicator.text = ("Ammo " + Shotgungunammo);
                Shotgungunammo--;
                lastshoot = 0;
            }


        }


    }

}
