using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Camera Cam;
    [Space]
    public ParticleSystem MuzzleFlash;
    public GameObject GroundImpact;
    public GameObject FleshImpact;
    public AudioSource GunShot;
    [Space]
    public float Dmg = 25;
    public float WaitTime;

    private float _waitTill = -999f;

    // Start is called before the first frame update
    void Start() {

    }

    public void Shoot() {
        if (!Input.GetMouseButtonDown(0) ) return;
        if (Time.time <= _waitTill) return;

        _waitTill = Time.time + WaitTime;

        //play sound
        GunShot.Play();

        //muzzle flash
        MuzzleFlash.Play();

        RaycastHit hit;
        if (!Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, Mathf.Infinity)) return;
        Debug.Log(hit.transform.name);

        //check if collider is enemy type
        if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Enemy")) {
            hit.collider.GetComponent<EnemyController>().TakeDamage(Dmg);
            //reduce health 

        }

        //hit effect
        if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Enemy")) {
            GameObject ImpactGO = Instantiate(FleshImpact, hit.point, Quaternion.LookRotation(hit.normal));
            ImpactGO.transform.parent = hit.collider.gameObject.transform;
            ImpactGO.GetComponent<ParticleSystem>().Play();
            Destroy(ImpactGO, 2f);
        } else { //hits floor or something 
            GameObject ImpactGO = Instantiate(GroundImpact, hit.point, Quaternion.LookRotation(hit.normal));
            ImpactGO.transform.parent = hit.collider.gameObject.transform;
            ImpactGO.GetComponent<ParticleSystem>().Play();
            Destroy(ImpactGO, 2f);
        }
    }
}
