using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{

    public Transform[] spawns = new Transform [1];

    public int count = 0;
    public basicenemy enemy;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (count == 1)
            calling();








    }


    void calling()
    {
        for (int i = 0; i < spawns.Length; i++)
        {
            basicenemy enemys = Instantiate(enemy);

            enemys.transform.position = spawns[i].transform.position;

            Debug.Log(spawns[i]);

 

            if (i <= 12)
                count = 0;
        }

    }
}
