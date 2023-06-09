using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class RabbitSelectUI : BaseUI
{
    public GameObject rabbit;
    public GameObject nickNameUI;
    public Text warningText;
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
        inputField.characterLimit = 10;
    }

    public override void Exit()
    {
        gameObject.SetActive(false);
    }

    public override void Show()
    {
        gameObject.SetActive(true);

        warningText.gameObject.SetActive(false);
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
        //한글영어만 가능??
        return Regex.IsMatch(inputField.text, "^[a-zA-Z가-힣]*$");
    }

    public void SelectRabbitInfo()
    {
        if (CheckNickName() == false)
        {
            warningText.gameObject.SetActive(true);
            StartCoroutine(ShakeCo());
            warningText.text = "잘못된 닉네임 입니다.";
            return;
        }

        if(inputField.text.Length<2)
        {
            warningText.gameObject.SetActive(true);
            StartCoroutine(ShakeCo());
            warningText.text = "최소 두 글자의 닉네임을 입력해주세요.";
            return;
        }
        warningText.gameObject.SetActive(false);
        SelectRabbit.Instance.nickName = inputField.text;
        Debug.Log(SelectRabbit.Instance.nickName);
        //씬넘기기
        GameManager.Instance.Scene.LoadScene(EScene.InGame);
    }

    private IEnumerator ShakeCo()
    {
        Vector3 origin = warningText.transform.position;

        for (int i = 0; i < 5; i++)
        {
            warningText.transform.position += new Vector3(0, Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * 30f;
            yield return new WaitForSeconds(0.02f);
            warningText.transform.position = origin;
        }
    }
}
