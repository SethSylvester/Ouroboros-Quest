using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SalamanderattackBehavior : MonoBehaviour
{
    private SalamanderMovement Salamander;
    // Start is called before the first frame update
    void Start()
    {
        Salamander = gameObject.GetComponentInParent<SalamanderMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Salamander.Attack)
        {
            if (other.CompareTag("PlayerHitbox"))
            {
                PlayerScriptBehavior p = other.GetComponentInParent<PlayerScriptBehavior>();
                p.TakeDamage(Salamander.Damage);
                Salamander.SendMessage("SetJumpbackTimer");
                //Salamander.Attack = false;
                Salamander.TestJumpBack = true;
            }
        }
    }
}
