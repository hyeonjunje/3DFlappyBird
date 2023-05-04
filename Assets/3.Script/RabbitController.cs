using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RabbitController : Singleton<RabbitController>
{
    [SerializeField] float jumpForce;
    Rigidbody rigid;

    public Animator ani;
    public Vector3 defaultScale;
    Vector3 view;
    public SkinnedMeshRenderer rend;
    public Material[] mat;

    public bool isDead;
    public bool isBig;


    private void Awake()
    {
        isDead = false;
        isBig = false;
        defaultScale = gameObject.transform.localScale;
        rend = GetComponentInChildren<SkinnedMeshRenderer>();
        TryGetComponent(out rigid);
        TryGetComponent(out ani);
        
        
    }


    private void Update()
    {
      
        view = Camera.main.WorldToViewportPoint(transform.position);
        //화면 밖으로 나가면 죽음?
        if(view.y>1||view.y<0&&!isBig)
        {
            Die();
        }

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

    void Die()
    {
        isDead = true;
        ani.SetTrigger("Die");
        Debug.Log("죽음");
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Pipe")&&!isDead&&!isBig)
        {
            //죽고 점프 못뛰고 화면 멈추고 게임오버 나오고 점수 나오고,,,,,,,,,,,,,,,
            Die();
        }

        if (collision.transform.CompareTag("Pipe") && isBig)
        {
            //아이템 먹으면 파이프 뿌시기
            collision.collider.gameObject.SetActive(false);

        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item")&&!isDead)
        {
            IItem item = other.GetComponent<IItem>();
            if (item != null)
            {
                item.Use();
                Destroy(other.gameObject);
            }
        }
    }

    public void Carrot()
    {
        StartCoroutine(sizeUpItemCo());
    }

    public IEnumerator sizeUpItemCo()
    {
        //커지고 파이프 뿌시고 일정시간 이후에 돌아오기
        isBig = true;
        int count = 0;
        while (count < 7)
        {
            RabbitController.Instance.transform.localScale *= 1.3f;
            yield return new WaitForSeconds(0.065f);
            count++;
        }
        ani.SetBool("Dance", true);
        yield return new WaitForSeconds(5f);

        while (transform.localScale.x >= defaultScale.x)
        {
            transform.localScale -= Vector3.one * 0.3f;
            yield return new WaitForSeconds(0.065f);
        }
        transform.localScale = defaultScale;
        ani.SetBool("Dance", false);
        isBig = false;
    }




}
