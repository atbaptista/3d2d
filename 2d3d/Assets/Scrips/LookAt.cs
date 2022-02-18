using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform LookTarget;
    public float speed = 1f;

    void FixedUpdate()
    {
        Vector3 direction = LookTarget.position - transform.position;

        //doesnt rotate up or down to look at object
        direction = Vector3.ProjectOnPlane(direction, Vector3.up);

        Quaternion toRotation = Quaternion.LookRotation(direction, transform.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, speed * Time.time);
    }
}
