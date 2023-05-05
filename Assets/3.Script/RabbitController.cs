using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RabbitController : Singleton<RabbitController>
{
    [SerializeField] private float jumpForce;
    private Rigidbody rigid;

    public Animator ani;
    public Vector3 defaultScale;
    private Vector3 view;
    public SkinnedMeshRenderer rend;
    public Material[] mat;

    public bool isDead;
    public bool isBig;
    public Item item;

    public delegate void OnDie();
    public event OnDie onDie;

    public string nickName;

    public ILemon lemonItemScript;
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
        if(view.y>1||view.y<0&&!isBig && GameManager.Instance.Scene.currentScene == EScene.InGame)
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

    private void Jump()
    {
        if (!EventSystem.current.IsPointerOverGameObject()&&!isDead && GameManager.Instance.Scene.currentScene == EScene.InGame)
        {
            rigid.velocity = Vector3.zero;
            rigid.AddForce(Vector3.up*jumpForce);
            ani.SetTrigger("Jump");
        }

    }

    private void Die()
    {
        if (isDead)
            return;

        isDead = true;
        ani.SetTrigger("Die");
        Debug.Log("죽음");

        // 죽는 이벤트 실행
        onDie?.Invoke();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Pipe"))
        {
            if (isBig)
            {
                //아이템 먹으면 파이프 뿌시기
                collision.collider.gameObject.SetActive(false);
            }
            else
            {
                //죽고 점프 못뛰고 화면 멈추고 게임오버 나오고 점수 나오고,,,,,,,,,,,,,,,
                Die();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item") && !isDead)
        {
            IItem item = other.GetComponent<IItem>();
            EItem eItem = other.GetComponent<EItem>();
            if (item != null)
            {
                item.Use();
                Destroy(other.gameObject);
            }
            if(item != null && eItem == EItem.Lemon)
            {
                lemonItemScript = other.GetComponent<ILemon>();
            }
            
            
        }
    }

    public void UseItem(EItem item)
    {
        switch(item)
        {
            case EItem.Carrot:
                StartCoroutine(sizeUpItemCo());
                break;
            case EItem.Lemon:
                StartCoroutine(changeItemCo());
                break;

        }

    }
    public IEnumerator changeItemCo()
    {
        if(lemonItemScript != null)
        {
            lemonItemScript.isRoot = true;
            yield return new WaitForSeconds(0.1f);
            lemonItemScript.isRoot = false;
            lemonItemScript.gameObject.SetActive(false);
        }
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
