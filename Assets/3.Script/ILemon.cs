using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ILemon : MonoBehaviour
{
    public enum ItemType { Lemon,DragonFruit}
    public ItemType type;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pipe") && type.Equals(ItemType.Lemon))
        {
            ObjectChange box = other.GetComponent<ObjectChange>();
        }

        if (other.CompareTag("Player") && type.Equals(ItemType.DragonFruit))
        {

            
            gameObject.SetActive(false);
        }
    }
}
