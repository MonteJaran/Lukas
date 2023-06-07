using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PickAnAbility : MonoBehaviour
{
    public TextMeshProUGUI TextToDisplay;
    public AbilityTree AT;
    public int num;

//    
    public void Start()
    {
        AT = GameObject.Find("Player").GetComponent<AbilityTree>();
        int randomNum = Random.Range(0,34);
        num = randomNum;
        switch (randomNum)
        {
            case 1:
                Ability1();
                break;
            case 2:
                Ability2();
                break;
            case 3:
                Ability3();
                break;
            case 4:
                Ability4();
                break;
            case 5:
                Ability5();
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
                Ability10();
                break;
            case 11:
                Ability11();
                break;
            case 12:
                Ability12();
                break;
            case 13:
                Ability13();
                break;
            case 14:
                Ability14();
                break;
            case 15:
                Ability15();
                break;
            case 16:
                Ability16();
                break;
            case 17:
                Ability17();
                break;
            case 18:
                Ability18();
                break;
            case 19:
                Ability19();
                break;
            case 20:
                Ability20();
                break;
            case 21:
                Ability21();
                break;
            case 22:
                Ability22();
                break;
            case 23:
                Ability23();
                break;
            case 24:
                Ability24();
                break;
            case 25:
                Ability25();
                break;
            case 26:
                Ability26();
                break;
            case 27:
                Ability27();
                break;
            case 28:
                Ability28();
                break;
            case 29:
                Ability29();
                break;
            case 30:
                Ability30();
                break;
            case 31:
                Ability31();
                break;
            case 32:
                Ability32();
                break;
            case 33:
                Ability33();
                break;
            default:
                // Handle the default case when randomNum doesn't match any specified cases
                break;
        }

    }

//


//    
    void Ability1()
    {
        TextToDisplay.text = "Every 5 seconds, fire 5 ( * amount of upgrades) rapid basic attacks, each doing 110% of your AD!";
    }
     void Ability2()
    {   
        TextToDisplay.text = "Fire a fireball towards closest enemy. Fireball will do 150 ( + 20% AD permanent bonus damage per upgrade) to enemies within 5 meters, and 50% of current damage to enemies up to 10 meters. AOE!";
    }
    
    void Ability3()
    {
        TextToDisplay.text = "Reduce Armor by 5 ( * amount of upgrades) to all enemies on the map right now.";
    }

     void Ability4()
    {
        TextToDisplay.text = "Get a shield equivalent to 20% ( + 5% amount of upgrades) of your Max health. Repeat every 5 seconds.";
    }

     void Ability5()
    {
        TextToDisplay.text = "Release thunderstorm every 5 seconds, with a damane equivalent to 20 ( + 7 AD per upgrade) of damage dealt.";
    }
     void Ability6()
    {
        TextToDisplay.text = "";
    }
     void Ability7()
    {
        
    }
     void Ability8()
    {
        
    }
     void Ability9()
    {
        
    }
     void Ability10()
    {
        
    }
     void Ability11()
    {
        
    }
     void Ability12()
    {
        
    }
     void Ability13()
    {
        
    }
     void Ability14()
    {
        
    }
     void Ability15()
    {
        
    }
     void Ability16()
    {
        
    }
     void Ability17()
    {
        
    }
     void Ability18()
    {
        
    }

    // Next abilities are dog abilities

     void Ability19()
    {
        
    }
     void Ability20()
    {
        
    }
     void Ability21()
    {
        
    }
     void Ability22()
    {
        
    }
     void Ability23()
    {
        
    }
     void Ability24()
    {
        
    }
     void Ability25()
    {
        
    }
     void Ability26()
    {
        
    }
     void Ability27()
    {
        
    }
     void Ability28()
    {
        
    }
     void Ability29()
    {
        
    }
     void Ability30()
    {
        
    }
     void Ability31()
    {
        
    }
     void Ability32()
    {
        
    }
     void Ability33()
    {
        
    }
//
    public void ChooseAbility()
    {
        AT.ActivateAbility(num);
        GameObject.Find("PanelForAbilities").SetActive(false);
        TimeManager.Instance.TogglePause();
    }
}
