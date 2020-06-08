using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField]
    protected int Health;

    protected NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfDead();
    }

    public virtual void  TakeDamage(int damage)
    {
        Health -= damage;
    }

    protected virtual void CheckIfDead()
    {
        if (Health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        agent.isStopped = true;
        Object.Destroy(gameObject, 3);
    }
}
