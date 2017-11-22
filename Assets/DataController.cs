using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour {

    private static DataController instance;

    public static DataController Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<DataController>();

                if(instance == null)
                {
                    GameObject container = new GameObject("DataController");

                    instance = container.AddComponent<DataController>();
                }
            }
            return instance;
        }
    }

    // itembutton

    public long heart
    {
        get
        {
            if (!PlayerPrefs.HasKey("Heart"))
            {
                return 100000000;
            }
            string tmpHeart = PlayerPrefs.GetString("Heart");
            return long.Parse(tmpHeart);
        }
        set
        {
            PlayerPrefs.SetString("Heart", value.ToString());
        }
    }
    
    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
        if (!PlayerPrefs.HasKey("ViewIntro"))
        {
            PlayerPrefs.SetInt("ViewIntro", 1);
            SceneManager.LoadScene("Intro");
        }
    }

    private int m_HeartPerClick = 0;

    public int heartPerClick
    {
        get
        {
            return PlayerPrefs.GetInt("HeartPerClick", 10);
        }
        set
        {
            PlayerPrefs.SetInt("HeartPerClick", value);
        }
    }
    /*
    private int m_HeartPerSec = 0;

    public int heartPerSec
    {
        get
        {
            return PlayerPrefs.GetInt("HeartPerSec", 0);
        }
        set
        {
            PlayerPrefs.SetInt("HeartPerSec", value);
        }
    }*/

    // mountain upgrade
    public void LoadUpgradeButton(UpgradeButton upgradeButton)
    {
        string key = upgradeButton.upgradeName;

        upgradeButton.level = PlayerPrefs.GetInt(key + "_level", 1);
        upgradeButton.heartByUpgrade = PlayerPrefs.GetInt(key + "_heartByUpgrade", upgradeButton.startHeartByUpgrade);
        upgradeButton.currentCost = PlayerPrefs.GetInt(key + "_cost", upgradeButton.startCurrentCost);
    }

    public void SaveUpgradeButton(UpgradeButton upgradeButton)
    {
        string key = upgradeButton.upgradeName;

        PlayerPrefs.SetInt(key + "_level", upgradeButton.level);
        PlayerPrefs.SetInt(key + "_heartByUpgrade", upgradeButton.heartByUpgrade);
        PlayerPrefs.SetInt(key + "_cost", upgradeButton.currentCost);
    }

    // tree Upgrade
    public void LoadUpgradeButton_Tree(UpgradeButton_Tree upgradeButton)
    {
        string key = upgradeButton.upgradeName;

        upgradeButton.level = PlayerPrefs.GetInt(key + "_level", 1);
        upgradeButton.heartByUpgrade = PlayerPrefs.GetInt(key + "_heartByUpgrade", upgradeButton.startHeartByUpgrade);
        upgradeButton.currentCost = PlayerPrefs.GetInt(key + "_cost", upgradeButton.startCurrentCost);
        upgradeButton.heartPerSec = PlayerPrefs.GetInt(key + "_heartPerSec", upgradeButton.startHeartByUpgrade);
    }

    public void SaveUpgradeButton_Tree(UpgradeButton_Tree upgradeButton)
    {
        string key = upgradeButton.upgradeName;

        PlayerPrefs.SetInt(key + "_level", upgradeButton.level);
        PlayerPrefs.SetInt(key + "_heartByUpgrade", upgradeButton.heartByUpgrade);
        PlayerPrefs.SetInt(key + "_cost", upgradeButton.currentCost);
        PlayerPrefs.SetInt(key + "_heartPerSec", upgradeButton.heartPerSec);
    }
}
