using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private enum EnemyState {
        ATTACK,
        IDLE,
        DIE
    }

    public EnemyAttackScript AttackScript;

    [SerializeField]
    private float _health = 100f;
    private EnemyState _state;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _state = EnemyState.ATTACK;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_state) {
            case EnemyState.IDLE:
                idle();
                break;
            case EnemyState.ATTACK:
                AttackScript.Attack();
                break;
            case EnemyState.DIE:
                die();
                break;
        }
    }

    private void attack() {

    }
    private void idle() {

    }
    private void die() {

    }

    public void TakeDamage(float dmg) {
        _health -= dmg;
    }
}
