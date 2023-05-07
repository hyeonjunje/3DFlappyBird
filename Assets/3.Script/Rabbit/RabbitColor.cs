using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitColor : MonoBehaviour
{
    public SkinnedMeshRenderer rend;
    Animator ani;

    private void Awake()
    {
        rend = GetComponentInChildren<SkinnedMeshRenderer>();
        ani = GetComponent<Animator>();
    }

    private void Start()
    {
        Time.timeScale = 1;
        ani.SetTrigger("IdleC");
    }

}
