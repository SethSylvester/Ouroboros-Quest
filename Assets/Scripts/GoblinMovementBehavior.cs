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
    private bool _preparecharge;
    private float _oldAngularSpeed;
    private float _chargeCoolDown;

    public float Timer;
    public float ChargeSpeed;
    public bool Charge;
    public bool TestDying;
    public int Damage;
    public float RestTimer;
    public float ChargeTimer;
    public float ChargeCoolDown;


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
        _chargeTimer = ChargeTimer;
        _preparecharge = true;
        _oldAngularSpeed = agent.angularSpeed;
        _chargeCoolDown = ChargeCoolDown;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Charge);
        if (TestDying)
        {
            Die();
        }

        if (!Charge)
        {
            
            if(_restTimer <= 0)
                {
                agent.destination = target.position;
                Debug.Log("not Charging");
            }
            else if (_restTimer > 0)
            {
                _restTimer -= Time.deltaTime;
                Debug.Log("Resting");
            }
        }
        if (Charge)
        {
            if(_preparecharge)
            {
                stop = false;
                agent.speed = ChargeSpeed;
                _chargeTimer = ChargeTimer;
                _preparecharge = false;
                agent.angularSpeed = 0;
            }
            NavMeshHit point;
            Vector3 sourcePosition = transform.position + transform.forward;
            if (NavMesh.Raycast(agent.transform.position, sourcePosition, out point, 1))
            {
               Debug.Log("Stop");
               stop = true;
            }
            //Debug.Log(point.position);
            _chargeTimer -= Time.deltaTime;
            if (_chargeTimer <= 0)
            {
                stop = true;
            }
            if (!stop)
            {
                agent.destination = transform.position + transform.forward;
            }
            else if (stop)
            {
                agent.speed = _oldspeed;
                _restTimer = RestTimer;
                _chargeTimer = ChargeTimer;
                Charge = false;
                _preparecharge = true;
                agent.angularSpeed = _oldAngularSpeed;

            }
        }
        CheckIfDead();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (_chargeCoolDown <= 0)
        {
            if (other.CompareTag("Player"))
            {
                NavMeshHit hit;

                if (!agent.Raycast(target.position, out hit))
                {
                    Charge = true;

                }
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (_restTimer <= 0)
        {
            if (other.CompareTag("Player"))
            {
                Charge = true;
            }
        }
    }
}