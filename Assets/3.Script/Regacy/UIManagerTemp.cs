using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManagerTemp : MonoBehaviour
{
    public GameObject rabbit;
    public GameObject nickNameUI;
    public GameObject warningUI;
    public InputField inputField;

    public int index = 0;

    private void Awake()
    {
        warningUI.SetActive(false);
        nickNameUI.SetActive(false);
    }

    public void RightBtn()
    {
        if (index >= SelectRabbit.Instance.mat.Length-1)
        {
            index = 0;
        }
        else index++;
        rabbit.GetComponent<RabbitColor>().rend.material = SelectRabbit.Instance.mat[index];
    }

    public void LeftBtn()
    {
        if(index<=0)
        {
            index = SelectRabbit.Instance.mat.Length-1;
        }
        else index--;
        rabbit.GetComponent<RabbitColor>().rend.material = SelectRabbit.Instance.mat[index];
    }

    public void MiddleBtn()
    {
        SelectRabbit.Instance.rabbitColor = index;
        nickNameUI.SetActive(true);
    }

    bool CheckNickName()
    {
        //한글영어만 가능??
        return Regex.IsMatch(inputField.text, "^[a-zA-Z가-힣]*$");
    }


    public void Save()
    {
        if(CheckNickName()==false)
        {
            warningUI.SetActive(true);
            Debug.Log("다시지어");
            return;
        }
        warningUI.SetActive(false);
        SelectRabbit.Instance.nickName = inputField.text;
        Debug.Log(SelectRabbit.Instance.nickName);
        //씬넘기기
        GameManager.Instance.Scene.LoadScene(EScene.InGame);
    }




}
