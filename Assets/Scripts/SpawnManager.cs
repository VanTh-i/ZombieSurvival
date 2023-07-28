using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] zombieDelayPrefabs;
    public GameObject SpawnPosZb;

    float spawnRangeX = 20f;
    float spawnRangeY = 15f;
    float spawnPosX;
    float spawnPosY;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Spawn()
    {
        StartCoroutine(SpawnZbDelay());
    }
    public void StopSpawn()
    {
        
    }
    IEnumerator SpawnZbDelay()
    {
        while (true)
        {
            spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
            spawnPosY = Random.Range(-spawnRangeY, spawnRangeY);
            Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, 0);
            int zombieIndex = Random.Range(0, zombieDelayPrefabs.Length);

            yield return new WaitForSeconds(1f);

            Instantiate(SpawnPosZb, spawnPos, SpawnPosZb.transform.rotation);

            yield return new WaitForSeconds(1f);

            Instantiate(zombieDelayPrefabs[zombieIndex], spawnPos, zombieDelayPrefabs[zombieIndex].transform.rotation);
        }
    }
}
