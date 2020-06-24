using UnityEngine;

public class AttackColliderBehavior : MonoBehaviour
{
    //Todo: Collide with enemies once I get them
    private void OnTriggerEnter(Collider other)
    {
        //If its an enemy
        if (other.gameObject.GetComponentInParent<SlimeBehavior>() != null ||
            other.gameObject.GetComponentInParent<GoblinMovementBehavior>() != null ||
            other.gameObject.GetComponentInParent<SalamanderMovement>() != null)

        {
            //Hurt it
            other.GetComponentInParent<EnemyBehavior>().TakeDamage(PlayerScriptBehavior.damage);
            //Then remove the arrow
            DestroyArrow();
        }
        //If its the boss
        else if (other.gameObject.GetComponentInParent<JesterBossBehavior>() != null)
        {
            other.gameObject.GetComponentInParent<JesterBossBehavior>().TakeDamage(PlayerScriptBehavior.damage);
            DestroyArrow();
        }

    }

    private void DestroyArrow()
    {
        if (gameObject.GetComponent<ProjectileBehavior>())
        {
            Destroy(gameObject);
        }
    }
}