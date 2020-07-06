using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SalamanderMovement : EnemyBehavior
{
    private Vector3 JumpBackPosition;
    private float _oldSpeed;
    private float _oldAngularSpeed;
    private bool _jumpBack;
    private bool hasTarget;
    private float _jumpBacktimer;

    [HideInInspector]
    public bool NormalAttack;

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

    private float Timer;
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agent = gameObject.GetComponent<NavMeshAgent>();
        _jumpBack = false;
        hasTarget = false;
        _jumpBacktimer = JumpBackTimer;
        _oldSpeed = agent.speed;
        _oldAngularSpeed = agent.angularSpeed;
        //weapon = gameObject.GetComponentInChildren<GameObject>();
        Attack = true;
        _attackTimer = AttackTimer;
        TestDying = false;
        agent.isStopped = false;
        Timer = 0.3f;
        EnemyAnimator = gameObject.GetComponentInChildren<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (TestJumpBack)
        {
            TestJumpBack = false;
            _jumpBack = true;
        }
        // Debug.Log(agent.remainingDistance);
        CheckIfDead();
        if (!_jumpBack && !RangedAttack)
        {

            agent.destination = Target.position;
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
            if(!RangedAttack && !_jumpBack && !NormalAttack)
            {
                agent.isStopped = false;
                Timer -= Time.deltaTime;
                //Debug.Log(Timer);
                Debug.Log(_oldAngularSpeed);
                if (Timer <= 0)
                {
                    agent.angularSpeed = _oldAngularSpeed;
                    Timer = 0.3f;
                }

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
                agent.isStopped = true;
                Debug.Log("JumpbackDone");
                _jumpBack = false;
                _jumpBacktimer = JumpBackTimer;
                agent.speed = _oldSpeed;
                Attack = true;
                Timer = 0.3f;
            }
            else
            {
                _jumpBacktimer -= Time.deltaTime;
                Vector3 JumpBackDirection = transform.position + -transform.forward;
                //JumpBackDirection.Normalize();
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

    //private void OnTriggerEnter(Collider other)
    //{
    //    NavMeshHit point;
    //    if (other.CompareTag("Player") && _attackcooldown <= 0 && !agent.Raycast(target.position, out point))
    //    {
    //        RangedAttack = true;
    //        agent.isStopped = true;
    //    }
    //}
}
