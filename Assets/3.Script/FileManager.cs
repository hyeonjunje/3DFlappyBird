using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileManager
{
    private GameData gameData = new GameData();
    public GameData GameData => gameData;


    /// <summary>
    /// 데이터 기록
    /// </summary>
    /// <param name="scoreData">기록할 데이터</param>
    public void RecordData(ScoreData scoreData)
    {
        gameData.AddScoreData(scoreData);
        if(gameData.maxScore < scoreData.playerScore)
        {
            gameData.maxScore = scoreData.playerScore;
        }
    }

    public void SaveGame()
    {
        string filePath = Application.persistentDataPath + "/save.json";
        StreamWriter saveFile = new StreamWriter(filePath);
        saveFile.Write(JsonUtility.ToJson(gameData, true));

        saveFile.Close();
    }

    public void LoadGame()
    {
        string filePath = Application.persistentDataPath + "/save.json";
        Debug.Log(filePath);

        if(!File.Exists(filePath))
        {
            Debug.Log("No file!");
            return;
        }

        StreamReader saveFile = new StreamReader(filePath);

        JsonUtility.FromJsonOverwrite(saveFile.ReadToEnd(), gameData);

        saveFile.Close();
    }
}
