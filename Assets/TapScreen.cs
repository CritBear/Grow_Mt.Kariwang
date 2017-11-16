using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class TapScreen : MonoBehaviour {

    public Text text;

    private int touchCount = 0;
    private TouchPad m_TouchPad;

    private void Start()
    {
        m_TouchPad = GetComponent<TouchPad>();
    }

    public void Tap()
    {
        DataController.Instance.heart += DataController.Instance.heartPerClick;
        text.text = DataController.Instance.heart.ToString();

        StartCoroutine(StopDrag());
    }

    IEnumerator StopDrag()
    {
        touchCount++;
        if(touchCount > 0)
        {
            m_TouchPad.m_Dragging = false;
        }

        yield return new WaitForSeconds(0.1f);

        touchCount--;
        if(touchCount <= 0)
        {
            m_TouchPad.m_Dragging = true;
        }
    }
}
