using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class ScoreData
{
    public string playerName;
    public int playerScore;

    public ScoreData(string playerName, int playerScore)
    {
        this.playerName = playerName;
        this.playerScore = playerScore;
    }
}

[System.Serializable]
public class Data
{
    public List<ScoreData> scoreData = new List<ScoreData>();

    public Data()
    {
        scoreData = new List<ScoreData>();
    }
}

public class FileManager
{
    public Data saveData = new Data();


    public void SaveGame()
    {
        string filePath = Application.persistentDataPath + "/save.json";
        StreamWriter saveFile = new StreamWriter(filePath);
        saveFile.Write(JsonUtility.ToJson(saveData, true));

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

        JsonUtility.FromJsonOverwrite(saveFile.ReadToEnd(), saveData);

        saveFile.Close();
    }
}
