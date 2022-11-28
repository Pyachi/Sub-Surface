using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Written By:
//Sarah Glass
//Mark Scheidker
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
    private void Start()
    {
        //temporary for debug purposes
        //PlayerPrefs.SetInt("Money", 1000000000);

        //check current state of every item stored in in player prefs and set prices accordingly
        MoneyText.text = PlayerPrefs.GetInt("Money").ToString();

        var tempspeed = PlayerPrefs.GetInt("SpeedLevel");
        SpeedCount.text = tempspeed.ToString();
        if (tempspeed < 100)
            SpeedCost.text = (tempspeed * tempspeed * 100 + 900).ToString();
        else
            SpeedCost.text = "";

        var temphealth = PlayerPrefs.GetInt("HealthLevel");
        HealthCount.text = temphealth.ToString();
        if (temphealth < 100)
            HealthCost.text = (temphealth * temphealth * 100 + 900).ToString();
        else
            HealthCost.text = "";

        var tempdamage = PlayerPrefs.GetInt("DamageLevel");
        DamageCount.text = tempdamage.ToString();
        if (tempdamage < 100)
            DamageCost.text = (tempdamage * tempdamage * 100 + 900).ToString();
        else
            DamageCost.text = "";

        var tempfirerate = PlayerPrefs.GetInt("FireRateLevel");
        FireRateCount.text = tempfirerate.ToString();
        if (tempfirerate < 100)
            FireRateCost.text = (tempfirerate * tempfirerate * 100 + 900).ToString();
        else
            FireRateCost.text = "";

        var temprapidfire = PlayerPrefs.GetInt("RapidFireLevel");
        if (temprapidfire < 1)
        {
            RapidFireCost.text = "500000";
            RapidFireToggle.isOn = false;
        }
        else
        {
            RapidFireCost.text = "";
            RapidFireToggle.isOn = true;
        }
    }

    public void BuySpeed()
    {
        var tempspeed = PlayerPrefs.GetInt("SpeedLevel");
        var tempmoney = PlayerPrefs.GetInt("Money");

        if (tempspeed * tempspeed * 100 + 900 <= tempmoney && tempspeed < 100)
        {
            PlayerPrefs.SetInt("SpeedLevel", tempspeed + 1);
            PlayerPrefs.SetInt("Money", tempmoney - (tempspeed * tempspeed * 100 + 900));

            var newtempspeed = PlayerPrefs.GetInt("SpeedLevel");
            var newtempmoney = PlayerPrefs.GetInt("Money");
            SpeedCount.text = newtempspeed.ToString();
            if (newtempspeed < 100)
                SpeedCost.text = (newtempspeed * newtempspeed * 100 + 900).ToString();
            else
                SpeedCost.text = "";
            MoneyText.text = newtempmoney.ToString();
        }
    }

    public void BuyHealth()
    {
        var temphealth = PlayerPrefs.GetInt("HealthLevel");
        var tempmoney = PlayerPrefs.GetInt("Money");

        if (temphealth * temphealth * 100 + 900 <= tempmoney && temphealth < 100)
        {
            PlayerPrefs.SetInt("HealthLevel", temphealth + 1);
            PlayerPrefs.SetInt("Money", tempmoney - (temphealth * temphealth * 100 + 900));

            var newtemphealth = PlayerPrefs.GetInt("HealthLevel");
            var newtempmoney = PlayerPrefs.GetInt("Money");
            HealthCount.text = newtemphealth.ToString();
            if (newtemphealth < 100)
                HealthCost.text = (newtemphealth * newtemphealth * 100 + 900).ToString();
            else
                HealthCost.text = "";
            MoneyText.text = newtempmoney.ToString();
        }
    }

    public void BuyDamage()
    {
        var tempdamage = PlayerPrefs.GetInt("DamageLevel");
        var tempmoney = PlayerPrefs.GetInt("Money");

        if (tempdamage * tempdamage * 100 + 900 <= tempmoney && tempdamage < 100)
        {
            PlayerPrefs.SetInt("DamageLevel", tempdamage + 1);
            PlayerPrefs.SetInt("Money", tempmoney - (tempdamage * tempdamage * 100 + 900));

            var newtempdamage = PlayerPrefs.GetInt("DamageLevel");
            var newtempmoney = PlayerPrefs.GetInt("Money");
            DamageCount.text = newtempdamage.ToString();
            if (newtempdamage < 100)
                DamageCost.text = (newtempdamage * newtempdamage * 100 + 900).ToString();
            else
                DamageCost.text = "";
            MoneyText.text = newtempmoney.ToString();
        }
    }

    public void BuyFireRate()
    {
        var tempfirerate = PlayerPrefs.GetInt("FireRateLevel");
        var tempmoney = PlayerPrefs.GetInt("Money");

        if (tempfirerate * tempfirerate * 100 + 900 <= tempmoney && tempfirerate < 100)
        {
            PlayerPrefs.SetInt("FireRateLevel", tempfirerate + 1);
            PlayerPrefs.SetInt("Money", tempmoney - (tempfirerate * tempfirerate * 100 + 900));

            var newtempfirerate = PlayerPrefs.GetInt("FireRateLevel");
            var newtempmoney = PlayerPrefs.GetInt("Money");
            FireRateCount.text = newtempfirerate.ToString();
            if (newtempfirerate < 100)
                FireRateCost.text = (newtempfirerate * newtempfirerate * 100 + 900).ToString();
            else
                FireRateCost.text = "";
            MoneyText.text = newtempmoney.ToString();
        }
    }

    public void BuyRapidfire()
    {
        var temprapidfire = PlayerPrefs.GetInt("RapidFireLevel");
        var tempmoney = PlayerPrefs.GetInt("Money");

        if (500000 <= tempmoney && temprapidfire < 1)
        {
            PlayerPrefs.SetInt("RapidFireLevel", temprapidfire + 1);
            PlayerPrefs.SetInt("Money", tempmoney - 500000);

            var newtemprapidfire = PlayerPrefs.GetInt("RapidFireLevel");
            var newtempmoney = PlayerPrefs.GetInt("Money");
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