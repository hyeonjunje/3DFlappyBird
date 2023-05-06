using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ILemon : MonoBehaviour, IItem
{
    public EItem item;
    public enum ItemType { Lemon, DragonFruit }
    public ItemType type;
    public SphereCollider sphere;

    public bool isRoot;

    private RabbitController rabbit;
    private void Awake()
    {
        isRoot = false;
        sphere.enabled = false;
        TryGetComponent(out sphere);
    }
    private void OnEnable()
    {
        if(type == ItemType.Lemon)
        {
            sphere.enabled = false;
        }

        if (type == ItemType.DragonFruit)
        {
            sphere.enabled = true;
        }
    }
    private void Update()
    {
    }
    public void Use()
    {
        sphere.enabled = true;
        rabbit = GameObject.FindGameObjectWithTag("Player").GetComponent<RabbitController>();
        rabbit.UseItem(item);
    }
    public IEnumerator changeItemCo()
    {
        isRoot = true;
        sphere.enabled = true;
        yield return new WaitForSeconds(0.1f);
        sphere.enabled = false;
        gameObject.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Pipe") && type.Equals(ItemType.Lemon))
        {
            ObjectChange box = other.GetComponent<ObjectChange>();

            if (box != null)
            {
                box.isChange = true;
                box.ChangeObj();
            }
        }

        //용과로 접촉 시
        if (other.CompareTag("Player") && type.Equals(ItemType.DragonFruit))
        {
            GameManager.Instance.AddScore(10);
            gameObject.SetActive(false);
        }
    }
}
