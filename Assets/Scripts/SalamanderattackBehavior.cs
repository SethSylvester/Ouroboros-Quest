using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SalamanderattackBehavior : MonoBehaviour
{
    private float _attackcooldown;
    public GameObject Fire;
    private SalamanderMovement Salamander;
    private FireTriggerScript SalamanderFire;
    
    public float FireTimer;
    private float _fireTimer;

    public float RestTimer;
    private float _restTimer;

    private bool _fireSpawned;

    // Start is called before the first frame update
    void Start()
    {
        Salamander = gameObject.GetComponentInParent<SalamanderMovement>();
        SalamanderFire = Salamander.GetComponentInChildren<FireTriggerScript>();
        _fireTimer = FireTimer;
        _restTimer = RestTimer;
        _fireSpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        _attackcooldown -= Time.deltaTime;
        if (Salamander.RangedAttack)
        { 
            _fireTimer -= Time.deltaTime;
            if (_fireTimer <= 0)
            {
                if (!_fireSpawned)
                {
                    GameObject.Instantiate(Fire, Salamander.transform.position, Salamander.transform.rotation);
                    Debug.Log("Fire");
                    _fireSpawned = true;
                }
                _restTimer -= Time.deltaTime;

                if (_restTimer <= 0)
                {
                    Salamander.RangedAttack = false;
                    _fireSpawned = false;
                    SalamanderFire.RangeCoolDown();
                    _fireTimer = FireTimer;
                    _restTimer = RestTimer;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Salamander.Attack)
        {
            if (other.CompareTag("PlayerHitbox"))
            {
                PlayerScriptBehavior p = other.GetComponentInParent<PlayerScriptBehavior>();
                p.TakeDamage(Salamander.Damage);
                Salamander.SendMessage("SetJumpbackTimer");
                //Salamander.Attack = false;
                Salamander.TestJumpBack = true;
            }
        }
    }
}
