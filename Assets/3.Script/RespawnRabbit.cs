using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnRabbit : MonoBehaviour
{
    GameObject player;
    public GameObject rabbit;
    // Start is called before the first frame update

    private void Awake()
    {
        player = Instantiate(rabbit, new Vector3(0,0,0), Quaternion.Euler(0,90,0));
        player.GetComponentInChildren<SkinnedMeshRenderer>().material =
            SelectRabbit.Instance.mat[SelectRabbit.Instance.rabbitColor];
    }
}
