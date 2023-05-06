using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressAnyKey : MonoBehaviour
{
    Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
        StartCoroutine(BlinkCo());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.Instance.Scene.LoadScene(EScene.Lobby);
        }

        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                GameManager.Instance.Scene.LoadScene(EScene.Lobby);
            }
        }
    }


    IEnumerator BlinkCo()
    {
        while(text.color.a<1)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / 2.0f));
            yield return null;

        }
        StartCoroutine(BlinkCo2());
    }

    IEnumerator BlinkCo2()
    {
        while (text.color.a>0)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / 2.0f));
            yield return null;

        }
        StartCoroutine(BlinkCo());
    }




}
