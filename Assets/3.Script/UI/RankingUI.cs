using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingUI : BaseUI
{
    [SerializeField] private Transform scoreUnitParent;
    [SerializeField]private ScoreUnit scoreUnitPrefab;
    [SerializeField] private ScoreUnit myScoreUnit;

    private ScoreData currentScoreData;

    private bool isFirst = true;

    /// <summary>
    /// RankingUI 활성화 시 
    /// 랭킹 보여주기 (1등부터 10등까지)
    /// 그리고 내 점수 보여주기
    /// </summary>
    public override void Show()
    {
        gameObject.SetActive(true);

        if (isFirst)
        {
            isFirst = false;

            ShowRanking();
            ShowMyRanking();
        }
    }

    public override void Exit()
    {
        gameObject.SetActive(false);
    }

    public void InitData(ScoreData scoreData)
    {
        currentScoreData = scoreData;
    }

    /// <summary>
    /// 1등부터 10등까지 보여주기
    /// </summary>
    private void ShowRanking()
    {
        List<ScoreData> scoreData = GameManager.Instance.File.GameData.scoreData;
        scoreData.Sort();

        int count = scoreData.Count < 10 ? scoreData.Count : 10;
        for(int i = 0; i < count; i++)
        {
            ScoreUnit scoreUnit = Instantiate(scoreUnitPrefab, scoreUnitParent);
            scoreUnit.InitData((i + 1).ToString(), scoreData[i].playerName, scoreData[i].playerScore);
        }
    }

    /// <summary>
    /// 내 점수 보여주기
    /// </summary>
    private void ShowMyRanking()
    {
        myScoreUnit.InitData("나", currentScoreData.playerName, currentScoreData.playerScore);
    }
}
