using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EItem { Carrot, Lemon, DragonFruit };
public class Item : MonoBehaviour
{
    public EItem item;

    private void Update()
    {
       // transform.Translate(Vector3.left * 1 * Time.deltaTime);
        transform.Rotate(new Vector3(1, 1, 1) * 180 * Time.deltaTime);
        
    }
}
