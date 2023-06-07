using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    public int DMG;
    public int multiShot;
    public GameObject basicAttack;
    public GameObject tar;
    private void OnTriggerEnter(Collider other)
    {
        // Check if the trigger touches the target object
        if (other.CompareTag("Enemy"))
        {
            AIStats aiStats = other.gameObject.GetComponent<AIStats>();
            if (aiStats != null)
            {
                aiStats.GetDmg(DMG);
                ShootTowardsClosestEnemy();
            }

            // Destroy the attack object
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Invoke("DestroyMe", 3f);
    }

    void DestroyMe()
    {
        Destroy(gameObject);
    }

    public void ShootTowardsClosestEnemy()
    {
        if(multiShot < 1)
        {
            return;
        }
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = 500f;
        GameObject closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            if(enemy != tar)
            {  
                float distance = (enemy.transform.position - transform.position).sqrMagnitude;
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = enemy;
                }
            }
        }

        if (closestEnemy != null)
        {
            Vector3 direction = closestEnemy.transform.position - transform.position;
            direction.Normalize();
            Vector3 attackPosition = transform.position + direction * 1.5f;

            GameObject attack = Instantiate(basicAttack, attackPosition, Quaternion.LookRotation(direction));
            attack.GetComponent<Rigidbody>().velocity = direction * 15f;
            attack.GetComponent<BasicAttack>().tar = closestEnemy;
            attack.GetComponent<BasicAttack>().DMG -= 3;
            attack.GetComponent<BasicAttack>().multiShot--;

        }

        Debug.Log("Shooting");
    }
}
