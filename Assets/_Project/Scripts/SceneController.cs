using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private Transform parentObjects;
    [SerializeField] private Transform[] rows;
    [HideInInspector] public bool readyToRotateCamera;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        readyToRotateCamera = false;
    }

    public void GenerateObjectsInScene()
    {
        for(int i = 0; i < rows.Length; i++)
        {
            GameObject GO = Instantiate(objectPrefab, new Vector3(rows[i].position.x, parentObjects.position.y, rows[i].transform.parent.position.z), Quaternion.identity);
            GO.transform.parent = parentObjects;
        }
    }
}
