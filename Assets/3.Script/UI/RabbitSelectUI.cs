using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class RabbitSelectUI : BaseUI
{
    public GameObject rabbit;
    public GameObject nickNameUI;
    public GameObject warningUI;
    public InputField inputField;

    private int index = 0;
    public int Index
    {
        get
        {
            return index;
        }
        set
        {
            index = value;

            if (index > SelectRabbit.Instance.mat.Length - 1)
                index = 0;
            if (index < 0)
                index = SelectRabbit.Instance.mat.Length - 1;
        }
    }

    private void Awake()
    {
        Show();
    }

    public override void Exit()
    {
        gameObject.SetActive(false);
    }

    public override void Show()
    {
        gameObject.SetActive(true);

        warningUI.SetActive(false);
        nickNameUI.SetActive(false);
    }

    public void RightBtn()
    {
        Index++;
        rabbit.GetComponent<RabbitColor>().rend.material = SelectRabbit.Instance.mat[Index];
    }

    public void LeftBtn()
    {
        Index--;
        rabbit.GetComponent<RabbitColor>().rend.material = SelectRabbit.Instance.mat[Index];
    }

    public void MiddleBtn()
    {
        SelectRabbit.Instance.rabbitColor = Index;
        nickNameUI.SetActive(true);
    }

    private bool CheckNickName()
    {
        //�ѱۿ�� ����??
        return Regex.IsMatch(inputField.text, "^[a-zA-Z��-�R]*$");
    }

    public void SelectRabbitInfo()
    {
        if (CheckNickName() == false)
        {
            warningUI.SetActive(true);
            Debug.Log("�ٽ�����");
            return;
        }
        warningUI.SetActive(false);
        SelectRabbit.Instance.nickName = inputField.text;
        Debug.Log(SelectRabbit.Instance.nickName);
        //���ѱ��
        GameManager.Instance.Scene.LoadScene(EScene.InGame);
    }
}
