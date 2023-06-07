using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballAbility : MonoBehaviour
{
    public int fireballDamage;
    public float aoeRadius = 10f;
    public float aoeDamagePercentage = 0.5f;

    public void OnCollisionEnter(Collision collision)
    {
        ApplyDamage();
    }

    private void ApplyDamage()
    {
        Debug.Log(fireballDamage + " dmg");

        // Find all nearby enemies within the area-of-effect radius
        Collider[] colliders = Physics.OverlapSphere(transform.position, aoeRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                GameObject enemy = collider.gameObject;

                // Calculate the distance between the enemy and the fireball
                float distance = Vector3.Distance(enemy.transform.position, transform.position);

                // Calculate the damage percentage based on the distance from the fireball
                float damagePercentage = (distance <= 5f) ? 1f : aoeDamagePercentage;

                // Apply damage to the enemy
                enemy.GetComponent<AIStats>().GetDmg(Mathf.RoundToInt(fireballDamage * damagePercentage));
            }
        }

        Destroy(gameObject);
    }
}
