using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleUI : BaseUI
{
    [SerializeField]
    private Text pressAnyKeyText;

    private Coroutine blinkCo;

    public override void Exit()
    {
        gameObject.SetActive(false);

        if (blinkCo != null)
            StopCoroutine(blinkCo);
    }

    public override void Show()
    {
        gameObject.SetActive(true);

        if (blinkCo != null)
            StopCoroutine(blinkCo);
        blinkCo = StartCoroutine(BlinkCo());
    }

    private IEnumerator BlinkCo()
    {
        while (pressAnyKeyText.color.a < 1)
        {
            pressAnyKeyText.color = new Color(pressAnyKeyText.color.r, pressAnyKeyText.color.g, pressAnyKeyText.color.b, pressAnyKeyText.color.a + (Time.deltaTime / 2.0f));
            yield return null;

        }
        StartCoroutine(BlinkCo2());
    }

    private IEnumerator BlinkCo2()
    {
        while (pressAnyKeyText.color.a > 0)
        {
            pressAnyKeyText.color = new Color(pressAnyKeyText.color.r, pressAnyKeyText.color.g, pressAnyKeyText.color.b, pressAnyKeyText.color.a - (Time.deltaTime / 2.0f));
            yield return null;

        }
        StartCoroutine(BlinkCo());
    }
}
