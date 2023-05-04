using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RabbitController : Singleton<RabbitController>
{
    [SerializeField] float jumpForce;
    Rigidbody rigid;
    Animator ani;
    Vector3 defaultScale;
    public SkinnedMeshRenderer rend;
    public Material[] mat;
    bool isDead;
    bool isBig;

    private void Awake()
    {
        defaultScale = gameObject.transform.localScale;
        rend = GetComponentInChildren<SkinnedMeshRenderer>();
        TryGetComponent(out rigid);
        TryGetComponent(out ani);
        
    }

    private void FixedUpdate()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }

        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Jump();
            }
        }

    }

    void Jump()
    {
        if (!EventSystem.current.IsPointerOverGameObject()&&!isDead)
        {
            rigid.velocity = Vector3.zero;
            rigid.AddForce(Vector3.up*jumpForce);
            ani.SetTrigger("Jump");
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Pipe")&&!isDead&&!isBig)
        {
            //죽고 점프 못뛰고 화면 멈추고 게임오버 나오고 점수 나오고,,,,,,,,,,,,,,,
            isDead = true;
            ani.SetTrigger("Die");
        }

        if (collision.transform.CompareTag("Pipe") && isBig)
        {
            //아이템 먹으면 파이프 뿌시기
            Destroy(collision.collider.gameObject);

        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Item")&&!isDead)
        {
            isBig = true;
            Destroy(other.gameObject);
            StartCoroutine(sizeUpItemCo());
        }
    }

    IEnumerator sizeUpItemCo()
    {
        //커지고 파이프 뿌시고 일정시간 이후에 돌아오기
        int count = 0;
        while (count < 3)
        {
            transform.localScale *= 1.3f;
            yield return new WaitForSeconds(0.065f);
            count++;
        }
        ani.SetBool("Dance", true);
        yield return new WaitForSeconds(5f);

        while(transform.localScale.x>=defaultScale.x)
        {
            transform.localScale -= Vector3.one* 0.2f;
            yield return new WaitForSeconds(0.065f);
        }
        transform.localScale = defaultScale;
        ani.SetBool("Dance", false);
        isBig = false;
    }



}
