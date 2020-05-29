using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoblinMovementBehavior : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent agent;
    private float _oldspeed;
    private float _timer;
    private float _stopJumpAttackTime;

    public float Timer;
    public float ChargeSpeed;
    public bool Charge;
    public int Damage;

    // Charges the player if there is line of sight.
    // has short cooldown after charging.
    // Will not change direction.

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = gameObject.GetComponent<NavMeshAgent>();
        _oldspeed = agent.speed;
    }

    // Update is called once per frame
    void Update()
    {
        NavMeshHit hit;
        if (Charge)
        {
            
            _timer -= Time.deltaTime;
            if(_timer >= 0)
            {
                agent.isStopped = false;
                _timer = 0;
                ChargeAttack();
            }
        }
        if (!Charge)
        {
            
            
            if (!agent.Raycast(target.position, out hit) && agent.remainingDistance <= 20)
            {
                agent.isStopped = true;
                _timer = Timer;
                Charge = true;
                //agent.autoBraking = false;
            }
        }
        if(!agent.Raycast(target.position, out hit) && agent.remainingDistance >= 20)
        {
            agent.isStopped = false;
            Charge = false;
            agent.speed = _oldspeed;
        }
        agent.destination = target.position;
    }

    void ChargeAttack()
    {
        agent.speed = ChargeSpeed;
    }
}
