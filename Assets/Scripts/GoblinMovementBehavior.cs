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
    private float _restTimer;
    private float _chargeTimer;

    public float Timer;
    public float ChargeSpeed;
    public bool Charge;
    public int Damage;
    public float RestTimer;
    public float ChargeTimer;
    


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
        _restTimer = 0.0f;
        _chargeTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Charge)
        {
            
            if(_restTimer <= 0)
                {
                agent.destination = target.position;
            }
            else
            {
                _restTimer -= Time.deltaTime;
            }
        }
        if (Charge)
        {
            NavMeshHit point;
            Vector3 sourcePosition = transform.position + transform.forward;
            if (!NavMesh.SamplePosition(sourcePosition, out point, 1, NavMesh.AllAreas))
            {
                stop = true;
            }
            _chargeTimer -= Time.deltaTime;
            if (_chargeTimer <= 0)
            {
                stop = true;
            }
            if (!stop)
            {
                agent.destination = transform.position + transform.forward;
            }
            if (stop)
            {
                agent.speed = _oldspeed;
                _restTimer = RestTimer;
                _chargeTimer = ChargeTimer;
                Charge = false;
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
                stop = false;
                agent.speed = ChargeSpeed;
                _chargeTimer = ChargeTimer;
            }
        }
    }
}