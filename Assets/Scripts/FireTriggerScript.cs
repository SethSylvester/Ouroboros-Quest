using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FireTriggerScript : MonoBehaviour
{
    private SalamanderMovement Salamander;
    private NavMeshAgent agent;
    public float AttackCooldown;
    private float _attackcooldown;

    // Start is called before the first frame update
    void Start()
    {
        Salamander = gameObject.GetComponentInParent<SalamanderMovement>();
        agent = gameObject.GetComponentInParent<NavMeshAgent>();
        _attackcooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _attackcooldown -= Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!Salamander.death)
        {
            NavMeshHit point;
            if (other.CompareTag("Player") && _attackcooldown <= 0 && !agent.Raycast(agent.destination, out point))
            {
                if (!Salamander.RangedAttackPlayed)
                {
                    Salamander.EnemyAnimator.SetTrigger("FireAtk");
                    Salamander.RangedAttackPlayed = true;
                }
                Salamander.RangedAttack = true;
                agent.isStopped = true;
            }
        }
    }
    public void RangeCoolDown()
    {
        _attackcooldown = AttackCooldown;
    }
}
