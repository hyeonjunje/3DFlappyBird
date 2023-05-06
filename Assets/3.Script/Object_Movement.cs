using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Movement : MonoBehaviour
{
    [SerializeField] private float objectMoveSpeed;

    [Header("Instance Value")]

    [SerializeField] private int valueBoxCount;

    [Header("Vector Info")]

    [SerializeField] private Vector3 objectVectorEnd;
    [SerializeField] private Transform objectPoolVector;

    [Header("Instance Info")]

    [SerializeField] private GameObject[] objectUpBoxArray;
    [SerializeField] private GameObject[] objectUpBoxPrefab;
    [SerializeField] private Transform[] objectUpBoxPosArray;

    [SerializeField] private GameObject[] objectDownBoxArray;
    [SerializeField] private GameObject[] objectDownBoxPrefab;
    [SerializeField] private Transform[] objectDownBoxPosArray;

    private int valueRandNum;
    private int valueBoxPrefab;

    private Object_Scrplling scrolling;

    [SerializeField] private int randSpawnItem; //스폰될 아이템

    [SerializeField] private Transform[] itemRandSpawnPos;
    [SerializeField] private GameObject[] spawnItemPrefabs;

    public int randLevel = 0;
    public float randPosX;

    /*
        1. 각 레벨의 기둥들을 3개씩 Instance한다.
        2. 활성화 될 때마다 기둥들 중 랜덤으로 호출 
        3. 활성화되면 왼쪽으로 이동

        4. 일정 확률로 아이템 생성
        5. 생성되는 아이템은 한개
        6. 5분의 1의 확률로 아이템 배치

      */
    private void Awake()
    {
        scrolling = GetComponentInParent<Object_Scrplling>();
        //Box Array = 레벨 종류 x 종류 당 개수 
        objectUpBoxArray = new GameObject[valueBoxCount];
        objectDownBoxArray = new GameObject[valueBoxCount];

        //프리팹 레벨 종류 만큼 for문으로 소환
        for (int i = 0; i < objectUpBoxArray.Length; i++)
        {
            //Pool Vector에 각 레벨의 아이템들을 Instance
            objectUpBoxArray[i] = Instantiate(objectUpBoxPrefab[valueBoxPrefab], objectPoolVector.position, Quaternion.identity, objectPoolVector);
            objectDownBoxArray[i] = Instantiate(objectDownBoxPrefab[valueBoxPrefab], objectPoolVector.position, Quaternion.identity, objectPoolVector);

            objectUpBoxArray[i].SetActive(false);
            objectDownBoxArray[i].SetActive(false);
            //=====================================================  각 프리팹 종류에 따라 설정된 카운트에 분배하여 개수 소환
            valueBoxPrefab++;

            if (valueBoxPrefab >= objectUpBoxPrefab.Length)
            {
                valueBoxPrefab = 0;
            }
        }
    }
    private void OnEnable()
    {

        for (int i = 0; i < spawnItemPrefabs.Length; i++)
        {
            spawnItemPrefabs[i].transform.position = objectPoolVector.position;
        }
        for (int i = 0; i < objectUpBoxPosArray.Length; i++)
        {
            valueRandNum = Random.Range(0, objectUpBoxArray.Length);

            if (!objectUpBoxArray[valueRandNum].activeSelf)
            {
                objectUpBoxArray[valueRandNum].SetActive(true);
                objectUpBoxArray[valueRandNum].transform.position = objectUpBoxPosArray[i].position;
            }
            else
            {
                i--;
                continue;
            }
        }

        for (int i = 0; i < objectDownBoxPosArray.Length; i++)
        {
            valueRandNum = Random.Range(0, objectDownBoxArray.Length);
            if (!objectDownBoxArray[valueRandNum].activeSelf)
            {
                objectDownBoxArray[valueRandNum].SetActive(true);
                objectDownBoxArray[valueRandNum].transform.position = objectDownBoxPosArray[i].position;

            }

            else
            {
                i--;
                continue;
            }
        }
        RandSpawnItem();

    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.left * objectMoveSpeed * Time.deltaTime);

        if (transform.position.x <= objectVectorEnd.x)
        {
            ResetPooling();
            scrolling.ResetBoxFilePositon(gameObject);
        }
    }

    void RandSpawnItem()
    {
        //index 랜덤뽑기
        randSpawnItem = Random.Range(0, 2);


        //살아있는 box중 랜덤한 위치와 레벨을 가져오기 (5분의 1의 확률)

        for (int i = 0; i < objectDownBoxArray.Length; i++)
        {
            int randnum = Random.Range(0, 10);
            if (i == randnum && objectDownBoxArray[i].activeSelf)
            {
                ObjectChange objScript = objectDownBoxArray[i].GetComponent<ObjectChange>();
                randPosX = objectDownBoxArray[i].transform.position.x;
                randLevel = objScript._levelIdx;
                Debug.Log(randPosX);
                Debug.Log(randLevel);
                Debug.Log(gameObject.name);
                break;
            }
        }


        //가져온 박스의 레벨 제외 비활성화
        for (int i = 0; i < itemRandSpawnPos.Length; i++)
        {
            itemRandSpawnPos[i].gameObject.SetActive(true);
           
            if (i != randLevel -1)
            {
                itemRandSpawnPos[i].gameObject.SetActive(false);
            }

        }

        //동일한 방법으로 아이템 두 개 중 하나만 활성화
        for (int j = 0; j < spawnItemPrefabs.Length; j++)
        {
            spawnItemPrefabs[j].gameObject.SetActive(true);

            if (j != randSpawnItem)
            {
                spawnItemPrefabs[j].gameObject.SetActive(false);
            }

        }

        for (int i = 0; i < itemRandSpawnPos.Length; i++)
        {
            for (int j = 0; j < spawnItemPrefabs.Length; j++)
            {
                //스폰될 위치와 스폰될 아이템이 전부 활성화 된 상태라면 위치를 변경
                if (itemRandSpawnPos[i].gameObject.activeSelf && spawnItemPrefabs[j].activeSelf)
                {
                    itemRandSpawnPos[i].position = new Vector3(randPosX, itemRandSpawnPos[i].transform.position.y, 0);
                    spawnItemPrefabs[j].transform.position = itemRandSpawnPos[i].position;
                }
            }
        }
    }

    private void ResetPooling()
    {
        for (int i = 0; i < objectUpBoxArray.Length; i++)
        {
            objectUpBoxArray[i].SetActive(false);
            objectDownBoxArray[i].SetActive(false);
        }
    }
}
