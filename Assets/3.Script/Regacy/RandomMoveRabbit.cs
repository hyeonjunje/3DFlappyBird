using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMoveRabbit : MonoBehaviour
{
    Animator ani;
    int num = 0;

    private void Awake()
    {
        ani = GetComponent<Animator>();
        Invoke("Think", 5);
    }

    void Think()
    {
        if (num.Equals(0))
        {
            ani.SetTrigger("IdleC");
            num = 1;
        }
        else
        { ani.SetTrigger("IdleB");  num = 0; }

        Invoke("Think", 5);
    }



}
