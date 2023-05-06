using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wait : MonoBehaviour
{
    public GameObject WaitUI;
    public Text countDown;


    private void Start()
    {
        StartCoroutine(oo());
    }

    IEnumerator oo()
    {
        WaitUI.SetActive(true);
        Time.timeScale = 0.0f;
        for(int i=3; i>0; i--)
        {
            countDown.text = i.ToString();
            yield return new WaitForSecondsRealtime(1f);
        } 
        Time.timeScale = 1.0f;
        WaitUI.SetActive(false);
    }


}
