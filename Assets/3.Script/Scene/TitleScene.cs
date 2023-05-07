using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : BaseScene
{
    [SerializeField]
    private BaseUI titleUI;

    protected override void Init()
    {
        base.Init();

        // BGM ���
        GameManager.Instance.Sound.PlayBgm(EBGM.Background);

        // UI �����ֱ�
        GameManager.Instance.UI.ShowUI(titleUI);
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.Instance.Scene.LoadScene(EScene.Lobby);
        }
#endif

#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                GameManager.Instance.Scene.LoadScene(EScene.Lobby);
            }
        }
    }
#endif
}

