using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject[] enemyUnits; // Array containing references to all enemy units
    public Transform[] playerUnits; // Array containing references to all player units
    public float rotationSpeed;
    public float movementSpeed;
    public float slownessEffect;
    public void Start()
    {
        enemyUnits = new GameObject[5000];
    }
    public void Update()
    {
        // Iterate through all enemy units
        foreach(GameObject enemyUnit in enemyUnits)
        {
            if(enemyUnit != null)
            {
                Transform closestPlayer = FindClosestPlayer(enemyUnit.transform.position);
            
                // Move the enemy unit towards the closest player unit
                float dist = Vector3.Distance(enemyUnit.transform.position, closestPlayer.transform.position);
                if(dist < 2f)
                {
                    enemyUnit.GetComponent<AIStats>().AttackAlly(closestPlayer);
                }
                else
                {
                    MoveEnemyTowardsPlayer(enemyUnit, closestPlayer);
                }
            }
        }
    }

    public Transform FindClosestPlayer(Vector3 enemyPosition)
    {
        Transform closestPlayer = null;
        float closestDistance = Mathf.Infinity;

        // Iterate through all player units
        for (int i = 0; i < playerUnits.Length; i++)
        {
            // Calculate the distance between the enemy and player unit
            float distance = Vector3.Distance(enemyPosition, playerUnits[i].position);

            // Check if this player unit is closer than the previous closest
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPlayer = playerUnits[i];
            }
        }

        return closestPlayer;
    }

    public void MoveEnemyTowardsPlayer(GameObject enemy, Transform player)
    {
        Vector3 direction = (player.position - enemy.transform.position).normalized;

        // Rotate the enemy towards the player
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        enemy.transform.rotation = Quaternion.Lerp(enemy.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

        // Move the enemy in a straight line towards the player
        enemy.transform.position += enemy.transform.forward * movementSpeed * Time.deltaTime * slownessEffect;
        
    }

    public void AddNewEnemy(GameObject newEnemy)
    {
        for(int i = 0; i < enemyUnits.Length; i++)
        {
            if(enemyUnits[i] == null)
            {
                enemyUnits[i] = newEnemy;
                return;
            }
        }
    }
}
