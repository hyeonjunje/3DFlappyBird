using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RabbitController : Singleton<RabbitController>
{
    [SerializeField] float jumpForce = 200f;
    Rigidbody rigid;
    Animator ani;
    public SkinnedMeshRenderer rend;
    public Material[] mat;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        rend = GetComponentInChildren<SkinnedMeshRenderer>();
        ani = GetComponent<Animator>();
        
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                rigid.AddForce(0, jumpForce, 0);
                ani.SetTrigger("Jump");
            }
        }
        
    }
}
