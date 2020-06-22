﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemyspawn : MonoBehaviour
{
    public GameObject Slime;
    public GameObject Goblin;
    public GameObject Salamander;

    private int Enemynumber;

    private Transform target;
    public int SlimeSpawnAmountLimit;
    public int GoblinSpawnAmountLimit;
    public int SalamanderSpawnAmountLimit;
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
        Enemynumber = 1; // Use to keep track of wich enemy is spawning;
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemynumber == 1)
        {
            _spawnTimer -= Time.deltaTime;
            if (_spawnTimer <= 0 && SlimeSpawnAmountLimit > spawnedamount)
            {
                GameObject Spawned = Instantiate(Slime, _currentSpawnPoint.transform.position, _currentSpawnPoint.transform.rotation);
                spawnedamount += 1;
                _spawnTimer = SpawnTimer;
                _currentSpawnPoint = SpawnPoint[Random.Range(0, SpawnPoint.Count)];
            }
            if(SlimeSpawnAmountLimit <= spawnedamount)
            {
                Enemynumber += 1;
                spawnedamount = 0;
                _spawnTimer = SpawnTimer;
            }
        }
        if (Enemynumber == 2)
        {
            _spawnTimer -= Time.deltaTime;
            if (_spawnTimer <= 0 && GoblinSpawnAmountLimit > spawnedamount)
            {
                GameObject Spawned = Instantiate(Goblin, _currentSpawnPoint.transform.position, _currentSpawnPoint.transform.rotation);
                spawnedamount += 1;
                _spawnTimer = SpawnTimer;
                _currentSpawnPoint = SpawnPoint[Random.Range(0, SpawnPoint.Count)];
            }
            if (GoblinSpawnAmountLimit <= spawnedamount)
            {
                Enemynumber += 1;
                spawnedamount = 0;
                _spawnTimer = SpawnTimer;
            }
        }
        if (Enemynumber == 3)
        {
            _spawnTimer -= Time.deltaTime;
            if (_spawnTimer <= 0 && SalamanderSpawnAmountLimit > spawnedamount)
            {
                GameObject Spawned = Instantiate(Salamander, _currentSpawnPoint.transform.position, _currentSpawnPoint.transform.rotation);
                spawnedamount += 1;
                _spawnTimer = SpawnTimer;
                _currentSpawnPoint = SpawnPoint[Random.Range(0, SpawnPoint.Count)];
            }
            if (SalamanderSpawnAmountLimit <= spawnedamount)
            {
                Enemynumber += 1;
                spawnedamount = 0;
                _spawnTimer = SpawnTimer;
            }
        }
    }
}
