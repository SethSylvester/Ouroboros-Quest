using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackBehavior : MonoBehaviour
{
    //public variables
    public float damage = 1.0f;
    public float attackDelay = 1.0f;

    //private variables
    private float _attackDelayTimer;
    private bool _canAttack = true;

    private GameObject _hitBox;

    private Vector3 _attackPosition;

    // Start is called before the first frame update
    void Start()
    {
        _attackDelayTimer = attackDelay;
    }

    // Update is called once per frame
    void Update()
    {
        //If there is a left mouse click and the player is allowed to attack
        if (Input.GetMouseButtonDown(0) && _canAttack) { Attack(); }
        //Make sure the player can attack
        CheckAttack();
    }

    void Attack()
    {
        //Creates the hitbox
        CreateHitBox();
        //Set the vector 3 to the gameobject position + the forward.
        _attackPosition = (gameObject.transform.position) + gameObject.transform.forward;
        //Spawn a hitbox at the Vector3
        _hitBox.transform.position = _attackPosition;
        //Set canAttack to false to start the timer
        _canAttack = false;
    }

    void CreateHitBox()
    {
        //Makes the hitbox a gameobject rather then a nullpointer
        _hitBox = new GameObject();
        //Adds the attack collider script
        _hitBox.AddComponent<AttackColliderBehavior>();
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