using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    private List<GameObject> pooledBullets = new List<GameObject>();
    private int amountToPool = 15;

    [SerializeField] private GameObject bulletPrefabs;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(bulletPrefabs);
            obj.SetActive(false);
            pooledBullets.Add(obj);
        }
    }

    public GameObject GetpooledBullet()
    {
        for (int i = 0; i < pooledBullets.Count ; i++)
        {
            if (!pooledBullets[i].activeInHierarchy)
            {
                return pooledBullets[i];
            }
        }

        return null;
    }
}
