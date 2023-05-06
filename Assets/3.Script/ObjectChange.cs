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

    BoxCollider box;
    private void Awake()
    {  
        objectClass = new ObjectFile(objectBoxPrefabs, objectItemPrefabs);
        TryGetComponent(out box);
    }

    void OnEnable()
    {
        isChange = false;
        box.enabled = true;
        ChangeObj();

        // 점수 콜라이더 활성화
        if(scoreZone != null)
            scoreZone.SetActive(true);
    }

    public void ChangeObj()
    {
        if (!isChange)
        {
            for (int i = 0; i < objectClass.objectBoxPrefab.Length; i++)
            {
                box.enabled = true;
                objectClass.objectBoxPrefab[i].SetActive(true);
                objectClass.objectItemPrefab[i].SetActive(false);

            }
        }
        else
        {
            for (int i = 0; i < objectClass.objectItemPrefab.Length; i++)
            {
                box.enabled = false;
                objectClass.objectBoxPrefab[i].SetActive(false);
                objectClass.objectItemPrefab[i].SetActive(true);
            }
        }

        // 오브젝트 변화시 점수 콜라이더는 필요없어짐
        if(scoreZone != null)
            scoreZone.SetActive(false);
    }
}
