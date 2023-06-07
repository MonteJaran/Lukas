using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyAI : MonoBehaviour
{
    public float detectionRange = 15f;
    public float returnRange = 20f;
    public float AttackRange;
    public GameObject currentEnemy;
    public Transform playerTransform;
    public int DamageRemoverFromSamoyed;
    [Header("Stats")]
    public int MaxHP;
    public int HP;
    public int AD;
    public int Shield;
    public int Armor;
    public float Speed = 5f;

    [Header("Stats")]
    public int HaskiNextAttack;
    
    private void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
        FindClosestEnemy();
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        float PlayerToEnemy = 0f;
        if (currentEnemy == null || distanceToPlayer > returnRange)
        {
            // Find a new enemy or move towards the player if too far away
            if (distanceToPlayer > returnRange)
            {
                MoveTowardsPlayer();
                currentEnemy = null; // Reset current enemy to search for new ones
            }
            else
            {
                FindClosestEnemy();
                if(currentEnemy != null)
                {
                    PlayerToEnemy = Vector3.Distance(playerTransform.position, currentEnemy.transform.position);
                }
            }
        }
        else if(currentEnemy != null && returnRange > PlayerToEnemy)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, currentEnemy.transform.position);

            if(distanceToEnemy < AttackRange)
            {AttackEnemy(currentEnemy);}
            else
            {MoveTowardsEnemy();}
            

        }
        else if(currentEnemy == null && distanceToPlayer < returnRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            transform.rotation = transform.rotation;
        }
    }

    private void FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance <= detectionRange && distance < closestDistance)
            {
                closestDistance = distance;
                currentEnemy = enemy;
            }
        }
    }

    private void MoveTowardsEnemy()
    {
        if (currentEnemy != null )
        {
            // Rotate to face the current enemy
            Vector3 direction = currentEnemy.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        }
    }


    private void MoveTowardsPlayer()
    {
        Vector3 direction = playerTransform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
    }

    public void AttackEnemy(GameObject enemy)
    {
       enemy.GetComponent<AIStats>().GetDmg(AD * HaskiNextAttack);
       HaskiNextAttack = 1;
    }

    public void GetDmg(int DMG)
    {
        Debug.Log("Got: " + DMG + " dmg.");
        if(Shield > DMG)
        {
            Shield -= DMG;
            return;
        }

        int preDamage = DMG - Shield;
        
        Shield = 0;
        if(DamageRemoverFromSamoyed>0)
        {
            preDamage -= (Mathf.CeilToInt((preDamage/100)*DamageRemoverFromSamoyed));
        }
        if(preDamage < Armor)
        {
            return;
        }
        
        int ArmorReductionDMG = preDamage - Armor;
        HP -= ArmorReductionDMG;
        if(HP < 1)
        {
            Destroy(gameObject);
        }
        Debug.Log("Did to me: " + ArmorReductionDMG + " dmg.");
        
    }
}
