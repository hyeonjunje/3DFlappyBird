using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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

    [SerializeField] private int randSpawnItem; //������ ������

    [SerializeField] private Transform[] itemRandSpawnPos;
    [SerializeField] private GameObject[] spawnItemPrefabs;

    public int randLevel = 0;
    public float randPosX;

    /*
        1. �� ������ ��յ��� 3���� Instance�Ѵ�.
        2. Ȱ��ȭ �� ������ ��յ� �� �������� ȣ�� 
        3. Ȱ��ȭ�Ǹ� �������� �̵�

        4. ���� Ȯ���� ������ ����
        5. �����Ǵ� �������� �Ѱ�
        6. 5���� 1�� Ȯ���� ������ ��ġ

      */
    private void Awake()
    {
        scrolling = GetComponentInParent<Object_Scrplling>();
        //Box Array = ���� ���� x ���� �� ���� 
        objectUpBoxArray = new GameObject[valueBoxCount];
        objectDownBoxArray = new GameObject[valueBoxCount];

        //������ ���� ���� ��ŭ for������ ��ȯ
        for (int i = 0; i < objectUpBoxArray.Length; i++)
        {
            //Pool Vector�� �� ������ �����۵��� Instance
            objectUpBoxArray[i] = Instantiate(objectUpBoxPrefab[valueBoxPrefab], objectPoolVector.position, Quaternion.identity, objectPoolVector);
            objectDownBoxArray[i] = Instantiate(objectDownBoxPrefab[valueBoxPrefab], objectPoolVector.position, Quaternion.identity, objectPoolVector);

            objectUpBoxArray[i].SetActive(false);
            objectDownBoxArray[i].SetActive(false);
            //=====================================================  �� ������ ������ ���� ������ ī��Ʈ�� �й��Ͽ� ���� ��ȯ
            valueBoxPrefab++;

            if (valueBoxPrefab >= objectUpBoxPrefab.Length)
            {
                valueBoxPrefab = 0;
            }
        }
    }
    private void OnEnable()
    {
        List<int> randomIndex = new List<int>();
        for (int i = 0; i < objectDownBoxArray.Length; i++)
            randomIndex.Add(i);

        // ������ ����
        randomIndex = randomIndex.GetShuffleList();

        for (int i = 0; i < spawnItemPrefabs.Length; i++)
        {
            spawnItemPrefabs[i].transform.position = objectPoolVector.position;
        }

        for (int i = 0; i < objectUpBoxPosArray.Length; i++)
        {
            int valueRandNum = randomIndex[i];

            objectUpBoxArray[valueRandNum].SetActive(true);
            objectUpBoxArray[valueRandNum].transform.position = objectUpBoxPosArray[i].position;

            objectDownBoxArray[objectUpBoxArray.Length - 1 - valueRandNum].SetActive(true);
            objectDownBoxArray[objectUpBoxArray.Length - 1 - valueRandNum].transform.position = objectDownBoxPosArray[i].position;
        }

/*        for (int i = 0; i < objectDownBoxPosArray.Length; i++)
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
        }*/
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
        //index �����̱�
        randSpawnItem = Random.Range(0, 2);

        //����ִ� box�� ������ ��ġ�� ������ �������� (5���� 1�� Ȯ��)
        for (int i = 0; i < objectDownBoxArray.Length; i++)
        {
            int randnum = Random.Range(0, 10);
            if (i == randnum && objectDownBoxArray[i].activeSelf)
            {
                ObjectChange objScript = objectDownBoxArray[i].GetComponent<ObjectChange>();
                randPosX = objectDownBoxArray[i].transform.position.x;
                randLevel = objScript._levelIdx;
                break;
            }
        }


        //������ �ڽ��� ���� ���� ��Ȱ��ȭ
        for (int i = 0; i < itemRandSpawnPos.Length; i++)
        {
            itemRandSpawnPos[i].gameObject.SetActive(true);
           
            if (i != randLevel -1)
            {
                itemRandSpawnPos[i].gameObject.SetActive(false);
            }

        }

        //������ ������� ������ �� �� �� �ϳ��� Ȱ��ȭ
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
                //������ ��ġ�� ������ �������� ���� Ȱ��ȭ �� ���¶�� ��ġ�� ����
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
