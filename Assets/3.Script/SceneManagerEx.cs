using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum EScene
{
    Lobby = 0,
    InGame
}

public class SceneManagerEx
{
    public EScene currentScene = EScene.Lobby;


    public delegate void OnChangeScene();
    public event OnChangeScene onChangeScene;

    public void Init()
    {
        currentScene = EScene.Lobby;
    }

    public void LoadScene(EScene scene)
    {
        SceneManager.LoadScene((int)scene);
        currentScene = scene;

        onChangeScene?.Invoke();
    }
}