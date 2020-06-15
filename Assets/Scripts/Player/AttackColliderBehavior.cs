using UnityEngine;

public class AttackColliderBehavior : MonoBehaviour
{
    //Todo: Collide with enemies once I get them
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<EnemyBehavior>() != null)
        {
            other.GetComponent<EnemyBehavior>().TakeDamage(PlayerScriptBehavior.damage);
        }

    }
}