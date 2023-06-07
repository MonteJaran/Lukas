using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStats : MonoBehaviour
{
    public int HP;
    public float Speed;
    public int AD;
    public float ADCD;
    public int Armor;
    public int Shield = 30;
    public bool canAttack = true;
    private int PotentialDMG;
    public int enemyLayer;
    public int allyLayer;
    public int goldWorth;

    void Start()
    {
        enemyLayer = LayerMask.NameToLayer("Enemy");
        allyLayer = LayerMask.NameToLayer("Ally");
        InvokeRepeating("StrengthEnemies", 45f, 45f);
    }
    public void GetDmg(int DMG)
    {
        if(Shield > DMG)
        {
            Shield -= DMG;
            return;
        }

        int preDamage = DMG - Shield;
        
        Shield = 0;
        if(preDamage < Armor)
        {
            return;
        }
        
        int ArmorReductionDMG = preDamage - Armor;
        HP -= ArmorReductionDMG;
        GameObject.Find("Player").GetComponent<PlayerStats>().HealFromDamage(ArmorReductionDMG);
        if(HP < 1)
        {
            GameObject.Find("EXPBar").GetComponent<ExpirienceBar>().GainExperience(1);
            GameObject.Find("EXPBar").GetComponent<ExpirienceBar>().KillingUnit(goldWorth);
            Destroy(gameObject);
        }
        
    }

    public void AttackAlly(Transform ally)
    {
        
        if(canAttack)
        {
            GameObject target = ally.gameObject;
            if(target.tag == "Player")
            {
                target.GetComponent<PlayerStats>().GetDmg(AD);
            }
            else if(target.layer == enemyLayer)
            {
                target.GetComponent<AIStats>().GetDmg(AD);
            }
            else if(target.layer == allyLayer)
            {
                target.GetComponent<FriendlyAI>().GetDmg(AD);
            }
            Invoke("CanAttackAgain", ADCD);
            canAttack = false;
        }    
    }

    void CanAttackAgain()
    {
        canAttack = true;
    }

    void StrengthEnemies()
    {
        HP += 20;
        AD += 5;
        Speed += 0.2f;
    }
}
