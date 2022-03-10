using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform LookTarget;
    public float speed = 1f;
    public Vector3 PointDir;

    private void Start() {
        PointDir = transform.up;
    }

    void FixedUpdate()
    {
        //make direction negative so the sprites can get lit
        Vector3 direction = transform.position - LookTarget.position;
        
        //doesnt rotate up or down to look at object
        direction = Vector3.ProjectOnPlane(direction, Vector3.up);

        Quaternion toRotation = Quaternion.LookRotation(direction, PointDir);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, speed * Time.time);
    }
}
