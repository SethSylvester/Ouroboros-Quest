using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SalamanderMovement : EnemyBehavior
{
    private Transform target;
    private Vector3 JumpBackPosition;
    private float _oldSpeed;
    private float _oldAngularSpeed;
    private bool _jumpBack;
    private bool hasTarget;
    private float _jumpBacktimer;
    private float _attackcooldown;
    private GameObject weapon;
    private float _attackTimer;

    private float _waitTimer;

    [HideInInspector]
    public bool Attack;

    public float WaitTimer;

    public bool TestJumpBack;
    public float JumpBackTimer;
    public float JumpBackSpeed;
    public float AttackCoolDown;
    public float AttackTimer;
    public int Damage;

    public bool TestDying;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agent = gameObject.GetComponent<NavMeshAgent>();
        _jumpBack = false;
        hasTarget = false;
        _jumpBacktimer = JumpBackTimer;
        _attackcooldown = 0;
        _oldSpeed = agent.speed;
        _oldAngularSpeed = agent.angularSpeed;
        //weapon = gameObject.GetComponentInChildren<GameObject>();
        Attack = true;
        _attackTimer = AttackTimer;
        TestDying = false;
    }
    // Update is called once per frame
    void Update()
    {
        CheckIfDead();
        if (!_jumpBack)
        {
            agent.destination = target.position;
            if (agent.remainingDistance <= 1)
            {
                SalamanderAttack();
            }

            if(agent.remainingDistance >= 4 && agent.remainingDistance <= 5)
            {

            }
        }
        if(TestDying)
        {
            Die();
        }
        if (_jumpBack)
        {
            JumpBack();
        }
        if (TestJumpBack)
        {
            TestJumpBack = false;
            _jumpBack = true;
        }
    }

    void SalamanderAttack()
    {
        _attackTimer -= Time.deltaTime;
    }

    void JumpBack()
    {
        if (_waitTimer <= 0)
        {
            if(agent.isStopped == true)
            {
                agent.isStopped = false;
            }

            NavMeshHit point;
            Vector3 sourcePosition = transform.position + -transform.forward;
            if (NavMesh.Raycast(agent.transform.position, sourcePosition, out point, 1) || _jumpBacktimer <= 0)
            {
                Debug.Log("JumpbackDone");
                _jumpBack = false;
                _jumpBacktimer = JumpBackTimer;
                agent.speed = _oldSpeed;
                agent.angularSpeed = _oldAngularSpeed;
                Attack = true;
            }
            else
            {
                _jumpBacktimer -= Time.deltaTime;
                Vector3 JumpBackDirection = transform.position + -transform.forward;
                agent.angularSpeed = 0;
                agent.speed = JumpBackSpeed;
                agent.destination = JumpBackDirection;
            }
        }
        else
        {
            _waitTimer -= Time.deltaTime;
        }
    }

    void SetJumpbackTimer()
    {
        _waitTimer =  WaitTimer;
        agent.isStopped = true;
        Attack = false;
    }

}
