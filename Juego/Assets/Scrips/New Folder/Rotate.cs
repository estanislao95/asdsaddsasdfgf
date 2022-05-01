using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public Transform Target;

    // Update is called once per frame
    void Update()
    {
        Vector3 TargetOr = Target.position - transform.position;
        Debug.DrawRay(transform.position, TargetOr);

        Quaternion targetOrientationQuaternion = Quaternion.LookRotation(TargetOr);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetOrientationQuaternion, 13*Time.deltaTime);
    }
}
