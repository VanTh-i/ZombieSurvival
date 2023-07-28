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
        if (GameManager.Instance.playerDead || GameManager.Instance.victory)
        {
            Destroy(gameObject);
        }

        if (Time.time - createdTime > 1f)
        {
            Destroy(gameObject);
        }
    }
}
