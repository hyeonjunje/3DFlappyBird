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
    /// ���� ������ GameOverUI Ȱ��ȭ
    /// Ȱ��ȭ�ϸ� �̸��� ������ �����ͼ� ���� �� UI ����
    /// </summary>
    public override void Show()
    {
        gameObject.SetActive(true);

        if(isFirst)
        {
            isFirst = false;

            // ������ ��������
            string nickName = SelectRabbit.Instance.nickName;
            int score = GameManager.Instance.Score;
            ScoreData scoreData = new ScoreData(nickName, score);

            // score ���
            GameManager.Instance.File.RecordData(scoreData);
            rankingUI.InitData(scoreData);

            // UI ����
            scorePointText.text = score.ToString();

            // �ű�� ����
            if (GameManager.Instance.File.GameData.maxScore < score)
            {
                GameManager.Instance.File.GameData.maxScore = score;
            }
            bestScorePointText.text = GameManager.Instance.File.GameData.maxScore.ToString();
        }

        GameManager.Instance.File.SaveGame();
    }
}
