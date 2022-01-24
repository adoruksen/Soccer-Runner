using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterControl;

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
    public GameObject friendPrefab;
    public GameObject enemyPrefab;
    public GameObject chunkPrefab;
    public GameObject levelEndPrefab;

    [Header("Parameters")]
    public int chunkCount = 10;
    public int enemyCount = 15;

    [Header("Vectors")]
    Vector3 enemySpawnPos;

    void Start()
    {
        InstantiateChunks();
        InstantiateEnemy();
        InstantiateFriend();
        enemySpawnPos = new Vector3(-1.5f ,0,0) + transform.GetChild(0).GetChild(chunkCount - 1).position;
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

        for (int i = 1; i < chunkCount ; i++)
        {
            Vector3 pos = new Vector3(0, 0,Random.Range(10,20));
            GameObject myEnemy = Instantiate(enemyPrefab, new Vector3(-1.5f,0,0) + pos * i,enemyPrefab.transform.localRotation, transform.GetChild(1));
        }
    }

    void InstantiateFriend()
    {
        Vector3 pos = new Vector3(0, 0, chunkPrefab.GetComponent<Renderer>().bounds.size.z);
        for (int i = 1; i < chunkCount; i++)
        {
            GameObject myFriend = Instantiate(friendPrefab, new Vector3(1.5f, 0, 0) + pos * i, friendPrefab.transform.localRotation ,transform.GetChild(2));
        }
    }

}
