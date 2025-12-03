using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsSpawn : MonoBehaviour
{
    public Transform[] spawns;
    public GameObject[] objects;
    public float waitTime = 3f;

    void Start()
    {
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject() 
    {
        yield return new WaitForSeconds(waitTime);

        int spawn = Random.Range(0, spawns.Length);
        int spawnObject = Random.Range(0, objects.Length);

        Instantiate(objects[spawnObject], spawns[spawn].position, Quaternion.identity);
        if(waitTime > 0.8)
        {
            waitTime -= 0.1f;
        }
        
        StartCoroutine(SpawnObject());
    }
}
