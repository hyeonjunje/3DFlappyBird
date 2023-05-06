using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : Item, IItem
{
    private RabbitController rabbit;


    public void Use()
    {
        rabbit = GameObject.FindGameObjectWithTag("Player").GetComponent<RabbitController>();

        if (rabbit != null)
        {
            rabbit.UseItem(item);
        }
        //Ä¿Áö±â
    }

}
