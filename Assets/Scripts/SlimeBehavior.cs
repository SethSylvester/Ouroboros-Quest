using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlimeBehavior : EnemyBehavior
{
    //Public Variables
    public Transform target;

    public GameObject itemDropTest;

    public int damage;

    public bool testdying;

    public float WaitTimer; // The timer before starting jumpattack
    public float StopJumpAttacktime; //Timer until the slime stops its attack
    public float JumpSpeed; //sped that slime moves when it jumps

    //Private Variables
    private float _oldspeed; // speed that was set before the slime jumps
    private float _timer; // The number that counts down
    private float _stopJumpAttackTime; // the stop jump attack timer that counts down

    private bool HasJumpattackTarget;

    private bool jumpattack = false; //bool so slime knows if it needs to jump attack

    private int randMax = 20;
    private int randMin = 0;

    public Material Green;
    public Material Red;
    private MeshRenderer mesh;
    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        mesh = gameObject.GetComponent<MeshRenderer>();
        mesh.material = Green;
        _oldspeed = agent.speed;
        _timer = WaitTimer;
        _stopJumpAttackTime = StopJumpAttacktime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!jumpattack)
        {
            //sets the enemies destination to the target
            agent.destination = target.position;
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
            agent.isStopped = true;
            jumpattack = true;
            agent.autoRepath = false;
            agent.destination = agent.destination;

            
        }
        //This checks if the trigger is the trigger for the hitbox
        if(other.gameObject.CompareTag("PlayerHitbox"))
        {
            //Make the slimes hurt the player
            PlayerScriptBehavior p = other.GetComponentInParent<PlayerScriptBehavior>();
            p.TakeDamage(1);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jumpattack = false;
            agent.isStopped = false;
            _timer = WaitTimer;
            agent.speed = _oldspeed;
            _stopJumpAttackTime = StopJumpAttacktime;
        }
    }

    public void JumpAttack()
    {
        if (agent.isStopped == true)
        {
            _timer -= Time.deltaTime;

            if (agent.isStopped == true)
            {
                if (_timer <= 0.0f)
                {
                    if (!HasJumpattackTarget)
                    {
                        agent.destination = target.position;
                        HasJumpattackTarget = true;
                    }
                    agent.speed = JumpSpeed;
                    agent.isStopped = false;
                    _stopJumpAttackTime = StopJumpAttacktime;
                    _timer = WaitTimer;
                }
                
            }
        }
        if (agent.isStopped == false)
        {
            _stopJumpAttackTime -= Time.deltaTime;
            if (_stopJumpAttackTime <= 0)
            {
                HasJumpattackTarget = false;
                agent.isStopped = true;
                _stopJumpAttackTime = StopJumpAttacktime;
                _timer = WaitTimer;
                agent.destination = target.position;
            }
        }
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }

    public override void Die()
    {
        agent.isStopped = true;
        ItemDrop();
        UnityEngine.Object.Destroy(gameObject, 3);
    }

    void ItemDrop()
    {
        //Creates the random number to determine drops
        //Random randPicker = new Random();
        //int randItem = randPicker.Next(randMin, randMax);

        GameObject itemDrop = Instantiate(itemDropTest);
    }
}
