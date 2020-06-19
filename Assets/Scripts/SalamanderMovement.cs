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

    [HideInInspector]
    public bool RangedAttack;


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
        agent.isStopped = false;
    }
    // Update is called once per frame
    void Update()
    {
        _attackcooldown -= Time.deltaTime;
        Debug.Log(agent.isStopped);
        Debug.Log(agent.remainingDistance);
        CheckIfDead();
        if (!_jumpBack && !RangedAttack)
        {

            agent.destination = target.position;
            if (agent.remainingDistance <= 1)
            {
                SalamanderAttack();
                agent.isStopped = true;
            }

            //else if (agent.remainingDistance >= 8 && agent.remainingDistance <= 12 && _attackcooldown <= 0)
            //{
            //    RangedAttack = true;
            //    agent.isStopped = true;
            //}
            if(!RangedAttack)
            { agent.isStopped = false; }
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
        Attack = true;
        _attackTimer -= Time.deltaTime;
    }

    void JumpBack()
    {
        Attack = false;
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
        //agent.isStopped = true;
        Attack = false;
    }

    public void RangeCoolDown()
    {
        _attackcooldown = AttackCoolDown;
    }

    private void OnTriggerEnter(Collider other)
    {
        NavMeshHit point;
        if (other.CompareTag("Player") && _attackcooldown <= 0 && !agent.Raycast(target.position, out point))
        {
            RangedAttack = true;
            agent.isStopped = true;
        }
    }
}
