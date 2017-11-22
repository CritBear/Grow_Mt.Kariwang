using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour {

    public Transform[] mountains = new Transform[3];
    public GameObject nextPanel;

    public AudioSource soundEff;
    public Text levelText;
    public Text heartText;
    public Text nextHeartText;
    public Text costText;
    public string displayName;

    public string upgradeName;

    [HideInInspector]
    public int heartByUpgrade;
    public int startHeartByUpgrade;

    [HideInInspector]
    public int currentCost;
    public int startCurrentCost;

    [HideInInspector]
    public int level = 1;

    public float upgradePow;
    public float costPow;
    
    private Button button;
    private int mountainCount;
    private bool isNextPanelSet = false;

    private void Start()
    {
        button = GetComponent<Button>();

        DataController.Instance.LoadUpgradeButton(this);
        UpdateUI();

        // Scene 초기설정 - mountain
        mountainCount = Mathf.FloorToInt(level / 20);
        for(int i = mountainCount; i < 3; i++)
        {
            mountains[i].Translate(Vector3.down * 20);
        }

        // Scene 초기설정 - TreeUpgradePanel
        if(level >= 2)
        {
            isNextPanelSet = true;
            nextPanel.SetActive(true);
        }

        InvokeRepeating("HeartCheck", 0, 0.1f);
    }

    void HeartCheck()
    {
        if(DataController.Instance.heart < currentCost)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }

    public void PurchaseUpgrade()
    {
        if (DataController.Instance.heart >= currentCost)
        {
            soundEff.Play();
            DataController.Instance.heart -= currentCost;
            level++;

            if(mountainCount < 3 && level >= (mountainCount + 1) * 20)
            {
                RaiseMountain(mountainCount);
                mountainCount++;
            }

            if(!isNextPanelSet && level >= 10)
            {
                isNextPanelSet = true;
                nextPanel.SetActive(true);
            }

            DataController.Instance.heartPerClick += heartByUpgrade;

            UpdateUpgrade();
            UpdateUI();
            DataController.Instance.SaveUpgradeButton(this);
        }
    }

    void RaiseMountain(int mountainNum)
    {
        GameObject.Find("Mountains").GetComponent<MountainShake>().ShakeMountain(5);
        mountains[mountainNum].Translate(Vector3.up * 20);
        StartCoroutine(SmoothRaise(mountainNum));
    }

    IEnumerator SmoothRaise(int mountainNum)
    {
        float raiseTime = 5;
        float step = 0.0f;
        float rate = 1.0f / raiseTime;
        float smoothStep = 0.0f;
        float lastStep = 1.0f;
        while(step < 1.0f)
        {
            step += Time.deltaTime * rate;
            smoothStep = Mathf.SmoothStep(0.0f, 1.0f, step);
            mountains[mountainNum].Translate(Vector3.up * 20 * (smoothStep - lastStep));
            lastStep = smoothStep;
            yield return null;
        }
        if (step > 1.0f) mountains[mountainNum].Translate(Vector3.up * 20 * (1.0f - lastStep));
    }

    void UpdateUpgrade()
    {
        heartByUpgrade = (int)(startHeartByUpgrade * Mathf.Pow(upgradePow, level - 1));

        currentCost = (int)(startCurrentCost * Mathf.Pow(costPow, level - 1));
    }

    void UpdateUI()
    {
        levelText.text = "레벨" + level + " " + displayName;
        heartText.text = DataController.Instance.heartPerClick + " 생명력/탭";
        nextHeartText.text = "+" + heartByUpgrade + " 생명력";
        costText.text = currentCost.ToString();
    }
}
