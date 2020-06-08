using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScriptBehavior : MonoBehaviour
{
    static public int hp = 3;
    static public int shards = 0;
    static public int damage = 1;
    static public float attackDelay = 1.0f;
    static public float speed = 5.0f;
    static public float gravityDefault = 1.0f;

    static public Weapon weapon = Weapon.Scythe;

    public enum Weapon
    {
        Sword,
        Scythe,
        Axe,
        Bow
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log("this worked");
        if (hp <= 0)
        { die(); }
    }

    public void Heal(int heal)
    { hp += heal; }

    public void die()
    {
        PlayerMovementBehavior p = gameObject.GetComponent<PlayerMovementBehavior>();
        PlayerAttackBehavior a = gameObject.GetComponent<PlayerAttackBehavior>();
        //If the player is grounded (So they don't die mid air and get stuck)
        if (p.IsGrounded())
        {
            //Destroys the player movement so that they can't move while dead.
            p.enabled = false;
            //Also make them unable to attack
            a.enabled = false;
            //Todo: Add player death animation
        }
    }
}