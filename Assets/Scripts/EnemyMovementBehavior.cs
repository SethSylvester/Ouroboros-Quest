using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementBehavior : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;

    public int health;
    public int damage;

    public int Timer;
    public float JumpSpeed;
    private float _oldspeed;
    private float _timer;
    [System.NonSerialized]public bool _isstoped;
    Random rand;
    public Material Green;
    public Material Red;
    private MeshRenderer mesh;
    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        mesh = gameObject.GetComponent<MeshRenderer>();
        mesh.material = Green;
        _oldspeed = agent.speed;
        _timer = Timer;
        _isstoped = false;
    }

    // Update is called once per frame
    void Update()
    {
        //sets the enemies destination to the target
        agent.destination = target.position;

        jumpattack();
    }

    void OnTriggerEnter(Collider other)
    {
        agent.isStopped = true;
        _isstoped = true;
        
    }

    void OnTriggerExit(Collider other)
    {
        agent.isStopped = false;
        _timer = Timer;
        agent.speed = _oldspeed;
    }

    public void jumpattack()
    {
        if (agent.isStopped == true)
        {
            _timer -= Time.deltaTime;

            if (agent.isStopped == true)
            {
                if (_timer <= 0.0f)
                {
                    agent.speed = JumpSpeed;
                    agent.isStopped = false;
                    _timer = Timer;
                }
            }
        }
    }

    public void TakeDamage(int enemyattack)
    {

    }
}
