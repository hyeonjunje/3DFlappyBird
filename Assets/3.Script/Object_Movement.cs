using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Movement: MonoBehaviour
{
    [SerializeField] private float objectMoveSpeed;

    [SerializeField] private int valueBoxCount;

    [Header("Vector Info")]

    [SerializeField] private Vector3 objectVectorEnd;
    [SerializeField] private Vector3 objectVectorStart;
    [SerializeField] private Vector3 objectPoolVector;


    [Header("Instance Info")]

    [SerializeField] private GameObject[] objectBoxArray;
    [SerializeField] private GameObject[] objectBoxPrefab;
    [SerializeField] private Transform[] objectBoxPosArray;


    private int valueCountPlus;
    private int valueRandNum;

    private void OnEnable()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * objectMoveSpeed);
    }
}
