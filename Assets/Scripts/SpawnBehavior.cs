using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehavior : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform behaviorTarget;

    public float timeInterval = 5.0f;
    public float timeRemaining = 0.0f;

    // Update is called once per frame
    void Update()
    {
        //decrease time remaining
        timeRemaining -= Time.deltaTime;

        //if no time is remaining
        if (timeRemaining <= 0.0f)
        {
            timeRemaining = timeInterval;
            SpawnInstance();
        }
    }

    void SpawnInstance()
    {
        GameObject spawnedEnemy = Instantiate(objectToSpawn, transform.position, transform.rotation);

        ////Set pursuits behavior
        //PursuitBehavior pursueBehavior = spawnedEnemy.GetComponent<PursuitBehavior>();
        //if (pursueBehavior != null)
        //{
        //    pursueBehavior.target = behaviorTarget;
        //}
        ////set avoidbehavior to target
        //AvoidBehavior avoidBehavior = spawnedEnemy.GetComponent<AvoidBehavior>();
        //if (avoidBehavior != null)
        //{
        //    avoidBehavior.target = behaviorTarget;
        //}

        ////Set the pathfinders target
        //PathfindBehavior pathfindBehavior = spawnedEnemy.GetComponent<PathfindBehavior>();
        //if (pathfindBehavior != null)
        //{
        //    pathfindBehavior.target = behaviorTarget;
        //}


    }
}
