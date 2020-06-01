using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackColliderBehavior : MonoBehaviour
{
    //Todo: Collide with enemies once I get them
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<SlimeBehavior>() != null)
        {
            Destroy(other.gameObject);
        }

    }

    private void Update()
    {
        //Set the vector 3 to the gameobject position + the forward.
        Vector3 pos = GetComponentInParent<GameObject>().transform.position + GetComponentInParent<GameObject>().transform.forward;
        transform.position = pos;
    }
}