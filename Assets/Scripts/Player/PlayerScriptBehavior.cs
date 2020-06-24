using UnityEngine;

public class PlayerScriptBehavior : MonoBehaviour
{
    static public int hp = 3;
    static public int shards = 100;
    static public int damage = 1;
    static public float attackDelay = 1.0f;
    static public float speed = 5.0f;
    static public float normalSpeed;
    static public float slowedSpeed;
    static public float gravityDefault = 1.0f;

    static public Weapon weapon = Weapon.Bow;

    public bool invul = false;
    public float iFramesDefault = 0.5f;
    public float iFrames;

    private PlayerAttackBehavior playerAttack;

    private void Start()
    {
        iFrames = iFramesDefault;
        normalSpeed = speed;
        slowedSpeed = speed * 0.5f;

        playerAttack = gameObject.GetComponent<PlayerAttackBehavior>();
    }

    private void Update()
    {
        if (invul)
        {
            iFrames -= Time.deltaTime;
            if (iFrames <= 0)
            {
                invul = false;
                iFrames = iFramesDefault;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchWeapon(3);
        }
    }

    public enum Weapon
    {
        Sword,
        Scythe,
        Axe,
        Bow
    }

    public void TakeDamage(int damage)
    {
        if (!invul)
        {
            hp -= damage;
            invul = true;
        }
        if (hp <= 0)
        { Die(); }
    }

    public void Heal(int heal)
    { hp += heal; }

    public void Die()
    {
        PlayerMovementBehavior p = gameObject.GetComponent<PlayerMovementBehavior>();
        PlayerAttackBehavior a = gameObject.GetComponent<PlayerAttackBehavior>();

        //Destroys the player movement so that they can't move while dead.
        p.enabled = false;
        //Also make them unable to attack
        a.enabled = false;

        if (!p.IsGrounded())
        {
            //Move player to the ground
            RaycastHit ray = new RaycastHit();
            Physics.Raycast(transform.position, -Vector3.up, out ray);

            Vector3 ground = ray.point;
            gameObject.transform.position = ground;
        }

        //Todo: Add player death animation
    }

    public void SwitchWeapon(int weaponID)
    {
        weapon = (Weapon)weaponID;

        if (weapon == Weapon.Sword)
        {
            damage = 2;
        }
        else if (weapon == Weapon.Axe)
        {
            damage = 4;
        }
        else if (weapon == Weapon.Bow)
        {
            damage = 1;
        }

        playerAttack.SwitchWeaponModel();
    }
}