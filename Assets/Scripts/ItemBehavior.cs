using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    public int healthRestore = 0;
    public int shardIncrease = 0;
    public float speedIncrease = 0f;
    public int attackIncrease = 0;

    //Pick Up Item Function
    private void OnTriggerEnter(Collider other)
    {
        PlayerScriptBehavior player = other.GetComponent<PlayerScriptBehavior>();
        if (player)
        {
            if (PlayerScriptBehavior.hp < 3)
            {
                PlayerScriptBehavior.hp += healthRestore;
                PlayerScriptBehavior.shards += shardIncrease;
                PlayerScriptBehavior.speed += speedIncrease;
                PlayerScriptBehavior.damage += attackIncrease;
            }
            else
            {
                PlayerScriptBehavior.shards += shardIncrease;
                PlayerScriptBehavior.speed += speedIncrease;
                PlayerScriptBehavior.damage += attackIncrease;
            }
            Destroy(gameObject);
        }
    }
}
