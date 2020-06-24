using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlimeBehavior : EnemyBehavior
{

    public int damage;

    public bool testdying;

    public float WaitTimer; // The timer before starting jumpattack
    public float StopJumpAttacktime; //Timer until the slime stops its attack
    public float JumpSpeed; //sped that slime moves when it jumps

    //Private Variables
    private float _oldspeed; // speed that was set before the slime jumps
    private float _timer; // The number that counts down
    private float _stopJumpAttackTime; // the stop jump attack timer that counts down

    private bool _hasJumpattackTarget; // used so the script does not get the target again when jump attacking
    private bool _isJumpAttacking; // used to tell slime if they should stop jump attacking

    private bool jumpattack = false; //bool so slime knows if it needs to jump attack

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agent = gameObject.GetComponent<NavMeshAgent>();
        _oldspeed = agent.speed;
        _timer = WaitTimer;
        _stopJumpAttackTime = StopJumpAttacktime;
        Target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!jumpattack)
        {
            //sets the enemies destination to the target
            agent.destination = Target.position;
        }
        //This is used to tell the slime what to do when jump attack is true
        if (jumpattack)
        {
            JumpAttack();
        }

        //This is used to call the die function so dying can be tested without the player killing the slime
        if (testdying)
        {
            Die();
        }
        CheckIfDead();
    }

    void OnTriggerEnter(Collider other)
    {
        //This checks if the trigger is the trigger on the player
        if(other.gameObject.CompareTag("Player"))
        {
            if (_isJumpAttacking)
            {
                agent.isStopped = true;
            }
            jumpattack = true;
            _isJumpAttacking = true;
            
        }
        //This checks if the trigger is the trigger for the hitbox
        //if(other.gameObject.CompareTag("PlayerHitbox"))
        //{
        //    //Make the slimes hurt the player
        //    PlayerScriptBehavior p = other.GetComponentInParent<PlayerScriptBehavior>();
        //    p.TakeDamage(1);
        //}
    }

    //void OnTriggerExit(Collider other)
    //{

    //    if (other.CompareTag("Player")) //This is used to make sure that this is activating with the right trigger
    //    {
    //        if (!_isJumpAttacking)
    //        {
    //            jumpattack = false;
    //            agent.isStopped = false;
    //            _timer = WaitTimer;
    //            agent.speed = _oldspeed;
    //            _stopJumpAttackTime = StopJumpAttacktime;
    //        }
    //    }

    //}

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isJumpAttacking = false;
        }
    }

    public void JumpAttack()
    {
        Debug.Log("JumpAttack");
        if (agent.isStopped == true)
        {
            _timer -= Time.deltaTime;
            if (agent.isStopped == true)
            {
                if (_timer <= 0.0f)
                {
                    if (!_hasJumpattackTarget)
                    {
                        agent.destination = Target.position;
                        _hasJumpattackTarget = true;
                        agent.isStopped = true;
                    }
                    agent.speed = JumpSpeed;
                    agent.isStopped = false;
                    Debug.Log(agent.isStopped);
                    _stopJumpAttackTime = StopJumpAttacktime;
                    _timer = WaitTimer;
                    Debug.Log(agent.destination);
                }

            }
        }
        if (agent.isStopped == false)
        {
            _stopJumpAttackTime -= Time.deltaTime;
            if (_stopJumpAttackTime <= 0)
            {
                _hasJumpattackTarget = false;
                agent.isStopped = true;
                _stopJumpAttackTime = StopJumpAttacktime;
                _timer = WaitTimer;
                agent.destination = Target.position;
                if (!_isJumpAttacking)
                {
                    jumpattack = false;
                    agent.isStopped = false;
                    _timer = WaitTimer;
                    agent.speed = _oldspeed;
                    _stopJumpAttackTime = StopJumpAttacktime;
                }

            }
        }
    }


}
