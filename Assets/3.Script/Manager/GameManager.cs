using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 나중에 싱글톤 상속받자
public class GameManager : MonoBehaviour
{
    private FileManager _file = new FileManager();

    public FileManager File => _file;

    private void Awake()
    {
        Debug.Log("불러옵니다.");
        File.LoadGame();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            File.saveData.scoreData.Add(new ScoreData("제현준", 30));
            Debug.Log(File.saveData.scoreData.Count + " 저장됨 !!");
        }
    }

    private void OnApplicationQuit()
    {
        Debug.Log("저장합니다.");
        File.SaveGame();
    }
}
