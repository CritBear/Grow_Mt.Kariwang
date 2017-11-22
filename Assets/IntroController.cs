using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour {

    public Image image;

    Text text;
    List<string> say = new List<string>();
    int currentSay = 0;

    private void Start()
    {
        text = GetComponent<Text>();
        say.Add("강원도 정선");
        say.Add("평창 올림픽이 치뤄진 후");
        say.Add("파헤쳐진 몸을 회복해나가는");
        say.Add("가리왕산의 모습이다");
        say.Add("");
        text.text = say[currentSay];

        StartCoroutine(StartSay());
    }

    IEnumerator StartSay()
    {
        image.raycastTarget = false;
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(FadeInText());
        yield return new WaitForSeconds(1.5f);
        image.raycastTarget = true;
    }

    public void NextSay()
    {
        StartCoroutine(Next());
    }

    IEnumerator Next()
    {
        image.raycastTarget = false;
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(1.5f);

        if(currentSay >= 3)
        {
            SceneManager.LoadScene("Main");
        }

        currentSay++;
        text.text = say[currentSay];
        StartCoroutine(FadeIn());
        yield return new WaitForSeconds(1.5f);
        image.raycastTarget = true;
    }

    IEnumerator FadeInText()
    {
        for (float i = 0; i <= 1f; i += 0.01f)
        {
            Color color = new Vector4(1, 1, 1, i);
            text.color = color;
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator FadeIn()
    {
        for (float i = 0; i <= 1f; i += 0.01f)
        {
            Color color = new Vector4(1, 1, 1, i);
            text.color = color;
            image.color = color;
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator FadeOut()
    {
        for (float i = 1f; i >= 0; i -= 0.01f)
        {
            Color color = new Vector4(1, 1, 1, i);
            text.color = color;
            image.color = color;
            yield return new WaitForSeconds(0.01f);
        }
    }

}
