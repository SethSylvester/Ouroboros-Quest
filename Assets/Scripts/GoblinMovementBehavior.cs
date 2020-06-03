using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoblinMovementBehavior : EnemyBehavior
{
    private Transform target;
    private float _oldspeed;
    private float _timer;
    private float _stopJumpAttackTime;
    private bool stop;

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
        stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Charge)
        {
            agent.destination = target.position;
        }
        if (Charge)
        {
            NavMeshHit point;
            Vector3 sourcePosition = transform.position + transform.forward;
            if (!NavMesh.SamplePosition(sourcePosition, out point, 1, NavMesh.AllAreas))
            {
                stop = true;
                Charge = false;
            }
            if (!stop)
            {
                agent.destination = transform.position + transform.forward;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            NavMeshHit hit;

            if (!agent.Raycast(target.position, out hit))
            {
                Charge = true;
            }
        }
        if (other.CompareTag("Wall"))
        {

        }
    }
}