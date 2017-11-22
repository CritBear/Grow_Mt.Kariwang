using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton_Tree : MonoBehaviour {

    public List<GameObject> trees = new List<GameObject>();
    public GameObject nextPanel;
    public GameObject thisMountain;
    public ParticleSystem treePlantEff;
    public GameObject infoPanel;

    public AudioSource soundEff;
    public Text levelText;
    public Text heartText;
    public Text nextHeartText;
    public Text costText;
    public string displayName;
    public int treePanelNum;

    public string upgradeName;

    [HideInInspector]
    public int heartByUpgrade;
    public int startHeartByUpgrade;

    [HideInInspector]
    public int currentCost;
    public int startCurrentCost;

    [HideInInspector]
    public int level = 1;

    [HideInInspector]
    public int heartPerSec;

    public float upgradePow;
    public float costPow;

    private Button button;
    private int treeCount = 0;
    private bool isNextPanelSet = false;

    private void Start()
    {
        button = GetComponent<Button>();

        DataController.Instance.LoadUpgradeButton_Tree(this);
        UpdateUI();

        if (nextPanel == null)
        {
            isNextPanelSet = true;
        }

        //Scene 초기설정
        treeCount = Mathf.FloorToInt(level / 5);
        for(int i = 0; i <= treeCount; i++)
        {
            trees[i].SetActive(true);
        }

        //초기 nextPanelSet
        if (level >= 10)
        {
            isNextPanelSet = true;
            nextPanel.SetActive(true);
        }

        InvokeRepeating("HeartCheck", 0, 0.1f);
    }

    private void OnEnable()
    {
        treeCount++;
        trees[0].SetActive(true);
        ParticleSystem plantEff = Instantiate(treePlantEff, trees[0].transform.position, trees[0].transform.rotation);
        Destroy(plantEff.gameObject, 2);
        StartCoroutine(AddHeartLoop());
    }

    IEnumerator AddHeartLoop()
    {
        while (true)
        {
            DataController.Instance.heart += heartPerSec;
            yield return new WaitForSeconds(1.0f);
        }
    }

    void HeartCheck()
    {
        if (DataController.Instance.heart < currentCost)
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
            if (!isNextPanelSet && level >= 9)
            {
                if (thisMountain.transform.position.y < -10)
                {
                    infoPanel.SetActive(true);
                    infoPanel.GetComponent<InfoPanelController>().Info("가리왕산 레벨 " + (treePanelNum + 1) * 20 + " 필요");
                    return;
                }
            }
            soundEff.Play();
            DataController.Instance.heart -= currentCost;
            level++;

            if(treeCount < 20 && level >= (treeCount + 1) * 5)
            {
                treeCount++;
                trees[treeCount].SetActive(true);

                ParticleSystem plantEff = Instantiate(treePlantEff, trees[treeCount].transform.position, trees[treeCount].transform.rotation);
                Destroy(plantEff.gameObject, 2);
            }

            if (!isNextPanelSet && level >= 10)
            {
                isNextPanelSet = true;
                nextPanel.SetActive(true);
            }

            heartPerSec += heartByUpgrade;

            UpdateUpgrade();
            UpdateUI();
            DataController.Instance.SaveUpgradeButton_Tree(this);
        }
    }

    void UpdateUpgrade()
    {
        heartByUpgrade = (int)(startHeartByUpgrade * Mathf.Pow(upgradePow, level - 1));

        currentCost = (int)(startCurrentCost * Mathf.Pow(costPow, level - 1));
    }

    void UpdateUI()
    {
        levelText.text = "레벨" + level + " " + displayName;
        heartText.text = heartPerSec + " 생명력/초";
        nextHeartText.text = "+" + heartByUpgrade + " 생명력";
        costText.text = currentCost.ToString();
    }
}
