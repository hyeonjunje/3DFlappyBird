using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public int index = 0;
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

}
