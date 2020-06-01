using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBehavior : MonoBehaviour
{
    Image health;
    Image shards;

    Text currentWeapon;
    Text swingSpeed;
    Text speed;

    // Update is called once per frame
    void Update()
    {
        currentWeapon.text = PlayerScriptBehavior.weapon.ToString();
        swingSpeed.text = PlayerScriptBehavior.attackDelay.ToString();
        speed.text = PlayerScriptBehavior.speed.ToString();
    }

}
