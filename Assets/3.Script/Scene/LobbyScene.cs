using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : BaseScene
{
    [SerializeField] private BaseUI SelectRabbitUI;


    // 로비씬 이동 시 할 일
    // 토끼 선택 UI 표시
    // 해당 씬의 브금 온
    protected override void Init()
    {
        base.Init();

        GameManager.Instance.Sound.PlayBgm(EBGM.Background);
        GameManager.Instance.UI.ShowUI(SelectRabbitUI);
    }
}
