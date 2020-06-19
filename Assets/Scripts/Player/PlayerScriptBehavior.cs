using UnityEngine;

public class PlayerScriptBehavior : MonoBehaviour
{
    static public int hp = 3;
    static public int shards = 100;
    static public int damage = 1;
    static public float attackDelay = 1.0f;
    static public float speed = 5.0f;
    static public float gravityDefault = 1.0f;

    static public Weapon weapon = Weapon.Bow;

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

    private void ToGround()
    {

    }
}