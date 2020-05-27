using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlimeSpawn : MonoBehaviour
{
    public GameObject SpawnedEnemy;
    public Transform target;
    public int spawnamountlimit;

    private int spawnedamount; // amount of enemies that have spawned

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnamountlimit >= spawnedamount)
        {


            GameObject Spawned = Instantiate(SpawnedEnemy, transform.position, transform.rotation);
            Spawned.tag = "Enemy attack";
            SlimeBehavior slime = Spawned.GetComponent<SlimeBehavior>();
            slime.target = target;
            spawnedamount += 1;
        }
    }
}
