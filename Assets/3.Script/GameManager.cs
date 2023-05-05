using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 나중에 싱글톤 상속받자
public class GameManager : Singleton<GameManager>
{
    private FileManager _file = new FileManager();
    private SoundManager _sound = new SoundManager();
    private SceneManagerEx _scene = new SceneManagerEx();

    public FileManager File => _file;
    public SoundManager Sound => _sound;
    public SceneManagerEx Scene => _scene;


    // 나중에 Init으로 해야함
    private void Awake()
    {
        Debug.Log("불러옵니다.");
        File.LoadGame();

        Scene.Init();
        Sound.Init();

        //RabbitController.Instance.onDie += GameOver;
    }

    private void GameOver()
    {
        GameObject gameOverCanvas = GameObject.Find("GameOverCanvas");
        gameOverCanvas.transform.GetChild(0).gameObject.SetActive(true);
    }

    private void OnApplicationQuit()
    {
        Debug.Log("저장합니다.");
        File.SaveGame();
    }
}
