using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * 3차원 배열을 이용한 아이템 정렬
 * 
 * 2차원으로 x축과 y축의 4면도를 만듬
 * 그 2차원배열을 클래스로 만든다. 
 * 해당 클래스를 가진 배열을 사용하여 z축으로 나열
 * 
 * 정리 : Class { x축 나열 프리팹, y축 나열 프리팹} => Class를 z축 List로 넣기 -> 3차원 배열 완성
 */

[System.Serializable]
public class Jelly2DArray
{
    public Jelly2DArray(GameObject _itemPrefabs, int _x, int _y)
    { itemPrefabs = _itemPrefabs; itemArrayValueX = _x; itemArrayValueY = _y; }

    public GameObject itemPrefabs;

    public int itemArrayValueX;
    public int itemArrayValueY;
}
public class JellySpawner : MonoBehaviour
{
    public static JellySpawner Instance = null;
    public GameObject itemJellyPrefabXY;
    public GameObject itemJellyPrefabZ;
    public GameObject[] itemJellyObjects;

    public Vector3 PoolingVec;

    int itemPoolingCount;
    public int _sizeX;
    public int _sizeY;
    public int _sizeZ;
    int _index = 0;
    [SerializeField] private GameObject[] itemParentZ;
    Jelly2DArray[,] jellyArray;
    // Update is called once per frame


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        itemParentZ = new GameObject[_sizeZ];
        itemPoolingCount = _sizeX * _sizeY;
        itemJellyObjects = new GameObject[itemPoolingCount];
        jellyArray = new Jelly2DArray[_sizeX, _sizeY];



        for (int k = 0; k < itemParentZ.Length; k++)
        {
            itemParentZ[k] = Instantiate(itemJellyPrefabZ, PoolingVec, Quaternion.identity, gameObject.transform);
            itemParentZ[k].transform.localPosition = new Vector3(0, 0, k * 0.1f);

         
            for (int i = 0; i < _sizeX; i++)
            {
                for (int j = 0; j < _sizeY; j++)
                {
                    itemJellyObjects[_index] = Instantiate(itemJellyPrefabXY, PoolingVec, Quaternion.identity, itemParentZ[k].transform);

                    jellyArray[i, j] = new Jelly2DArray(itemJellyObjects[_index], i, j);
                    jellyArray[i, j].itemPrefabs.gameObject.transform.localPosition = new Vector3(i * 0.1f, j * 0.1f, 0);
                    _index++;

                    if (_index >= itemPoolingCount)
                    {
                        _index = 0;
                    }
                }
            }
        }
    }

    public void TransformJelly()
    {

    }
}
 