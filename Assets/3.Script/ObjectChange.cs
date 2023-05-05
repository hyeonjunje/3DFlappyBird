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
    public ObjectFile objectClass;
    // Start is called before the first frame update
    public bool isChange;

    [SerializeField] private GameObject[] objectBoxPrefabs;
    [SerializeField] private GameObject[] objectItemPrefabs;

    private void Awake()
    {  
        objectClass = new ObjectFile(objectBoxPrefabs, objectItemPrefabs);
    }

    // Update is called once per frame
    void OnEnable()
    {
        isChange = false;
        ChangeObj();
    }

    public void ChangeObj()
    {
        for (int i = 0; i < objectClass.objectBoxPrefab.Length; i++)
        {
            objectClass.objectBoxPrefab[i].SetActive(!isChange);
            objectClass.objectItemPrefab[i].SetActive(isChange);
        }
    }
}
