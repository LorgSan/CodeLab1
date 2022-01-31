using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject badFallingObjectPrefab;
    public GameObject goodFallingObjectPrefab;
    GameObject fallingObjectPrefab;
    public float SpawnTime = 1f;
    float startSpawn;
    public float minSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnerFunction", SpawnTime);
        startSpawn = SpawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnerFunction()
    {

        int ranObj = Random.Range(0, 2);
        if (ranObj == 0)
        {
            fallingObjectPrefab = badFallingObjectPrefab;
        }
        else if (ranObj == 1)
        {
            fallingObjectPrefab = goodFallingObjectPrefab;
        }

        GameObject newFallingObject = Instantiate(fallingObjectPrefab);
        newFallingObject.transform.position = new Vector3(
                                        Random.Range(-3f, 3),
                                        4f,
                                        0f
            );
        SpawnTime -= 0.1f;
        if (SpawnTime < minSpawnTime)
        {
            SpawnTime = startSpawn;
        }
        Invoke("SpawnerFunction", SpawnTime);
    }
}
