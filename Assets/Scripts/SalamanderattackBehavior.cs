﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SalamanderattackBehavior : MonoBehaviour
{
    PlayerScriptBehavior p;
    private float _attackcooldown;
    public GameObject Fire;
    private SalamanderMovement Salamander;
    private FireTriggerScript SalamanderFire;
    private NavMeshAgent Agent;

    public float FireTimer;
    private float _fireTimer;

    public float FireRestTimer;
    private float _fireRestTimer;



    private bool _fireSpawned;

    private float _normalAttackTimer;

    public float NormalAttackTimer;

    // Start is called before the first frame update
    void Start()
    {
        Salamander = gameObject.GetComponentInParent<SalamanderMovement>();
        SalamanderFire = Salamander.GetComponentInChildren<FireTriggerScript>();
        _fireTimer = FireTimer;
        _fireRestTimer = FireRestTimer;
        _fireSpawned = false;
        _normalAttackTimer = NormalAttackTimer;
        Agent = gameObject.GetComponentInParent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Salamander.death)
        {
            _attackcooldown -= Time.deltaTime;
            if (Salamander.RangedAttack)
            {
                _fireTimer -= Time.deltaTime;
                if (_fireTimer <= 0)
                {
                    if (!_fireSpawned)
                    {
                        GameObject.Instantiate(Fire, Salamander.transform.position, Salamander.transform.rotation);
                        Debug.Log("Fire");
                        _fireSpawned = true;
                    }
                    else if (_fireSpawned)
                    {
                        _fireRestTimer -= Time.deltaTime;

                        if (_fireRestTimer <= 0)
                        {
                            Salamander.RangedAttack = false;
                            _fireSpawned = false;
                            SalamanderFire.RangeCoolDown();
                            _fireTimer = FireTimer;
                            _fireRestTimer = FireRestTimer;
                            Salamander.RangedAttackPlayed = false;
                            //Salamander.EnemyAnimator.speed = .75f;
                            Salamander.EnemyAnimator.SetFloat("Speed", 0);
                        }
                        //Salamander.EnemyAnimator.SetTrigger("AtkCancel");
                        //Salamander.EnemyAnimator.speed = 0f;
                    }
                }
            }
            if (Salamander.NormalAttack)
            {
                _normalAttackTimer -= Time.deltaTime;
                if (_normalAttackTimer <= 0)
                {
                    _attack();
                }
            }
        }
    }

    private void _attack()
    {
        p.TakeDamage(Salamander.Damage);
        Salamander.SendMessage("SetJumpbackTimer");
        //Salamander.Attack = false;
        Salamander.TestJumpBack = true;
        Agent.isStopped = true;
        Salamander.NormalAttack = false;
        _normalAttackTimer = NormalAttackTimer;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!Salamander.death)
        {
            if (Salamander.Attack)
            {
                if (other.CompareTag("PlayerHitbox"))
                {
                    Salamander.EnemyAnimator.SetTrigger("JumpAtk");
                    p = other.GetComponentInParent<PlayerScriptBehavior>();
                    Salamander.NormalAttack = true;
                    Agent.isStopped = true;
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!Salamander.death)
        {
            if (Salamander.NormalAttack)
            {
                if (other.CompareTag("PlayerHitbox"))
                {
                    Salamander.NormalAttack = false;
                    Agent.isStopped = false;
                }
            }
        }
    }
}
