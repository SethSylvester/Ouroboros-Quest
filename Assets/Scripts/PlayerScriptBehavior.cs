using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScriptBehavior : MonoBehaviour
{
    static public int hp = 3;
    static public float damage = 1.0f;
    static public float attackDelay = 1.0f;
    static public float speed = 5.0f;
    static public float gravityDefault = 1.0f;

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

        if (hp <= 0)
        {
            die();
        }
    }

    public void Heal(int heal)
    {
        hp += heal;
    }

    public void die()
    {
        PlayerMovementBehavior p = gameObject.GetComponent<PlayerMovementBehavior>();
        PlayerAttackBehavior a = gameObject.GetComponent<PlayerAttackBehavior>();
        //If the player is grounded (So they don't die mid air and get stuck)
        if (p.IsGrounded())
        {
            //Destroys the player movement so that they can't move while dead.
            Destroy(p);
            //Also make them unable to attack
            Destroy(a);
            //Todo: Add player death animation
        }
    }

}
