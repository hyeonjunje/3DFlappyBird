using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 objectVectorEnd;

    private Object_Scrplling scrolling;

    private void Awake()
    {
        scrolling = GetComponentInParent<Object_Scrplling>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x <= objectVectorEnd.x)
        {
            scrolling.ResetBoxFilePositon(gameObject);
        }
    }
}