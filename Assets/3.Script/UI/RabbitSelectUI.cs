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
        //ÇÑ±Û¿µ¾î¸¸ °¡´É??
        return Regex.IsMatch(inputField.text, "^[a-zA-Z°¡-ÆR]*$");
    }

    public void SelectRabbitInfo()
    {
        if (CheckNickName() == false)
        {
            warningText.gameObject.SetActive(true);
            StartCoroutine(ShakeCo());
            warningText.text = "Àß¸øµÈ ´Ð³×ÀÓ ÀÔ´Ï´Ù.";
            return;
        }

        if(inputField.text.Length<2)
        {
            warningText.gameObject.SetActive(true);
            StartCoroutine(ShakeCo());
            warningText.text = "ÃÖ¼Ò µÎ ±ÛÀÚÀÇ ´Ð³×ÀÓÀ» ÀÔ·ÂÇØÁÖ¼¼¿ä.";
            return;
        }
        warningText.gameObject.SetActive(false);
        SelectRabbit.Instance.nickName = inputField.text;
        Debug.Log(SelectRabbit.Instance.nickName);
        //¾À³Ñ±â±â
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
