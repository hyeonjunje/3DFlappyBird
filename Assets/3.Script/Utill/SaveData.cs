using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class ScoreData : IComparable
{
    public string playerName;
    public int playerScore;

    public ScoreData(string playerName, int playerScore)
    {
        this.playerName = playerName;
        this.playerScore = playerScore;
    }

    public int CompareTo(object obj)
    {
        return ((ScoreData)obj).playerScore.CompareTo(playerScore);
    }

    public static bool operator >(ScoreData op1, ScoreData op2)
    {
        return (op1.playerScore > op2.playerScore);
    }

    public static bool operator <(ScoreData op1, ScoreData op2)
    {
        return !(op1 > op2);
    }
}


[System.Serializable]
public class GameData
{
    public int maxScore = 0;
    public List<ScoreData> scoreData = new List<ScoreData>();

    public GameData() 
    {
        scoreData = new List<ScoreData>();
    }


    /// <summary>
    /// add할 때 크기 순으로 순서를 정해준다.
    /// </summary>
    /// <param name="scoreData">list에 더할 scoreData</param>
    public void AddScoreData(ScoreData scoreData)
    {
        int index = 0;

        for(int i = 0; i < this.scoreData.Count; i++)
        {
            // 새로운 값이 더 클 경우 그 자리를 대체한다.
            if(this.scoreData[i] < scoreData)
            {
                index = i;
                break;
            }
        }

        this.scoreData.Insert(index, scoreData);
    }
}
