using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MenuController : MonoBehaviour {

    public RectTransform m_ButtonRect;
    public int m_MenuNum;
    public string m_MenuName;

    private RectTransform m_PanelRect;

    private bool isMenuUp = false;
    private Vector3 originPos;
    private Vector3 targetPos;
    private int m_ScreenWidth;
    private int m_ScreenHeight;
    private float m_PanelWidth;

    private void Start()
    {
        m_ScreenWidth = Screen.width;
        m_ScreenHeight = Screen.height;

        // MenuPanel Size, Position
        m_PanelWidth = m_ScreenWidth / 2.5f;

        m_PanelRect = GetComponent<RectTransform>();
        m_PanelRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, m_PanelWidth);
        m_PanelRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, m_ScreenHeight);
        m_PanelRect.anchoredPosition = new Vector2(m_PanelWidth / 2, 0);

        originPos = new Vector2(m_PanelWidth / 2, 0);
        targetPos = originPos;

        // MenuButton Size, Position
        m_ButtonRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, m_ScreenWidth / 10);
        m_ButtonRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, m_ScreenHeight / 5);
        m_ButtonRect.anchoredPosition = new Vector2(m_ScreenWidth / 20 * (-1), m_ScreenHeight / 10 + m_MenuNum * m_ScreenHeight / 5);
    }

    private void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown(m_MenuName))
        {
            if (!isMenuUp)
            {
                transform.SetAsLastSibling();
                targetPos = new Vector2(m_PanelWidth / 2 * (-1), 0);
                isMenuUp = true;
            }
            else
            {
                targetPos = originPos;
                isMenuUp = false;
            }
        }
        m_PanelRect.anchoredPosition = Vector2.Lerp(m_PanelRect.anchoredPosition, targetPos, 5 * Time.deltaTime);
    }
}
