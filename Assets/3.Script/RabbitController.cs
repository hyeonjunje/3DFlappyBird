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
            Jump();
        }

        if(Input.touchCount>0)
        {
            if(Input.GetTouch(0).phase==TouchPhase.Began)
            {
                Jump();
            }
        }
        
    }

    void Jump()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            rigid.AddForce(0, jumpForce, 0);
            ani.SetTrigger("Jump");
        }

    }
}
