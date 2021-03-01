using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public Transform parentObjects;
    [SerializeField] private Transform[] rows;
    [HideInInspector] public bool readyToRotateCamera;
    private ObjectPooler objectPooler;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        readyToRotateCamera = false;
        objectPooler = ObjectPooler.Instance;
    }

    public void GenerateObjectsInScene()
    {
        for(int i = 0; i < rows.Length; i++)
        {
            objectPooler.SpawnFromPool("Cube", new Vector3(rows[i].position.x, parentObjects.position.y, rows[i].transform.parent.position.z), Quaternion.identity);
        }
    }
}
