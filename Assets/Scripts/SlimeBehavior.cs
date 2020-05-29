using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlimeBehavior : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;

    public int health;
    public int damage;

    public bool testdying;

    public float Timer; // The timer before starting jumpattack
    public float StopJumpAttacktime; //Timer until the slime stops its attack
    public float JumpSpeed; //sped that slime moves when it jumps

    private float _oldspeed; // speed that was set before the slime jumps
    private float _timer; // The number that counts down
    private float _stopJumpAttackTime; // the stop jump attack timer that counts down

    private bool jumpattack = false; //bool so slime knows if it needs to jump attack

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
        _timer = Timer;
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
        if(testdying)
        {
            Die();
        }
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
        jumpattack = false;
        agent.isStopped = false;
        _timer = Timer;
        agent.speed = _oldspeed;
        _stopJumpAttackTime = StopJumpAttacktime;
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
                    agent.speed = JumpSpeed;
                    agent.isStopped = false;
                    _stopJumpAttackTime = StopJumpAttacktime;
                    _timer = Timer;
                    
                }
            }
        }
        if (agent.isStopped == false)
        {
            _stopJumpAttackTime -= Time.deltaTime;
            if (_stopJumpAttackTime <= 0)
            {
                agent.isStopped = true;
                _stopJumpAttackTime = StopJumpAttacktime;
                _timer = Timer;
                agent.destination = target.position;
            }
        }
    }

    public void Die()
    {
        agent.isStopped = true;
        Object.Destroy(gameObject, 3);
    }

}
