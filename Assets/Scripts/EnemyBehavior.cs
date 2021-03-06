﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public Animator EnemyAnimator;

    public float deathTimer;

    public GameObject itemDropped1;
    public GameObject itemDropped2;
    public GameObject itemDropped3;
    public GameObject itemDropped4;
    public bool isDropped = false;

    [HideInInspector]
    public GameObject Enemy;

    [HideInInspector]
    public bool death;

    [SerializeField]
    protected int Health;

    [HideInInspector]
    public Enemyspawn enemyspawner;

    [HideInInspector]
    public Transform Target;

    protected NavMeshAgent agent;

    protected int randMax = 100;
    protected int randMin = 0;

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
        death = true;
        enemyspawner.playerkills += 1;
        agent.isStopped = true;
        gameObject.GetComponent<Collider>().enabled = false;
        agent.SetDestination(gameObject.transform.position); 
        Debug.Log(enemyspawner.playerkills);
        if (!isDropped)
        {
            ItemDrop();
        }
        EnemyAnimator.SetTrigger("Death");
        UnityEngine.Object.Destroy(gameObject, deathTimer);
    }

    //Function for dropping items for each enemy
    void ItemDrop()
    {
        Vector3 itemPosition = agent.transform.position;
        //Creates the random number to determine drops
        int randItem = Random.Range(randMin, randMax);

        if (randItem >= 0 && randItem < 30)
        {
            GameObject itemDrop = Instantiate(itemDropped1, itemPosition, new Quaternion());
        }
        else if (randItem >= 30 && randItem < 55)
        {
            GameObject itemDrop = Instantiate(itemDropped2, itemPosition, new Quaternion());
        }
        else if (randItem >= 55 && randItem < 75)
        {
            GameObject itemDrop = Instantiate(itemDropped3, itemPosition, new Quaternion());
        }
        else if (randItem >= 75 && randItem < 95)
        {
            GameObject itemDrop = Instantiate(itemDropped4, itemPosition, new Quaternion());
        }
        else if (randItem >= 95 && randItem < 100)
        {
            return;
        }

        isDropped = true;
    }
}
