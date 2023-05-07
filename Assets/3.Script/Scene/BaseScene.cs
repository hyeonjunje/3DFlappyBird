using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScene : MonoBehaviour
{
    private void Awake()
    {
        Init();
        Debug.Log(gameObject.name);
    }

    protected virtual void Init()
    {
        GameManager.Instance.Init();
    }

    public void ShowUI(BaseUI ui)
    {
        ui.Show();
        // GameManager.Instance.UI.ShowUI(ui);
    }

    public void PopUI()
    {
        GameManager.Instance.UI.ExitUI();
    }

    public void ExitUI(BaseUI ui)
    {
        ui.Exit();
    }
}
