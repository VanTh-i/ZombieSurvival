using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //public GameObject zombiePrefabs;
    public GameObject[] zombieDelayPrefabs;
    public GameObject SpawnPosZb;
    //public GameObject zombieDistant;
    //ublic GameObject SpawnPosZbDistant;

    float spawnRangeX = 20f;
    float spawnRangeY = 15f;
    float spawnPosX;
    float spawnPosY;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnZombie()
    {
        StartCoroutine(SpawnZbDelay());
    }
    public void Spawn()
    {
        InvokeRepeating("SpawnZombie", 1f, 1.5f);
        AudioManager.Instance.PlaySFX("Zombie");
    }
    public void StopSpawn()
    {
        CancelInvoke("SpawnZombie");
    }
    IEnumerator SpawnZbDelay()
    {
        spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        spawnPosY = Random.Range(-spawnRangeY, spawnRangeY);
        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, 0);
        int zombieIndex = Random.Range(0, zombieDelayPrefabs.Length);

        Instantiate(SpawnPosZb, spawnPos, SpawnPosZb.transform.rotation);
        //Instantiate(SpawnPosZbDistant, spawnPos, SpawnPosZbDistant.transform.rotation);

        yield return new WaitForSeconds(1f);

        Instantiate(zombieDelayPrefabs[zombieIndex], spawnPos, zombieDelayPrefabs[zombieIndex].transform.rotation);
        //Instantiate(zombieDistant, spawnPos, zombieDistant.transform.rotation);

    }
}
