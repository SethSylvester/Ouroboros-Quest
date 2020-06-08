using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SalamanderMovement : EnemyBehavior
{
    private Transform target;
    private NavMeshAgent Salamander;
    private Vector3 JumpBackPosition;
    private int _oldSpeed;
    private bool _jumpback;
    private bool hasTarget;

    public bool TestJumpBack;
    public float JumpBackTimer;
    public float JumpBackSpeed;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Salamander = gameObject.GetComponent<NavMeshAgent>();
        _jumpback = false;
        hasTarget = false;
}

    // Update is called once per frame
    void Update()
    {
        if (!_jumpback)
        {
            Salamander.destination = target.position;
        }
        if(_jumpback)
        {
            JumpBack();
        }
        if(TestJumpBack)
        {
            TestJumpBack = false;
            _jumpback = true;
        }
    }

    public void JumpBack()
    {

    if(hasTarget)
        {
            
        }
       
    }

    public override void Die()
    {
        base.Die();
    }
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }
}
