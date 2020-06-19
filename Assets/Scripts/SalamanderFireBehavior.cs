using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalamanderFireBehavior : MonoBehaviour
{
    private CharacterController fire;
    private Vector3 Forward;
    public int Damage;

    // Start is called before the first frame update
    void Start()
    {
        fire = gameObject.GetComponent<CharacterController>();
        Forward = gameObject.transform.forward.normalized;
        Forward *= 25;
    }

    // Update is called once per frame
    void Update()
    {
        fire.Move(Forward * Time.deltaTime);
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
