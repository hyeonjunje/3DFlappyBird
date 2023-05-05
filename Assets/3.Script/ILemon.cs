using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ILemon : MonoBehaviour,IItem
{
    [SerializeField] protected EItem item;
    public enum ItemType { Lemon, DragonFruit}
    public ItemType type;
    SphereCollider sphere;

    public bool isRoot = false;

    private RabbitController rabbit;
    private void Awake()
    {
        rabbit = RabbitController.Instance.GetComponent<RabbitController>();
    }

    public void Use()
    {
        rabbit.UseItem(item);
        //아이템 변환
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Pipe") && type.Equals(ItemType.Lemon) && isRoot)
        {
            ObjectChange box = other.GetComponent<ObjectChange>();

            if(box != null)
            {
                box.isChange = true;
                box.ChangeObj();

            }
        }

        //용과로 접촉 시
        if (other.CompareTag("Player") && type.Equals(ItemType.DragonFruit))
        {
            gameObject.SetActive(false);
        }
    }
}
