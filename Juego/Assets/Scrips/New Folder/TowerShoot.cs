using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{


    public Transform shootpoint;
    [SerializeField]
    private float damage = 10;

    [SerializeField]
    private int Firrate = 10;
    [SerializeField]
    private float lastshoot = 0;

    public int range = 100;
    public bool trigger = false;

    public move move;
    private void Start()
    {
        //move move = GetComponent<move>();
    }


    void Update()
    {
        lastshoot += Time.deltaTime;
        Debug.DrawRay(shootpoint.position, shootpoint.forward, new Color(200,0,0));

        if (trigger == true)
        {
            shoot();
        }
    }


    private bool canshot() => lastshoot > 1f / (Firrate / 60f);

    void shoot()
    {
        if (canshot()) //aqui se empieza el disparo
        {

            move.hit(damage);
            if (Physics.Raycast(shootpoint.position, shootpoint.forward, out RaycastHit hitinfo, range,10))
            {

                

            }
            lastshoot = 0;
        }
    }
}
