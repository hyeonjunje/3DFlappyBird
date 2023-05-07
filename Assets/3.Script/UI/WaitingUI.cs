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
        // ī��Ʈ �ٿ� ���� ��
        Time.timeScale = 0.0f;
        for (int i = 3; i > 0; i--)
        {
            countDown.text = i.ToString();
            yield return new WaitForSecondsRealtime(1f);
        }
        Time.timeScale = 1.0f;

        // ī��Ʈ �ٿ� ������ inGameUI show���ֱ�

        Exit();
        inGameUI.Show();

        // GameManager.Instance.UI.ShowUI(inGameUI);
    }
}
