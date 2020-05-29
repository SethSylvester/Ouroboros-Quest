using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackColliderBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        //Give it a rigidbody so it can collide
        gameObject.AddComponent<Rigidbody>();
        //Destroy the hitbox in the time below
        Destroy(gameObject, 0.8f);
    }

    //Todo: Collide with enemies once I get them
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.GetComponent<GoblinMovementBehavior>() != null ||
        collision.collider.gameObject.GetComponent<SlimeBehavior>() != null)
        {
            Destroy(collision.collider.gameObject);
        }
    }
}