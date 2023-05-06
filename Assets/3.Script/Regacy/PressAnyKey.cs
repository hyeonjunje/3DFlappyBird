using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressAnyKey : MonoBehaviour
{
    private Text pressAnyKeyText;

    private void Awake()
    {
        pressAnyKeyText = GetComponent<Text>();
        StartCoroutine(BlinkCo());
    }

    private IEnumerator BlinkCo()
    {
        while(pressAnyKeyText.color.a<1)
        {
            pressAnyKeyText.color = new Color(pressAnyKeyText.color.r, pressAnyKeyText.color.g, pressAnyKeyText.color.b, pressAnyKeyText.color.a + (Time.deltaTime / 2.0f));
            yield return null;

        }
        StartCoroutine(BlinkCo2());
    }

    IEnumerator BlinkCo2()
    {
        while (pressAnyKeyText.color.a>0)
        {
            pressAnyKeyText.color = new Color(pressAnyKeyText.color.r, pressAnyKeyText.color.g, pressAnyKeyText.color.b, pressAnyKeyText.color.a - (Time.deltaTime / 2.0f));
            yield return null;

        }
        StartCoroutine(BlinkCo());
    }




}
