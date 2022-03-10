using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private enum EnemyState {
        ATTACK,
        IDLE,
        DIE
    }

    public GameObject Player;
    [Space]
    public Sprite[] SpriteArray;
    [Space]
    public float AttackRange = 3f;
    public float AttackSpeed = 1f;
    public float AttackDmg = 15f;

    private NavMeshAgent _navAgent;
    private EnemyState _state;
    private SpriteRenderer _sprites;
    private LookAt _lookScript;
    [Space]
    [SerializeField]
    private float _health = 30;
    [SerializeField]
    private float _moveSpeed = 6;
    private float _waitTill = -999f;


    // Start is called before the first frame update
    void Start()
    {
        _sprites = GetComponent<SpriteRenderer>();
        _navAgent = GetComponent<NavMeshAgent>();
        _lookScript = GetComponent<LookAt>();

        _navAgent.speed = _moveSpeed;

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
                attack();
                break;
            case EnemyState.DIE:
                die();
                break;
        }
    }

    private void attack() {
        if (_health <= 0) {
            _state = EnemyState.DIE;
            return;
        }

        Vector3 distanceToPlayer = Player.transform.position - transform.position;

        //too far from player and not attacking
        if (distanceToPlayer.magnitude > AttackRange && Time.time > _waitTill) {
            _navAgent.SetDestination(Player.transform.position);
            return;
        }

        //damage player, set timer on attack
        if (Time.time <= _waitTill) return;
        _waitTill = Time.time + AttackSpeed;
        Player.GetComponent<PlayerController>().TakeDamage(AttackDmg);
    }
    private void idle() {

    }
    private void die() {
        _navAgent.isStopped = true;
        _sprites.sprite = SpriteArray[0];
    }

    public void TakeDamage(float dmg) {
        _health -= dmg;
    }
}
