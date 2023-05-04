using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Movement: MonoBehaviour
{
    [SerializeField] private float objectMoveSpeed;

    [Header("Instance Value")]

    [SerializeField] private int valueBoxCount;

    [Header("Vector Info")]

    [SerializeField] private Vector3 objectVectorEnd;
    [SerializeField] private Vector3 objectVectorStart;
    [SerializeField] private Transform objectPoolVector;


    [Header("Instance Info")]

    [SerializeField] private GameObject[] objectUpBoxArray;
    [SerializeField] private GameObject[] objectUpBoxPrefab;
    [SerializeField] private Transform[] objectUpBoxPosArray;

    [SerializeField] private GameObject[] objectDownBoxArray;
    [SerializeField] private GameObject[] objectDownBoxPrefab;
    [SerializeField] private Transform[] objectDownBoxPosArray;


    private int valueCountPlus;
    private int valueRandNum;
    private int valueBoxPrefab;


    /*
        1. 각 레벨의 기둥들을 3개씩 Instance한다.
        2. 활성화 될 때마다 기둥들 중 랜덤으로 호출 
        3. 활성화되면 왼쪽으로 이동

      */

    private void Awake()
    {
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

            if(valueBoxPrefab >= objectUpBoxPrefab.Length)
            {
                valueBoxPrefab = 0;
            }
        }
    }
    private void OnEnable()
    {
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


    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * objectMoveSpeed * Time.deltaTime);

        if(transform.position.x <= objectVectorEnd.x)
        {
            transform.position = objectVectorStart;
        }
    }
}
