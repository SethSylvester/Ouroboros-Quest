using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<PlayerMovementBehavior>() != null)
        {
            PlayerScriptBehavior.speed = PlayerScriptBehavior.slowedSpeed;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponentInParent<PlayerMovementBehavior>() != null)
        {
            PlayerScriptBehavior.speed = PlayerScriptBehavior.normalSpeed;
        }
    }
}
