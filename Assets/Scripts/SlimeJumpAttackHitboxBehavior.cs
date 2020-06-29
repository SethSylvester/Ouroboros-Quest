using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeJumpAttackHitboxBehavior : MonoBehaviour
{
    private SlimeBehavior Slime;
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
        //This checks if the trigger is the trigger on the player
        if (other.gameObject.CompareTag("Player"))
        {
            Slime.BeginJumpAttack();
        }
    }
}
