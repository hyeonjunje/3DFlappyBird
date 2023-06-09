using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : BaseUI
{
    [SerializeField] private Text scorePointText;
    [SerializeField] private Text bestScorePointText;

    [SerializeField] private RankingUI rankingUI;

    private bool isFirst = true;

    public override void Exit()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 게임 오버시 GameOverUI 활성화
    /// 활성화하면 이름과 점수를 가져와서 저장 후 UI 갱신
    /// </summary>
    public override void Show()
    {
        gameObject.SetActive(true);

        if(isFirst)
        {
            isFirst = false;

            // 데이터 가져오기
            string nickName = SelectRabbit.Instance.nickName;
            int score = GameManager.Instance.Score;
            ScoreData scoreData = new ScoreData(nickName, score);

            // score 기록
            GameManager.Instance.File.RecordData(scoreData);
            rankingUI.InitData(scoreData);

            // UI 갱신
            scorePointText.text = score.ToString();

            // 신기록 갱신
            if (GameManager.Instance.File.GameData.maxScore < score)
            {
                GameManager.Instance.File.GameData.maxScore = score;
            }
            bestScorePointText.text = GameManager.Instance.File.GameData.maxScore.ToString();
        }

        GameManager.Instance.File.SaveGame();
    }
}
