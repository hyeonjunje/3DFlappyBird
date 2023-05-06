using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitColor : MonoBehaviour
{
    public SkinnedMeshRenderer rend;

    private void Awake()
    {
        GameManager.Instance.Sound.PlayBgm(EBGM.Background);

        rend = GetComponentInChildren<SkinnedMeshRenderer>();
    }

}
