using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScaler : MonoBehaviour {

    Text text;
    public int divisionAmount = 50;

    private void Start()
    {
        text = GetComponent<Text>();
        text.fontSize = Screen.width / divisionAmount;
    }
}
