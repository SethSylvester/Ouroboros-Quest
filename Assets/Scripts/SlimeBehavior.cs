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

    public float Timer;
    public float StopJumpAttacktime;
    public float JumpSpeed;

    private float _oldspeed;
    private float _timer;
    private float _stopJumpAttackTime;

    private bool jumpattack = false;

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
        //sets the enemies destination to the target
        if (!jumpattack)
        {
            agent.destination = target.position;
        }

        if (jumpattack)
        {
            JumpAttack();
        }

        if(testdying)
        {
            Die();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            agent.isStopped = true;
            jumpattack = true;
            agent.autoRepath = false;
            agent.destination = agent.destination;

            //Make the slimes hurt the player
            PlayerScriptBehavior p = other.gameObject.GetComponent<PlayerScriptBehavior>();
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
