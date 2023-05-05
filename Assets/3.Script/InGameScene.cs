using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameScene : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverCanvas;

    private void Awake()
    {
        // 캐릭터 트랜스폼 조정
        //RabbitController.Instance.transform.rotation = Quaternion.identity;

        // 3초 세는거

        // 제현준이; 만든 프리팹도 여기서 생성
        // Instantiate(gameOverCanvas);
        // 
    }


    public void ReStart()
    {
        GameManager.Instance.Scene.LoadScene(EScene.Lobby);
    }
}
