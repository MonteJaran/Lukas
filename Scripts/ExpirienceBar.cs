using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExpirienceBar : MonoBehaviour
{
    public RectTransform progressBar;
    public float time;
    public TextMeshProUGUI GTime;
    public TextMeshProUGUI GKills;
    public TextMeshProUGUI GGold;
    public int maxExperience = 10;
    public int currentExperience = 0;
    private int level = 0;
    public int kills;
    public int killsNeeded1;
    public int killsNeeded2;
    public int gold;
    private int bonusCoins;
    public GameObject SkillsPlane;
    private int killCount1 = -999999;
    private int killCount2 = -999999;
    public bool canIncrement = false;
    public bool canIncrement2 = false;
    private void Start()
    {
        UpdateExperienceBar();
    }
    public void bonusIncluded(int bonus)
    {
        bonusCoins = bonus;
        
        Invoke("BreakBonusIncluded",7f);
    }

    void BreakBonusIncluded()
    {
        bonusCoins = 0;
    }
    public void GainExperience(int experiencePoints)
    {
        currentExperience += experiencePoints;
        if (currentExperience > maxExperience)
        {
            level++;
            currentExperience = maxExperience;
            maxExperience += 2 * level;
            SkillsPlane.SetActive(true);
            TimeManager.Instance.TogglePause();

            // Toggle it again after u pick an update
        }
        UpdateExperienceBar();
    }

    private void UpdateExperienceBar()
    {
        float fillAmount = (float)currentExperience / maxExperience;
        progressBar.anchorMax = new Vector2(fillAmount, progressBar.anchorMax.y);
    }

    public void Update()
    {
        time += Time.deltaTime;
        GTime.text = time.ToString("F2");
    }

    public void KillingUnit(int goldWorth)
    {
        kills++;
        killCount1++;
        killCount2++;
        gold += goldWorth + bonusCoins;
        if(killCount1 <= killsNeeded1 && canIncrement)
        {
            killCount1 = 0;
            GameObject.Find("Player").GetComponent<AbilityTree>().Ability28();
        }
        if(20 <= killsNeeded2 && canIncrement2)
        {
            GameObject.Find("Player").GetComponent<AbilityTree>().Ability21();
        }
        GKills.text = ("Kills: " + kills);        
    }

    public void ChangeBool(int k)
    {
        killsNeeded1 = k;
        canIncrement = true;
        killCount1 = 0;
    }

    public void ChangeBool2()
    {
        canIncrement2 = true;
        killCount2 = 0;
    }
}
