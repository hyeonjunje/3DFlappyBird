using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitSpawner : MonoBehaviour
{
    private RabbitController player;

    [SerializeField]
    private RabbitController rabbitPrefab;


    public RabbitController RespawnRabbit()
    {
        // 토끼 생성
        player = Instantiate(rabbitPrefab, new Vector3(0, 0, 0), Quaternion.Euler(0, 90, 0));

        // 토끼 색 입히기
        player.GetComponentInChildren<SkinnedMeshRenderer>().material =
            SelectRabbit.Instance.mat[SelectRabbit.Instance.rabbitColor];

        // 토끼 반환
        return player;
    }
}
