using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : BaseUI
{
    [SerializeField]
    private Text scoreText;

    public override void Exit()
    {
        gameObject.SetActive(false);
    }

    public override void Show()
    {
        gameObject.SetActive(true);

        GameManager.Instance.OnChangeScore = null;
        GameManager.Instance.OnChangeScore += (() => scoreText.text = GameManager.Instance.Score.ToString());

        // addScore delegate로 scoreText update해주기
    }
}
