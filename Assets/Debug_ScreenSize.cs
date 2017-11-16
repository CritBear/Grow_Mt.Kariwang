using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debug_ScreenSize : MonoBehaviour {

    private void Start()
    {
        Text m_text = GetComponent<Text>();
        m_text.text = Screen.width.ToString();
    }
}
