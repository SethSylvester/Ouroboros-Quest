using UnityEngine;

public class PlayerAttackBehavior : MonoBehaviour
{
    //private variables
    private float attackDelay;

    private float hitboxSpawnTimeDefault = 0.3f;
    private float hitboxSpawnTime;

    private float _attackDelayTimer;
    private bool _canAttack = true;

    private bool weaponOut = false;

    [SerializeField]
    GameObject swordHitbox;
    [SerializeField]
    GameObject arrowSpawner;
    [SerializeField]
    GameObject arrow;

    [SerializeField]
    GameObject swordModel;
    [SerializeField]
    GameObject bowModel;

    [SerializeField]
    Animator animator;


    // Start is called before the first frame update
    private void Start()
    {
        hitboxSpawnTime = hitboxSpawnTimeDefault;

        attackDelay = PlayerScriptBehavior.attackDelay;

        _attackDelayTimer = attackDelay;
    }

    // Update is called once per frame
    private void Update()
    {
        //If there is a left mouse click and the player is allowed to attack
        if (Input.GetMouseButtonDown(0) && _canAttack) { Attack(); }
        //Make sure the player can attack
        CheckAttack();
        WeaponTimer();
    }

    private void Attack()
    {
            //Switch statement depending on which weapon
            switch (PlayerScriptBehavior.weapon)
            {
                case PlayerScriptBehavior.Weapon.Sword:
                animator.SetTrigger("Attack");
                    swordHitbox.SetActive(true);
                    break;
                //case PlayerScriptBehavior.Weapon.Axe:
                //    axeHitbox.SetActive(true);
                //    break;
                case PlayerScriptBehavior.Weapon.Bow:
                Vector3 arrowSpawnPoint = arrowSpawner.transform.position;
                Instantiate(arrow, arrowSpawnPoint, transform.rotation);
                break;
            }
            weaponOut = true;
        _canAttack = false;
    }

    private void WeaponTimer()
    {
        //If the player is swinging the hitbox tick down the timer
        if (weaponOut)
        { hitboxSpawnTime -= Time.deltaTime; }

        //When the hitbox timer is 0
        if (hitboxSpawnTime <= 0)
        {
            //Sword
            if (swordHitbox.activeSelf)
            { swordHitbox.SetActive(false); }
            ////Axe
            //else if (axeHitbox.activeSelf)
            //{ axeHitbox.SetActive(false); }

            //Stop & reset the timer
            weaponOut = false;
            hitboxSpawnTime = hitboxSpawnTimeDefault;
        }
    }

    private void CheckAttack()
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

    public void SwitchWeaponModel()
    {
        swordModel.SetActive(false);
        //axeModel.SetActive(false);
        bowModel.SetActive(false);

        switch (PlayerScriptBehavior.weapon)
        {
            case (PlayerScriptBehavior.Weapon.Sword):
                swordModel.SetActive(true);
                break;
            //case (PlayerScriptBehavior.Weapon.Axe):
            //    axeModel.SetActive(true);
            //    break;
            case (PlayerScriptBehavior.Weapon.Bow):
                bowModel.SetActive(true);
                break;
        }
    }
}