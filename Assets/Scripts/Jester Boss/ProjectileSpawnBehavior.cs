using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ProjectileSpawnBehavior : MonoBehaviour
{
    public GameObject SpawnedEnemy;
    public float SpawnTimer;
    //public List<Transform> SpawnPoint;

    private Transform _currentSpawnPoint;
    private float _spawnTimer;

    private int spawnedamount; // amount of enemies that have spawned

    // Start is called before the first frame update
    void Start()
    {
        _spawnTimer = SpawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        _spawnTimer -= Time.deltaTime;
        if (_spawnTimer <= 0)
        {
            GameObject Spawned = Instantiate(SpawnedEnemy, transform.position, transform.rotation);
            spawnedamount += 1;
            _spawnTimer = SpawnTimer;
        }
    }

}
