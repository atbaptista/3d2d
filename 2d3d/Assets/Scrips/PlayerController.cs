using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerShoot ShootScript;

    private float _health = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootScript.Shoot();
    }

    public void TakeDamage(float dmg) {
        _health -= dmg;
        Debug.Log(_health);
    }
}
