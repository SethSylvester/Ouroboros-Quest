using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleProjectileSpawnerBehavior : MonoBehaviour
{
    public GameObject SpawnedEnemy;
    //public List<Transform> SpawnPoint;

    private void OnEnable()
    {
        GameObject Spawned = Instantiate(SpawnedEnemy, transform.position, transform.rotation);
    }
}
