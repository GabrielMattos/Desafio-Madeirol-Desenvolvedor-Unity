using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private Transform parentObjects;
    [SerializeField] private Transform[] rows;

    // Start is called before the first frame update
    void Start()
    {
        GenenateObjectsInScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenenateObjectsInScene()
    {
        for(int i = 0; i < rows.Length; i++)
        {
            GameObject GO = Instantiate(objectPrefab, new Vector3(rows[i].position.x, transform.position.y, rows[i].transform.parent.position.z), Quaternion.identity);
            GO.transform.parent = parentObjects;
        }
    }
}
