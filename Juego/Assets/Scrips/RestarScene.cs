using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RestarScene : MonoBehaviour
{

  // public void PlayLevelOne()
  // {
  //     SceneManager.LoadScene("level 1");
  // }



    private void OnTriggerEnter(Collider collision)
    {
        move move = collision.GetComponent<move>();

        if (move != null)
        {
            SceneManager.LoadScene("SampleScene");

        }
    }
}
