using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileAttackColliderBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<PlayerMovementBehavior>() != null)
        {
            other.gameObject.GetComponentInParent<PlayerScriptBehavior>().TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
