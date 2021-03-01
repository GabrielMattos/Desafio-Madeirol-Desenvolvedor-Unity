using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{   
    [System.Serializable]
    public class Pool 
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    public static ObjectPooler Instance;

    private SceneController sceneController;

    private void Awake() 
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        sceneController = FindObjectOfType<SceneController>();
        CreateAndDisableObjects();
    }

    public void CreateAndDisableObjects()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject GO = Instantiate(pool.prefab);
                GO.transform.parent = sceneController.parentObjects;
                GO.SetActive(false);
                objectPool.Enqueue(GO);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if(!poolDictionary.ContainsKey(tag))
        {
            return null;
        }

        GameObject objectoToSpawn = poolDictionary[tag].Dequeue();
        objectoToSpawn.SetActive(true);
        objectoToSpawn.transform.position = position;
        objectoToSpawn.transform.rotation = rotation;
        objectoToSpawn.transform.parent = sceneController.parentObjects;
        poolDictionary[tag].Enqueue(objectoToSpawn);

        return objectoToSpawn;
    }
}
