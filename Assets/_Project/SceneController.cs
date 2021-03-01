using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private int numberOfObjectsInScene;
    [SerializeField] private Transform parentObjects;


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
        for(int i = 0; i < numberOfObjectsInScene; i++)
        {
            GameObject GO = Instantiate(objectPrefab, transform.position, Quaternion.identity);
            GO.transform.parent = parentObjects;
        }
    }
}
