using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScaler : MonoBehaviour {

    public bool isSquare = false;
    public float relativeWidth;
    public float relativeHeight;

    public float xPos;
    public float yPos;

    private void Start()
    {
        if(relativeWidth != 0)
        {
            GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width * relativeWidth);
        }

        if (isSquare)
        {
            GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.width * relativeWidth);
        }else if (relativeHeight != 0)
        {
            GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height * relativeHeight);
        }

        if(xPos != 0 || yPos !=0)
        {
            GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos * Screen.width, yPos * Screen.height);
        }
    }
}
