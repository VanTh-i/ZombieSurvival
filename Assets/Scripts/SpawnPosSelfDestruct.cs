using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPosSelfDestruct : MonoBehaviour
{
    float createdTime;
    void Start()
    {
        createdTime = Time.time;
    }

    void Update()
    {
        if (Time.time - createdTime > 1f)
        {
            Destroy(gameObject);
        }
    }
}
