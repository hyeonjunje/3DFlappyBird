using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectFile {

    public ObjectFile(GameObject[] _box, GameObject[] _item) { objectBoxPrefab = _box; objectItemPrefab = _item; }

    public GameObject[] objectBoxPrefab;
    public GameObject[] objectItemPrefab;
}

public class ObjectChange : MonoBehaviour
{
    public int _levelIdx;
    public ObjectFile objectClass;
    public bool isChange;

    [SerializeField] private GameObject[] objectBoxPrefabs;
    [SerializeField] private GameObject[] objectItemPrefabs;

    [SerializeField] private GameObject scoreZone = null;

    private void Awake()
    {  
        objectClass = new ObjectFile(objectBoxPrefabs, objectItemPrefabs);
    }

    void OnEnable()
    {
        isChange = false;
        ChangeObj();

        // 점수 콜라이더 활성화
        if(scoreZone != null)
            scoreZone.SetActive(true);
    }

    public void ChangeObj()
    {
        for (int i = 0; i < objectClass.objectBoxPrefab.Length; i++)
        {
            objectClass.objectBoxPrefab[i].SetActive(!isChange);
            objectClass.objectItemPrefab[i].SetActive(isChange);
        }

        // 오브젝트 변화시 점수 콜라이더는 필요없어짐
        if(scoreZone != null)
            scoreZone.SetActive(false);
    }
}
