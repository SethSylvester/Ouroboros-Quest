using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScriptBehavior : MonoBehaviour
{
    public int hp = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
    }

    public void Heal(int heal)
    {
        hp += heal;
    }

    void die()
    {
        PlayerMovementBehavior p = gameObject.GetComponent<PlayerMovementBehavior>();
        //If the player is grounded (So they don't die mid air and get stuck)
        if (p.IsGrounded())
        {
            //Destroys the player movement so that they can't move while dead.
            Destroy(p);
        }
    }
}
