using UnityEngine;

public class AttackColliderBehavior : MonoBehaviour
{
    //Todo: Collide with enemies once I get them
    private void OnTriggerEnter(Collider other)
    {
        //If its an enemy
        if (other.gameObject.GetComponent<EnemyBehavior>() != null)
        {
            other.GetComponent<EnemyBehavior>().TakeDamage(PlayerScriptBehavior.damage);
            DestroyArrow();
        }
        //If its the boss
        else if (other.gameObject.GetComponent<JesterBossBehavior>() != null)
        {
            other.GetComponent<JesterBossBehavior>().TakeDamage(PlayerScriptBehavior.damage);
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