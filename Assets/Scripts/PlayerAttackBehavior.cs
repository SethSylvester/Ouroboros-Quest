using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackBehavior : MonoBehaviour
{
    //public variables

    //private variables
    private float damage;
    private float attackDelay;

    private float hitboxSpawnTimeDefault = 0.5f;
    private float hitboxSpawnTime;

    private float _attackDelayTimer;
    private bool _canAttack = true;

    private bool weaponOut = false;

    [SerializeField]
    GameObject sword;
    [SerializeField]
    GameObject scythe;
    [SerializeField]
    GameObject axe;

    // Start is called before the first frame update
    void Start()
    {
        hitboxSpawnTime = hitboxSpawnTimeDefault;

        damage = PlayerScriptBehavior.damage;
        attackDelay = PlayerScriptBehavior.attackDelay;

        _attackDelayTimer = attackDelay;
    }

    // Update is called once per frame
    void Update()
    {
        //If there is a left mouse click and the player is allowed to attack
        if (Input.GetMouseButtonDown(0) && _canAttack) { Attack(); }
        //Make sure the player can attack
        CheckAttack();
        WeaponTimer();
    }

    void Attack()
    {
        if (PlayerScriptBehavior.weapon != PlayerScriptBehavior.Weapon.Bow)
        {
            //Switch statement depending on which weapon
            switch (PlayerScriptBehavior.weapon)
            {
                case PlayerScriptBehavior.Weapon.Sword:
                    sword.SetActive(true);
                    break;
                case PlayerScriptBehavior.Weapon.Scythe:
                    scythe.SetActive(true);
                    break;
                case PlayerScriptBehavior.Weapon.Axe:
                    axe.SetActive(true);
                    break;
            }
            weaponOut = true;
        }
        _canAttack = false;
    }

    void WeaponTimer()
    {
        //If the player is swinging the hitbox tick down the timer
        if (weaponOut)
        { hitboxSpawnTime -= Time.deltaTime; }

        //When the hitbox timer is 0
        if (hitboxSpawnTime <= 0)
        {
            //Sword
            if (sword.activeSelf)
            { sword.SetActive(false); }
            //Scythe
            else if (scythe.activeSelf)
            { scythe.SetActive(false); }
            //Axe
            else if (axe.activeSelf)
            { axe.SetActive(false); }

            //Stop & reset the timer
            weaponOut = false;
            hitboxSpawnTime = hitboxSpawnTimeDefault;
        }
    }

    void CheckAttack()
    {
        //Switch statements are faster than if statements
        switch (_canAttack)
        {
            //If canAttack is false
            case false:
                //Tick down the timer
                _attackDelayTimer -= Time.deltaTime;
                //When the timer is 0 or less
                if (_attackDelayTimer <= 0)
                {
                    //Set can attack to true
                    _canAttack = true;
                    //Reset the timer
                    _attackDelayTimer = attackDelay;
                }
                //End of switch statement
                break;
        }
    }
}