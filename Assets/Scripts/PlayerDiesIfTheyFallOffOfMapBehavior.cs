using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDiesIfTheyFallOffOfMapBehavior : MonoBehaviour
{
    PlayerScriptBehavior Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject.GetComponentInParent<PlayerScriptBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.transform.position.y < -20)
        {
            Player.TakeDamage(1);
        }
    }
}
