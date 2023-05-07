using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RabbitController : MonoBehaviour
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
        //ȭ�� ������ ������ ����?
        if(view.y>1||view.y<0&&!isBig && GameManager.Instance.Scene.currentScene == EScene.InGame)
        {
            Die();
        }

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
#endif

#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Jump();
            }
        }
#endif

    }

    private void Jump()
    {
        if (!EventSystem.current.IsPointerOverGameObject()&&!isDead && GameManager.Instance.Scene.currentScene == EScene.InGame)
        {
            rigid.velocity = Vector3.zero;
            rigid.AddForce(Vector3.up*jumpForce);
            ani.SetTrigger("Jump");

            GameManager.Instance.Sound.PlaySE(ESE.jump);
        }

    }

    private void Die()
    {
        if (isDead)
            return;

        isDead = true;
        ani.SetTrigger("Die");
        Debug.Log("����");

        // �״� �̺�Ʈ ����
        onDie?.Invoke();
        GameManager.Instance.Sound.PlaySE(ESE.failed);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Floor") || collision.transform.CompareTag("Pipe"))
        {
            if (!isBig)
            {
                //�װ� ���� ���ٰ� ȭ�� ���߰� ���ӿ��� ������ ���� ������,,,,,,,,,,,,,,,
                Die();
            }
        }

        if (collision.transform.CompareTag("Pipe"))
        {
            if (isBig)
            {
                //������ ������ ������ �ѽñ�
                collision.collider.gameObject.SetActive(false);

                // ������ �Ѽ��� ���� ����!!
                GameManager.Instance.AddScore(1);
            }
       
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // ���ھ� layer�� �����ǰ� ���� ���� ������ ��
        if(other.gameObject.layer.Equals(LayerMask.NameToLayer("Score")) && !isDead)
        {
            // ���� �ö�!!
            GameManager.Instance.AddScore(1);
            
            // ���� �ö󰡴� �Ҹ� => ���߿� �Ҹ� �ٲ�
            GameManager.Instance.Sound.PlaySE(ESE.item);
        }

        if (other.CompareTag("Item") && !isDead)
        {
             this.item = other.GetComponent<Item>();
             IItem item = other.GetComponent<IItem>();

            if (this.item == null)
            {
                lemonItemScript = other.GetComponent<ILemon>();
                lemonItemScript.StartCoroutine(lemonItemScript.changeItemCo());
            }
            if (item != null && !isBig )
            {
                item.Use();

                if(this.item != null)
                {
                    other.gameObject.SetActive(false);
                }
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
        }
    }

    public IEnumerator sizeUpItemCo()
    {
        //Ŀ���� ������ �ѽð� �����ð� ���Ŀ� ���ƿ���
        isBig = true;
        int count = 0;
        while (count < 7)
        {
            transform.localScale *= 1.3f;
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
