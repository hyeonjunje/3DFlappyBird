using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wait : MonoBehaviour
{
    public GameObject WaitUI;
    public Text countDown;
    private float timer = 3;

    private void Awake()
    {
        countDown.text = timer.ToString();
    }

    private void Start()
    {
        StartCoroutine(oo());
    }
    void Update()
    {
/*            timer -= Time.unscaledDeltaTime;
        if (timer > 0)
        {
            countDown.text = Mathf.Round(timer).ToString();
        }
        else if (timer <= 0)
        {
            WaitUI.SetActive(false);
        }*/

    }

    IEnumerator oo()
    {
        WaitUI.SetActive(true);
        Time.timeScale = 0.0f;
        yield return new WaitForSecondsRealtime(3f);
        WaitUI.SetActive(false);
        Time.timeScale = 1.0f;
    }


}
