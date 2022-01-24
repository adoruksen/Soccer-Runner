using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    #region Singleton Pattern
    public static SpawnManager instance;
    private void Awake()
    {
        instance = this;
    }

    #endregion


    [Header ("Prefabs")]
    [SerializeField] GameObject friendPrefab;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] GameObject levelEndPrefab;

    [Header("Parameters")]
    [SerializeField] int chunkCount = 10;
    //[SerializeField] int enemyCount;
    //[SerializeField] int friendCount;

    //[Header("Queues")]
    //Queue<GameObject> enemyQueue = new Queue<GameObject>();
    //Queue<GameObject> friendQueue = new Queue<GameObject>();

    void Start()
    {
        InstantiateChunks();
        InstantiateEnemy();
        InstantiateFriend();
    }

    void InstantiateChunks()
    {
        Vector3 pos = new Vector3(0, 0, chunkPrefab.GetComponent<Renderer>().bounds.size.z);
        for (int i = 0; i <= chunkCount; i++)
        {
            if (i == chunkCount)
            {
                GameObject myEndChunk = Instantiate(levelEndPrefab, pos * i, Quaternion.identity, transform.GetChild(0));
            }
            else
            {
                GameObject myChunk = Instantiate(chunkPrefab, pos * i, Quaternion.identity, transform.GetChild(0));
            }
        }
    }

    void InstantiateEnemy()
    {
        Vector3 pos = new Vector3(0, 0, chunkPrefab.GetComponent<Renderer>().bounds.size.z);
        for (int i = 1; i < chunkCount ; i++)
        {
            GameObject myEnemy = Instantiate(enemyPrefab, new Vector3(-1.5f,0,0) + pos * i,enemyPrefab.transform.localRotation, transform.GetChild(1));
            //enemyQueue.Enqueue(myEnemy);
        }
    }

    void InstantiateFriend()
    {
        Vector3 pos = new Vector3(0, 0, chunkPrefab.GetComponent<Renderer>().bounds.size.z);
        for (int i = 1; i < chunkCount; i++)
        {
            GameObject myFriend = Instantiate(friendPrefab, new Vector3(1.5f, 0, 0) + pos * i, friendPrefab.transform.localRotation, transform.GetChild(2));
            //friendQueue.Enqueue(myFriend);
        }
    }
    void Update()
    {
        
    }
}
