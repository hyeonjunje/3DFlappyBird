using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 나중에 싱글톤 상속받자
public class GameManager : Singleton<GameManager>
{
    private FileManager _file = new FileManager();
    private SoundManager _sound = new SoundManager();

    public FileManager File => _file;
    public SoundManager Sound => _sound;

    private void Awake()
    {
        Debug.Log("불러옵니다.");
        File.LoadGame();
    }

    private void OnApplicationQuit()
    {
        Debug.Log("저장합니다.");
        File.SaveGame();
    }
}
