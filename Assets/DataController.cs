using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                return 0;
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
        PlayerPrefs.DeleteAll();
    }

    private int m_HeartPerClick = 0;

    public int heartPerClick
    {
        get
        {
            return PlayerPrefs.GetInt("HeartPerClick", 1);
        }
        set
        {
            PlayerPrefs.SetInt("HeartPerClick", value);
        }
    }

    public void LoadUpgradeButton(UpgradeButton upgradeButton)
    {
        string key = upgradeButton.upgradeName;

        //upgradeButton.level = PlayerPrefs.GetInt(key + "_level", 1);
        //upgradeButton.goldByUpgrade = PlayerPrefs.GetInt(key + "_goldByUpgrade", upgradeButton.startGoldByUpgrade);
        //upgradeButton.currentCost = PlayerPrefs.GetInt(key + "_cost", upgradeButton.startCurrentCost);
    }

    public void SaveUpgradeButton(UpgradeButton upgradeButton)
    {
        string key = upgradeButton.upgradeName;

        //PlayerPrefs.SetInt(key + "_level", upgradeButton.level);
        //PlayerPrefs.SetInt(key + "_goldByUpgrade", upgradeButton.goldByUpgrade);
        //PlayerPrefs.SetInt(key + "_cost", upgradeButton.currentCost);
    }
}
