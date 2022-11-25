using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeMenuScript : MonoBehaviour
{
    public string mainMenu, gameName;
    public Text MoneyText;
    public Text SpeedCount, SpeedCost;
    public Text HealthCount, HealthCost;
    public Text DamageCount, DamageCost;
    public Text FireRateCount, FireRateCost;
    public Text RapidFireCost;
    public Toggle RapidFireToggle;
    // Start is called before the first frame update
    void Start()
    {
        //temporary for debug purposes
        //PlayerPrefs.SetInt("Money", 1000000000);
        
        //check current state of every item stored in in player prefs and set prices accordingly
        MoneyText.text = PlayerPrefs.GetInt("Money").ToString();
        
        int tempspeed = PlayerPrefs.GetInt("SpeedLevel");
        SpeedCount.text = tempspeed.ToString();
        if (tempspeed < 100) {
            SpeedCost.text = ((tempspeed*tempspeed*100) + 900).ToString();
        }
        else {
            SpeedCost.text = "";
        }

        int temphealth = PlayerPrefs.GetInt("HealthLevel");
        HealthCount.text = temphealth.ToString();
        if (temphealth < 100) {
            HealthCost.text = ((temphealth*temphealth*100) + 900).ToString();
        }
        else {
            HealthCost.text = "";
        }
        
        int tempdamage = PlayerPrefs.GetInt("DamageLevel");
        DamageCount.text = tempdamage.ToString();
        if (tempdamage < 100) {
            DamageCost.text = ((tempdamage*tempdamage*100) + 900).ToString();
        }
        else {
            DamageCost.text = "";
        }
        
        int tempfirerate = PlayerPrefs.GetInt("FireRateLevel");
        FireRateCount.text = tempfirerate.ToString();
        if (tempfirerate < 100) {
            FireRateCost.text = ((tempfirerate*tempfirerate*100) + 900).ToString();
        }
        else {
            FireRateCost.text = "";
        }
        
        int temprapidfire = PlayerPrefs.GetInt("RapidFireLevel");
        if (temprapidfire < 1)
        {
            
            RapidFireCost.text = "500000";
            RapidFireToggle.isOn = false;
        }
        else {
            RapidFireCost.text = "";
             RapidFireToggle.isOn = true;
        }
    }
    
    public void BuySpeed()
    {
        int tempspeed = PlayerPrefs.GetInt("SpeedLevel");
        int tempmoney = PlayerPrefs.GetInt("Money");
        
        if ((tempspeed*tempspeed*100)+900 <= tempmoney && tempspeed < 100)
        {
            PlayerPrefs.SetInt("SpeedLevel", tempspeed + 1);
            PlayerPrefs.SetInt("Money", tempmoney - ((tempspeed*tempspeed*100) + 900));

            int newtempspeed = PlayerPrefs.GetInt("SpeedLevel");
            int newtempmoney = PlayerPrefs.GetInt("Money");
            SpeedCount.text = newtempspeed.ToString();
            if(newtempspeed < 100) {
                SpeedCost.text = ((newtempspeed * newtempspeed*100)+900).ToString();
            }
            else
            {
                SpeedCost.text = "";
            }
            MoneyText.text = newtempmoney.ToString();
        }
    }

    public void BuyHealth()
    {
        int temphealth = PlayerPrefs.GetInt("HealthLevel");
        int tempmoney = PlayerPrefs.GetInt("Money");
        
        if ((temphealth*temphealth*100)+900 <= tempmoney && temphealth < 100)
        {
            PlayerPrefs.SetInt("HealthLevel", temphealth + 1);
            PlayerPrefs.SetInt("Money", tempmoney - ((temphealth*temphealth*100) + 900));

            int newtemphealth = PlayerPrefs.GetInt("HealthLevel");
            int newtempmoney = PlayerPrefs.GetInt("Money");
            HealthCount.text = newtemphealth.ToString();
            if(newtemphealth < 100) {
                HealthCost.text = ((newtemphealth * newtemphealth*100)+900).ToString();
            }
            else
            {
                HealthCost.text = "";
            }
            MoneyText.text = newtempmoney.ToString();
        }
    }

    public void BuyDamage()
    {
        int tempdamage = PlayerPrefs.GetInt("DamageLevel");
        int tempmoney = PlayerPrefs.GetInt("Money");
        
        if ((tempdamage*tempdamage*100)+900 <= tempmoney && tempdamage < 100)
        {
            PlayerPrefs.SetInt("DamageLevel", tempdamage + 1);
            PlayerPrefs.SetInt("Money", tempmoney - ((tempdamage*tempdamage*100) + 900));

            int newtempdamage = PlayerPrefs.GetInt("DamageLevel");
            int newtempmoney = PlayerPrefs.GetInt("Money");
            DamageCount.text = newtempdamage.ToString();
            if(newtempdamage < 100) {
                DamageCost.text = ((newtempdamage * newtempdamage*100)+900).ToString();
            }
            else
            {
                DamageCost.text = "";
            }
            MoneyText.text = newtempmoney.ToString();
        }
    }

    public void BuyFireRate()
    {
        int tempfirerate = PlayerPrefs.GetInt("FireRateLevel");
        int tempmoney = PlayerPrefs.GetInt("Money");
        
        if ((tempfirerate*tempfirerate*100)+900 <= tempmoney && tempfirerate < 100)
        {
            PlayerPrefs.SetInt("FireRateLevel", tempfirerate + 1);
            PlayerPrefs.SetInt("Money", tempmoney - ((tempfirerate*tempfirerate*100) + 900));

            int newtempfirerate = PlayerPrefs.GetInt("FireRateLevel");
            int newtempmoney = PlayerPrefs.GetInt("Money");
            FireRateCount.text = newtempfirerate.ToString();
            if(newtempfirerate < 100) {
                FireRateCost.text = ((newtempfirerate * newtempfirerate*100)+900).ToString();
            }
            else
            {
                FireRateCost.text = "";
            }
            MoneyText.text = newtempmoney.ToString();
        }
    }

    public void BuyRapidfire()
    {
        
        int temprapidfire = PlayerPrefs.GetInt("RapidFireLevel");
        int tempmoney = PlayerPrefs.GetInt("Money");

        if (500000 <= tempmoney && temprapidfire < 1)
        {
            PlayerPrefs.SetInt("RapidFireLevel", temprapidfire + 1);
            PlayerPrefs.SetInt("Money", tempmoney - 500000);

            int newtemprapidfire = PlayerPrefs.GetInt("RapidFireLevel");
            int newtempmoney = PlayerPrefs.GetInt("Money");
            //add a thing here that sets the checkbox to the other option
            RapidFireToggle.isOn = true;
            
            RapidFireCost.text = "";
            MoneyText.text = newtempmoney.ToString();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameName);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
