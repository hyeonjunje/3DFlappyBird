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
        //ÇÑ±Û¿µ¾î¸¸ °¡´É??
        return Regex.IsMatch(inputField.text, "^[a-zA-Z°¡-ÆR]*$");
    }


    public void Save()
    {
        if(CheckNickName()==false)
        {
            warningUI.SetActive(true);
            Debug.Log("´Ù½ÃÁö¾î");
            return;
        }
        warningUI.SetActive(false);
        nickName = inputField.text;
        Debug.Log(nickName);
        //¾À³Ñ±â±â
    }




}
