﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinWeaponBehavior : MonoBehaviour
{
    GoblinMovementBehavior Goblin;
    // Start is called before the first frame update
    void Start()
    {
        Goblin = gameObject.GetComponentInParent<GoblinMovementBehavior>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (Goblin.Charge)
        {
            if (other.CompareTag("Player"))
            {
                PlayerScriptBehavior p = other.GetComponentInParent<PlayerScriptBehavior>();
                p.TakeDamage(Goblin.Damage);
            }
        }
    }
}
