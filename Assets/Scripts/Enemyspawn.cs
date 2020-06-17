using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemyspawn : MonoBehaviour
{
    public GameObject SpawnedEnemy;
    public Transform target;
    public int SpawnAmountLimit;
    public float SpawnTimer;
    public List<Transform> SpawnPoint;

    private Transform _currentSpawnPoint;
    private float _spawnTimer;

    private int spawnedamount; // amount of enemies that have spawned

    // Start is called before the first frame update
    void Start()
    {
        _spawnTimer = SpawnTimer;
        _currentSpawnPoint = SpawnPoint[0];
    }

    // Update is called once per frame
    void Update()
    {
        _spawnTimer -= Time.deltaTime;
        if (_spawnTimer <= 0 && SpawnAmountLimit > spawnedamount)
        {
            GameObject Spawned = Instantiate(SpawnedEnemy, _currentSpawnPoint.transform.position, _currentSpawnPoint.transform.rotation);
            Spawned.tag = "Enemy attack";
            SlimeBehavior slime = Spawned.GetComponent<SlimeBehavior>();
            slime.target = target;
            spawnedamount += 1;
            _spawnTimer = SpawnTimer;
            _currentSpawnPoint = SpawnPoint[Random.Range(0, SpawnPoint.Count)];
        }
    }
}
