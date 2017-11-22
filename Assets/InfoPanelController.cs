using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanelController : MonoBehaviour {

    public Text text;

    private int orderCount = 0;

	public void Info(string info)
    {
        transform.SetAsLastSibling();
        text.text = info;
        StartCoroutine(ShowInfo());
    }

    IEnumerator ShowInfo()
    {
        orderCount++;
        if(orderCount > 0)
        {
            gameObject.SetActive(true);
        }

        yield return new WaitForSeconds(3f);

        orderCount--;
        if(orderCount <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
