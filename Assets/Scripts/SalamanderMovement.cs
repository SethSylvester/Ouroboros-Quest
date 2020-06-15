using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SalamanderMovement : EnemyBehavior
{
    private Transform target;
    private NavMeshAgent Salamander;
    private Vector3 JumpBackPosition;
    private float _oldSpeed;
    private float _oldAngularSpeed;
    private bool _jumpBack;
    private bool hasTarget;
    private float _jumpBacktimer;
    private float _attackcooldown;
    private GameObject weapon;
    private float _attackTimer;

    [HideInInspector]
    public bool Attack;

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
        Salamander = gameObject.GetComponent<NavMeshAgent>();
        _jumpBack = false;
        hasTarget = false;
        _jumpBacktimer = JumpBackTimer;
        _attackcooldown = 0;
        _oldSpeed = Salamander.speed;
        _oldAngularSpeed = Salamander.angularSpeed;
        //weapon = gameObject.GetComponentInChildren<GameObject>();
        Attack = false;
        _attackTimer = AttackTimer;
        TestDying = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (!_jumpBack)
        {
            Salamander.destination = target.position;
            if (Salamander.remainingDistance <= 1)
            {
                SalamanderAttack();
            }

            //if (Attack)
            //{
            //    SalamanderAttack();
            //}
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
        if (_attackcooldown <= 0)
        {
            Attack = true;
            _attackTimer -= Time.deltaTime;
            //if(AttackTimer <= 0)
            //{
                
                _attackcooldown = AttackCoolDown;
                _attackTimer = AttackTimer;
            //}
        }
        if (_attackcooldown > 0)
        {
            _attackcooldown -= Time.deltaTime;
        }
    }

    void JumpBack()
    {
        NavMeshHit point;
        Vector3 sourcePosition = transform.position + -transform.forward;
        if (_jumpBacktimer <= 0 || !NavMesh.SamplePosition(sourcePosition, out point, 1, NavMesh.GetAreaFromName("Walkable")))
        {
            Debug.Log("JumpbackDone");
            _jumpBack = false;
            _jumpBacktimer = JumpBackTimer;
            Salamander.speed = _oldSpeed;
            Salamander.angularSpeed = _oldAngularSpeed;
        }
        else
        {
            _jumpBacktimer -= Time.deltaTime;
            Vector3 JumpBackDirection = transform.position + -transform.forward;
            Salamander.angularSpeed = 0;
            Salamander.speed = JumpBackSpeed;
            Salamander.destination = JumpBackDirection;
            Salamander.destination = JumpBackDirection;
        }
    }

}
