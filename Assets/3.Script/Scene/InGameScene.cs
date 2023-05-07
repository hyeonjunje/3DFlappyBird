using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameScene : BaseScene
{
    [SerializeField]
    private RabbitSpawner rabbitSpawner;
    [SerializeField]
    private BaseUI waitingUI;
    [SerializeField]
    private BaseUI gameOverUI;
    [SerializeField]
    private BaseUI inGameUI;

    private RabbitController rabbit;


    public void ReStart()
    {
        GameManager.Instance.Scene.LoadScene(EScene.Lobby);
    }

    protected override void Init()
    {
        base.Init();


        // 플레이어 생성
        rabbit = rabbitSpawner.RespawnRabbit();

        // 플레이어 죽을 때 gameOverUI 활성화 해주기
        // rabbit.onDie += (() => GameManager.Instance.UI.ShowUI(gameOverUI));
        rabbit.onDie += (() => inGameUI.Exit());
        rabbit.onDie += (() => gameOverUI.Show());
        /*// 카운트다운 UI Show
        GameManager.Instance.UI.ShowUI(waitingUI);*/

        waitingUI.Show();
    }
}
