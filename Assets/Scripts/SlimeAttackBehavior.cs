using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttackBehavior : MonoBehaviour
{
    SlimeBehavior Slime;
    // Start is called before the first frame update
    void Start()
    {
        Slime = gameObject.GetComponentInParent<SlimeBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!Slime.death)
        {
            //This checks if the trigger is the trigger for the hitbox
            if (other.CompareTag("PlayerHitbox"))
            {
                //Make the slimes hurt the player
                PlayerScriptBehavior p = other.GetComponentInParent<PlayerScriptBehavior>();
                p.TakeDamage(1);
            }
        }
    }
}
