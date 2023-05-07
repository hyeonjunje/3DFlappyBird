using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitingUI : BaseUI
{
    [SerializeField] private Text countDown;
    [SerializeField] private BaseUI inGameUI;

    private Coroutine countDownCo;

    private void Awake()
    {
        Show();
    }

    public override void Exit()
    {
        gameObject.SetActive(false);

        if(countDown != null)
            StopCoroutine(countDownCo);
    }

    public override void Show()
    {
        gameObject.SetActive(true);

        if (countDownCo != null)
            StopCoroutine(countDownCo);
        countDownCo = StartCoroutine(CountdownCo());
    }

    private IEnumerator CountdownCo()
    {
        // 카운트 다운 시작 시
        Time.timeScale = 0.0f;
        for (int i = 3; i > 0; i--)
        {
            countDown.text = i.ToString();
            yield return new WaitForSecondsRealtime(1f);
        }
        Time.timeScale = 1.0f;

        // 카운트 다운 끝나면 inGameUI show해주기

        Exit();
        inGameUI.Show();

        // GameManager.Instance.UI.ShowUI(inGameUI);
    }
}
