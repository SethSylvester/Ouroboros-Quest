using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField]
    protected int Health;

    [HideInInspector]
    public Transform Target;

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

    public void  TakeDamage(int damage)
    {
        Health -= damage;
    }

    protected void CheckIfDead()
    {
        if (Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        agent.isStopped = true;
        Object.Destroy(gameObject, 3);
    }
}
