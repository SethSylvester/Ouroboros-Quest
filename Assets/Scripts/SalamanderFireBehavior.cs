using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalamanderFireBehavior : MonoBehaviour
{
    private CharacterController fire;
    private MeshRenderer Mesh;
    private Vector3 Forward;

    private float _timer;
    public float Timer;

    public int Damage;
    public int Speed;

    // Start is called before the first frame update
    void Start()
    {
        fire = gameObject.GetComponent<CharacterController>();
        Forward = gameObject.transform.forward.normalized;
        Forward *= Speed;
        _timer = Timer;
        Mesh = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        fire.Move(Forward * Time.deltaTime);
        if(_timer <= 0)
        {
            Mesh.enabled = true;
        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHitbox"))
        {
            PlayerScriptBehavior p = other.GetComponentInParent<PlayerScriptBehavior>();
            p.TakeDamage(Damage);
            Object.Destroy(gameObject);
        }
    }
}
