using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject nickNameUI;
    public GameObject warningUI;
    public InputField inputField;
    string nickName;
    

    public int index = 0;

    private void Awake()
    {
        warningUI.SetActive(false);
        nickNameUI.SetActive(false);
    }

    public void RightBtn()
    {
        if (index >= RabbitController.Instance.mat.Length-1)
        {
            index = 0;
        }
        else index++;
        RabbitController.Instance.rend.material = RabbitController.Instance.mat[index];
    }

    public void LeftBtn()
    {
        if(index<=0)
        {
            index = RabbitController.Instance.mat.Length-1;
        }
        else index--;
        RabbitController.Instance.rend.material = RabbitController.Instance.mat[index];
    }

    public void MiddleBtn()
    {
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
        nickName = inputField.text;
        Debug.Log(nickName);
        //씬넘기기
    }




}
