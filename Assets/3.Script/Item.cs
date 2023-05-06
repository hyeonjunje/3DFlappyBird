using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EItem { Carrot, Lemon };
public class Item : MonoBehaviour
{
    [SerializeField] protected EItem item;

    private void Update()
    {
       // transform.Translate(Vector3.left * 1 * Time.deltaTime);
        transform.Rotate(new Vector3(1, 1, 1) * 180 * Time.deltaTime);
        
    }
}
