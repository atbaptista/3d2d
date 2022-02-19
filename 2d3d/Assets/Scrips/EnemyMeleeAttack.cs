using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMeleeAttack : EnemyAttackScript
{
    public GameObject Player;

    private NavMeshAgent _navAgent;

    public float AttackRange = 3f;
    public float AttackSpeed = 1f;
    public float AttackDmg = 15f;

    private float _waitTill = -999f;

    public void Start() {
        _navAgent = GetComponent<NavMeshAgent>();
    }

    public override void Attack() {

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
}
