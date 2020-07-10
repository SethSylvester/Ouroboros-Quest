using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScriptBehavior : MonoBehaviour
{
    static public int hp = 3;
    static public int shards = 10;
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

    float deathTimer = 3.0f;

    private PlayerAttackBehavior playerAttack;

    [SerializeField]
    Animator animator;


    private void Start()
    {
        iFrames = iFramesDefault;
        normalSpeed = speed;
        slowedSpeed = speed * 0.5f;

        playerAttack = gameObject.GetComponent<PlayerAttackBehavior>();
    }

    private void Update()
    {
        animator.speed = (speed/5);
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
            SwitchWeapon(3);
        }

        //Scene Switcher for Player Death
        if (hp <= 0)
        {
            deathTimer -= Time.deltaTime;

            if (deathTimer < 0)
            {
                print("Does this work?");
                //After the Player Dies, Send the User to the Game Lose Screen
                EndGame();
            }
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
            animator.SetTrigger("Hurt");
        }
        if (hp <= 0)
        { Die(); }
    }

    public void Heal(int heal)
    { hp += heal; }

    public void Die()
    {
        animator.SetTrigger("Death");

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
        //else if (weapon == Weapon.Axe)
        //{
        //    damage = 4;
        //}
        else if (weapon == Weapon.Bow)
        {
            damage = 1;
        }

        playerAttack.SwitchWeaponModel();
    }

    public void EndGame()
    {
        SceneManager.LoadScene("Game Lose Screen");        
    }
}