using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ILemon : MonoBehaviour
{
    public enum ItemType { Lemon, DragonFruit}
    public ItemType type;

    SphereCollider sphere;

    public bool isRoot = false;

    private void OnEnable()
    {
        isRoot = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pipe") && type.Equals(ItemType.Lemon) && isRoot)
        {
            ObjectChange box = other.GetComponent<ObjectChange>();
            box.isChange = true;
            box.ChangeObj();
            //gameObject.SetActive(false);
        }

        //용과로 접촉 시
        if (other.CompareTag("Player") && type.Equals(ItemType.DragonFruit))
        {
            gameObject.SetActive(false);
        }
    }
}
