using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public GameObject itemDropped;
    public bool isDropped = false;

    [SerializeField]
    protected int Health;

    [HideInInspector]
    public Transform Target;

    protected NavMeshAgent agent;

    protected int randMax = 20;
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
        agent.isStopped = true;
        if (!isDropped)
        {
            ItemDrop();
        }
        UnityEngine.Object.Destroy(gameObject, 3);
    }

    void ItemDrop()
    {
        Vector3 itemPosition = agent.transform.position;
        //Creates the random number to determine drops
        int randItem = Random.Range(randMin, randMax);

        GameObject itemDrop = Instantiate(itemDropped, itemPosition, new Quaternion());

        isDropped = true;
    }
}
