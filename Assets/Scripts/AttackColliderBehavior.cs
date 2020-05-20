using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackColliderBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        //Destroy the hitbox in the time below
        Destroy(gameObject, 0.8f);
    }

    //Todo: Collide with enemies once I get them
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}