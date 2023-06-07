using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AbilityTree : MonoBehaviour
{
    public float AbilityCD1, AbilityCD2, AbilityCD3, AbilityCD4, AbilityCD5, AbilityCD10, AbilityCD11, AbilityCD12, AbilityCD13, AbilityCD14, AbilityCD15, AbilityCD16, AbilityCD17, AbilityCD18, AbilityCD19, AbilityCD20, AbilityCD21, AbilityCD22, AbilityCD23, AbilityCD24, AbilityCD25, AbilityCD26, AbilityCD27, AbilityCD28, AbilityCD29, AbilityCD30, AbilityCD31, AbilityCD32, AbilityCD33;
    public int upgradeA1, upgradeA2, upgradeA3, upgradeA4, upgradeA5;
    public GameObject fireballPrefab;
    public int AD, Armor;
    
    public GameObject basicAttack;
    public float closestDistance;
    public GameObject closest;
    public Vector3 playerPosition;
    public GameObject[] enemies;
    
    private FriendlyAI ShibaAI;
    private FriendlyAI HaskiAI;
    private FriendlyAI SamoyedAI;
    private FriendlyAI LabradorAI;
    private FriendlyAI SamhuskyAI;
    private ExpirienceBar expBar;
    private float currentATSP;

    private PlayerStats PS;


    // Abilities var things
    public GameObject SamhuskyAsset;
    private int numOfTimes = 5;
    private int fireballDamage = 40;
    private int ArmorAmount = 5;
    private int shieldAmount = 5;
    private float ShieldRemovalTime = 7f;
    private int ThunerDamage = 20;
    private int multiShot = 0;
    public int HaskiNextAttack;
    public int bonusMoney;
    public int returnBonusGoldAD = 4;
    public int HPtoDamageMultiplier = 2;
    public int LabradorHPHeal = 1;
    public int SamhuskyHPToClone = 25;
    public int killsNeededForIncrement = 30;
    public int DamageRemoverFromSamoyed = 20;
    // Start is called before the first frame update
    void Start()
    {
        PS = GetComponent<PlayerStats>();
        InvokeRepeating("BasicAttack", 1f, 1f);
        InvokeRepeating("Ability1", 0f, AbilityCD1);
        InvokeRepeating("Ability2", 0f, AbilityCD2);
        InvokeRepeating("Ability3", 0f, AbilityCD3);
        InvokeRepeating("Ability4", 0f, AbilityCD4);
        ActivateAbility(20);
        ActivateAbility(19);
        //InvokeRepeating("Ability5", 0f, AbilityCD5);
        InvokeRepeating("GetInfo", 0f, 1f);
        Ability9();
        Ability8();
        Ability7();
        Invoke("UpgradeAbility9()", 10f);
        Invoke("UpgradeAbility8()", 10f);
        Invoke("UpgradeAbility7()", 10f);
        ShibaAI = GameObject.Find("Shiba").GetComponent<FriendlyAI>();
        HaskiAI = GameObject.Find("Haski").GetComponent<FriendlyAI>();
        SamoyedAI = GameObject.Find("Samoyed").GetComponent<FriendlyAI>();
        LabradorAI = GameObject.Find("Labrador").GetComponent<FriendlyAI>();
        SamhuskyAI = GameObject.Find("Samhusky").GetComponent<FriendlyAI>();
        expBar = GameObject.Find("EXPBar").GetComponent<ExpirienceBar>();
    }

    public void GetInfo()
    {
        AD = PS.AD;
        Armor = PS.Armor;
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(upgradeA1 < 4)
            {
                upgradeA1++;
            }
            Ability1();
        }
    }

    public void BasicAttack()
    {
        AD = PS.AD;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        closest = null;
        closestDistance = 500f;

        // Iterate through all enemies with the specified tag
        foreach (GameObject enemy in enemies)
        {
            
            // Calculate the squared distance between the player and enemy
            float distance = (enemy.transform.position - transform.position).sqrMagnitude;

            // Check if this enemy is closer than the previous closest
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closest = enemy;
            }
            
            
        }
        if (closest != null)
        {
            // Calculate the direction towards the closest enemy
            Vector3 direction = closest.transform.position - transform.position;
            direction.Normalize();

            Vector3 attackPosition = transform.position + direction * 1.5f;

            // Instantiate the attack prefab with the desired rotation
            GameObject attack = Instantiate(basicAttack, attackPosition, Quaternion.LookRotation(direction));
            attack.GetComponent<Rigidbody>().velocity = direction * 15f;
            attack.GetComponent<BasicAttack>().tar = closest;
            attack.GetComponent<BasicAttack>().DMG = AD;
            attack.GetComponent<BasicAttack>().multiShot = multiShot;
            // attack.GetComponent<BasicAttack>().basicAttack = basicAttack;
        }
    }



    // Activate specific ability
    public void ActivateAbility(int abilityNumber)
    {
        switch (abilityNumber)
        {

            case 1:
                InvokeRepeating("Ability1", 0f, AbilityCD1);
                break;
            case 2:
                InvokeRepeating("Ability2", 0f, AbilityCD2);
                break;
            case 3:
                InvokeRepeating("Ability3", 0f, AbilityCD3);
                break;
            case 4:
                InvokeRepeating("Ability4", 0f, AbilityCD4);
                break;
            case 5:
                InvokeRepeating("Ability5", 0f, AbilityCD5);
                break;
            case 6:
                Ability6();
                break;

            case 7:
                Ability7();
                break;
            case 8:
                Ability8();
                break;
            case 9:
                Ability9();
                break;
            case 10:
                InvokeRepeating("Ability10", 0f, AbilityCD10);
                break;
            case 11:
                InvokeRepeating("Ability11", 0f, AbilityCD11);
                break;
            case 12:
                InvokeRepeating("Ability12", 0f, AbilityCD12);
                break;

            case 13:
                InvokeRepeating("Ability13", 0f, AbilityCD13);
                break;
            case 14:
                InvokeRepeating("Ability14", 0f, AbilityCD14);
                break;
            case 15:
                InvokeRepeating("Ability15", 0f, AbilityCD15);
                break;
            case 16:
                InvokeRepeating("Ability16", 0f, AbilityCD16);
                break;
            case 17:
                InvokeRepeating("Ability17", 0f, AbilityCD17);
                break;
            case 18:
                InvokeRepeating("Ability18", 0f, AbilityCD18);
                break;

            case 19:
                InvokeRepeating("Ability19", 0f, AbilityCD19);
                break;
            case 20:
                InvokeRepeating("Ability20", 0f, AbilityCD20);
                break;

            case 21:
                InvokeRepeating("Ability21", 0f, AbilityCD21);
                break;
            case 22:
                InvokeRepeating("Ability22", 0f, AbilityCD22);
                break;

            case 23:
                InvokeRepeating("Ability23", 0f, AbilityCD23);
                break;
            case 24:
                InvokeRepeating("Ability24", 0f, AbilityCD24);
                break;

            case 25:
                InvokeRepeating("Ability25", 0f, AbilityCD25);
                break;
            case 26:
                InvokeRepeating("Ability26", 0f, AbilityCD26);
                break;

            case 27:
                InvokeRepeating("Ability27", 0f, AbilityCD27);
                break;
            case 28:
                Ability28();
                expBar.ChangeBool(killsNeededForIncrement);
                break;
            default:
            // Handle an invalid ability number
            break;
        }
    }

    public void Ability1()
    {
        float delay = 0.15f;
        for (int i = 0; i < numOfTimes; i++)
        {
            Invoke("BasicAttack", delay);
            delay += 0.15f;
        }
    }
    public void Ability2()
    {   
        // Find all objects with the "Enemy" tag
        GameObject[] enemiess = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemiess.Length > 0)
        {
            // Find the closest enemy
            GameObject closestEnemy = null;
            float closestDistance = Mathf.Infinity;

            foreach (GameObject enemy in enemiess)
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance < closestDistance)
                {
                    closestEnemy = enemy;
                    closestDistance = distance;
                }
            }

            if (closestEnemy != null)
            {
                // Calculate the direction from the player to the closest enemy
                Vector3 direction = (closestEnemy.transform.position - transform.position).normalized;

                // Calculate the travel time based on the distance and projectile speed
                float travelTime = closestDistance / 10f;

                // Calculate the initial velocity to reach the enemy in the specified travel time
                Vector3 initialVelocity = direction * 10f;
                initialVelocity.y = (2.5f - transform.position.y) / 0.5f;

                // Instantiate the projectile slightly above the player's position
                Vector3 projectileSpawnPosition = transform.position + Vector3.up * 2.5f;
                GameObject projectile = Instantiate(fireballPrefab, projectileSpawnPosition, Quaternion.identity);

                // Set the projectile's initial velocity
                projectile.GetComponent<Rigidbody>().velocity = initialVelocity;
                projectile.GetComponent<FireballAbility>().fireballDamage = fireballDamage += PS.AD;
            }
        }
        
    }
    


    public void Ability3()
    {
         GameObject[] enemiess = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemiess.Length > 0)
        {
            foreach(GameObject enemy in enemiess)
            {
                enemy.GetComponent<AIStats>().Armor -= ArmorAmount;
            }
        }
    }

    public IEnumerator Ability4()
    {
        int shieldAmount = Mathf.RoundToInt(PS.MaxHP * 0.4f);
        PS.Shield += shieldAmount;

        yield return new WaitForSeconds(ShieldRemovalTime);

        PS.RemoveShield(shieldAmount);
    }

    public void Ability5()
    {
        // Thunderstorm 
        // Add effect of a thunderstorm
        GameObject[] enemiess = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemiess.Length > 0)
        {
            foreach(GameObject enemy in enemiess)
            {
                enemy.GetComponent<AIStats>().GetDmg(ThunerDamage + 20);
            }
        }
    }
    public void Ability6()
    {
        GameObject.Find("GameManager").GetComponent<EnemyController>().slownessEffect *= 0.9f;
    }
    public void Ability7()
    {
        PS.LifeSaver(8);
    }
    public void Ability8()
    {
        PS.LifeSteal(1);
    }
    public void Ability9()
    {
        multiShot = 1;
    }
    public void Ability10()
    {
        
    }
    public void Ability11()
    {
        
    }
    public void Ability12()
    {
        
    }
    public void Ability13()
    {
        
    }
    public void Ability14()
    {
        
    }
    public void Ability15()
    {
        
    }
    public void Ability16()
    {
        
    }
    public void Ability17()
    {
        
    }
    public void Ability18()
    {
        
    }

    // Next abilities are dog abilities
    // Haski attacker
    public void Ability19()
    {
        HaskiAI.HaskiNextAttack = HaskiNextAttack;
        // Next attack deals 300% of AD every 15
    }
    public void Ability20()
    {
        HaskiAI.AD += Mathf.CeilToInt(AD/100);
        HaskiAI.MaxHP += Mathf.CeilToInt(HaskiAI.MaxHP/100);
        Debug.Log("Increased for ad :"+Mathf.CeilToInt(AD/100) + " and hp: " + Mathf.CeilToInt(HaskiAI.MaxHP/100));
        // Increment health and attack by 1% every 20/15/10 seconds
    }
    //samoyed tank
    public void Ability21()
    {
        SamoyedAI.MaxHP += 50;
        SamoyedAI.Armor += 5;
        expBar.ChangeBool2();
        // Gain bonus HP and Armor for each 20 kills we make
    }
    public void Ability22()
    {
        GameObject[] allies = GameObject.FindGameObjectsWithTag("Allies");
        foreach(GameObject ally in allies)
        {
            ally.GetComponent<FriendlyAI>().DamageRemoverFromSamoyed = DamageRemoverFromSamoyed;
        }
        GameObject.Find("Player").GetComponent<PlayerStats>().DamageRemoverFromSamoyed = DamageRemoverFromSamoyed;
        // Make allies take 20/50/70% less damage for 5/7/10 seconds
    }
    //Shiba money money
    public void Ability23()
    {
        expBar.bonusIncluded(bonusMoney);
        // Increase amount of coins enemies drop for 1/2/3 gold
    }
    public void Ability24()
    {
        ShibaAI.AD += expBar.gold;
        Invoke("ReturnBonus", returnBonusGoldAD);
        // Gain bonus AD equal to amount of coins we have and bonus 1 attack speed for 4/7/10 seconds
    }
    
    void ReturnBonus()
    {
        ShibaAI.AD -= expBar.gold;
    }

    //Labrador heals
    public void Ability25()
    {
        GameObject[] enemiess = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemiess)
        {
            float distances = Vector3.Distance(transform.position, enemy.transform.position);
            if(distances < 6f)
            {
                enemy.GetComponent<AIStats>().GetDmg((Mathf.CeilToInt((LabradorAI.MaxHP/100)*HPtoDamageMultiplier)));
            }
        }
        // Deal 2/5/8% of max health damage to surrounding enemies every second
    }
    public void Ability26()
    {
        LabradorAI.HP += (Mathf.CeilToInt((LabradorAI.HP/100)*LabradorHPHeal));
        // Heals us every 2 seconds for 1/3/5% of Labradors max health health
    }
    //samhusky assasin
    public void Ability27()
    {
        for(int i = 0; i < 3; i++)
        {
            GameObject dog = Instantiate(SamhuskyAsset, GameObject.Find("Samhusky").transform.position, Quaternion.identity);
            dog.name = "Dog";
            dog.GetComponent<FriendlyAI>().MaxHP = (Mathf.CeilToInt((LabradorAI.HP/100)*SamhuskyHPToClone));
        }
        // Multiply 1/2/3 times (clones has 25/50/75% of AD and max HP) every 20 seconds
    }
    public void Ability28()
    {
        if(SamhuskyAI.AD > 100)
        {
            SamhuskyAI.AD += (Mathf.CeilToInt((SamhuskyAI.AD/100)*2));
        }
        
        // Gain 2% damage incrase every 30/22/14 enemies we killed
    }



    public void UpgradeAbility1()
    {
        numOfTimes += 5;
    }
    public void UpgradeAbility2()
    {
        fireballDamage += Mathf.RoundToInt(PS.AD * 0.3f);
    }
    public void UpgradeAbility3()
    {
        ArmorAmount += 5;
        AbilityCD3 -= 2f;
    }
    public void UpgradeAbility4()
    {
        shieldAmount += Mathf.RoundToInt(PS.MaxHP * 0.4f);
    }
    public void UpgradeAbility5()
    {
        ThunerDamage += Mathf.RoundToInt(PS.AD * 0.2f);
    }
    public void UpgradeAbility6()
    {
        GameObject.Find("GameManager").GetComponent<EnemyController>().slownessEffect *= 0.9f;
    }
    public void UpgradeAbility7()
    {
        PS.LifeSaver(0);
    }
    public void UpgradeAbility8()
    {
        PS.LifeSteal(0);
    }
    public void UpgradeAbility9()
    {
        // Sivir w, multi target attack
        multiShot += 4;
    }
    public void UpgradeAbility10()
    {
        
    }
    public void UpgradeAbility11()
    {
        
    }
    public void UpgradeAbility12()
    {
        
    }
    public void UpgradeAbility13()
    {
        
    }
    public void UpgradeAbility14()
    {
        
    }
    public void UpgradeAbility15()
    {
        
    }
    public void UpgradeAbility16()
    {
        
    }
    public void UpgradeAbility17()
    {
        
    }
    public void UpgradeAbility18()
    {
        
    }

    // Next abilities are dog abilities

    public void UpgradeAbility19()
    {
        HaskiNextAttack += 1;
    }
    public void UpgradeAbility20()
    {
        CancelInvoke("Ability20");
        AbilityCD20 -= 5;
        InvokeRepeating("Ability20", 0f, AbilityCD20);
        
    }
    public void UpgradeAbility21()
    {
        // Non
    }
    public void UpgradeAbility22()
    {
        DamageRemoverFromSamoyed += 20;
        Ability22();
    }
    public void UpgradeAbility23()
    {
        bonusMoney += 1;
    }
    public void UpgradeAbility24()
    {
        returnBonusGoldAD += 3;
    }
    public void UpgradeAbility25()
    {
        HPtoDamageMultiplier += 3;
    }
    public void UpgradeAbility26()
    {
        LabradorHPHeal += 2;
    }
    public void UpgradeAbility27()
    {
        SamhuskyHPToClone += 25;
    }
    public void UpgradeAbility28()
    {
        killsNeededForIncrement -= 8;
        Ability28();
        expBar.ChangeBool(killsNeededForIncrement);
    }


}
