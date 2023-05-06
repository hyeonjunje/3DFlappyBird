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
        //ÇÑ±Û¿µ¾î¸¸ °¡´É??
        return Regex.IsMatch(inputField.text, "^[a-zA-Z°¡-ÆR]*$");
    }

    public void SelectRabbitInfo()
    {
        if (CheckNickName() == false)
        {
            warningUI.SetActive(true);
            Debug.Log("´Ù½ÃÁö¾î");
            return;
        }
        warningUI.SetActive(false);
        SelectRabbit.Instance.nickName = inputField.text;
        Debug.Log(SelectRabbit.Instance.nickName);
        //¾À³Ñ±â±â
        GameManager.Instance.Scene.LoadScene(EScene.InGame);
    }
}
