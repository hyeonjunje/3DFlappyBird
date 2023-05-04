using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : Item, IItem
{
    RabbitController rabbit;

    private void Awake()
    {
        rabbit = RabbitController.Instance.GetComponent<RabbitController>();
    }

    public void Use()
    {
        rabbit.Carrot();
        //Ä¿Áö±â
    }

}
