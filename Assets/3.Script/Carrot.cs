using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : Item, IItem
{
    private RabbitController rabbit;


    private void Awake()
    {
        rabbit = GetComponent<RabbitController>();
    }

    public void Use()
    {
        rabbit.UseItem(item);
        //Ä¿Áö±â
    }

}
