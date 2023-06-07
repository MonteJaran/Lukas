using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int MaxHP;
    public int HP;
    public float Speed;
    public int AD;
    public int Armor;
    public int Shield;
    public int PassiveHealing;
    public int healing;
    public int burst;
    public bool SavedFromNextAttack;
    private int PotentialHealing;
    private int PotentialDMG;
    private bool activatedSaver =  false;
    private float lifeTimer;
    public float lifeSteal;
    public bool lifeStealbool;
    public int DamageRemoverFromSamoyed;
    public int liteStealpercentage;
    void Start()
    {
        InvokeRepeating("Healing", 1f, 1f);
        Invoke("GiveStats", 5f);
    }

    public int GetAD()
    {
        return AD;
    }
    public void GiveStats()
    {
        healing = 10;
        burst = 2;
    }
    public void GetDmg(int DMG)
    {

        if(Shield > DMG)
        {
            Shield -= DMG;
            return;
        }
        if(SavedFromNextAttack)
        {
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
        
        
    }
    

    public void Healing()
    {
        HP += healing;
        if(HP > MaxHP) { HP = MaxHP; }
        if(healing < 0)
        {
            GetDmg(healing);
        }
    }

    public void RemoveShield(int shieldAmount)
    {
        if(Shield > shieldAmount)
        {
            Shield -= shieldAmount;
            return;
        }
        Shield = 0;
    }

    public void LifeSaver(float timerS)
    {
        
        if(!activatedSaver)
        {
            lifeTimer = timerS;
            InvokeRepeating("saveShield", 0f, 7f);
        }
        
        else
        {
            lifeTimer--;
            CancelInvoke("saveShield");
            InvokeRepeating("saveShield", 0f, lifeTimer);
        }
    }

    public void saveShield()
    {
        SavedFromNextAttack = true;
    }

    public void LifeSteal(int i)
    {
        if(!lifeStealbool)
        {
            lifeStealbool = true;
            liteStealpercentage = i;
            return;
        }
        liteStealpercentage += 2;
    }
    public void HealFromDamage(int lifeSteal)
    {
        if(lifeStealbool)
        {
            HP += Mathf.CeilToInt((liteStealpercentage/100) * lifeSteal); 
        }
    }
}
