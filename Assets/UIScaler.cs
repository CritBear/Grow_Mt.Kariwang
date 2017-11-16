using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScaler : MonoBehaviour {

    public float relativeWidth;
    public float relativeHeight;

    private void Start()
    {
        if(relativeWidth != 0)
        {
            GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width * relativeWidth);
        }
        if (relativeHeight != 0)
        {
            GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height * relativeHeight);
        }
    }
}
