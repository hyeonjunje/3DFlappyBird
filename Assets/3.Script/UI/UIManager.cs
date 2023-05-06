using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    private Stack<BaseUI> ui = new Stack<BaseUI>();

    public void Init()
    {
        ui = new Stack<BaseUI>();

        // 씬 이동 시 모든 UI 닫음
        GameManager.Instance.Scene.onChangeScene += ClearUI;
    }

    // 모든 UI를 닫습니다.
    public void ClearUI()
    {
        while(ui.Count > 0)
        {
            ExitUI();
        }
    }

    // 전 UI를 숨기고 해당 UI를 보여줍니다.
    public void ShowUI(BaseUI newUI)
    {
        if(ui.Count != 0)
        {
            BaseUI prevUI = ui.Peek();
            prevUI.Exit();
        }
        ui.Push(newUI);
        newUI.Show();
    }

    // 가장 위에 있는 UI를 지워줍니다.
    public void ExitUI()
    {
        // ui가 있으면 실행
        if(ui.Count != 0)
        {
            ui.Peek().Exit();
            ui.Pop();

            // ui를 pop해도 아직 남아있으며 그 ui보여줌
            if(ui.Count != 0)
            {
                ui.Peek().Show();
            }
        }
        else
        {
            Debug.Log("UI가 없습니다.");
        }
    }
}
