using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameScene : MonoBehaviour
{
    [SerializeField]
    private Text gameScoreText;

    private void Awake()
    {
        // 캐릭터 트랜스폼 조정
        //RabbitController.Instance.transform.rotation = Quaternion.identity;

        // 3초 세는거

        // 제현준이; 만든 프리팹도 여기서 생성
        // Instantiate(gameOverCanvas);
        // ()

        GameManager.Instance.OnChangeScore = null;
        GameManager.Instance.OnChangeScore += (() => gameScoreText.text = GameManager.Instance.Score.ToString());
    }



    public void ReStart()
    {
        GameManager.Instance.Scene.LoadScene(EScene.Lobby);
    }
}
