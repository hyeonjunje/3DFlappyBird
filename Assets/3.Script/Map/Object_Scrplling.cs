using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Scrplling : MonoBehaviour
{
    [Header("Vector Info")]

    [SerializeField] private GameObject[] objectBoxFiles;
    [SerializeField] private Vector3 objectVectorStart;

    public void ResetBoxFilePositon(GameObject boxFileObject )
    {
        boxFileObject.SetActive(false);
        boxFileObject.transform.position = objectVectorStart;
        boxFileObject.SetActive(true);
    }
}
