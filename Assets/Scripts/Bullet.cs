using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float xBound = 20f;
    private float yBound = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DestroyBullet();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            Destroy(gameObject);
            collision.GetComponent<EnemyHP>().HitEnemy(1);
            //Destroy(collision.gameObject);
        }
    }
    void DestroyBullet()
    {
        if (transform.position.x > xBound || transform.position.x < -xBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.y > yBound || transform.position.y < -yBound)
        {
            Destroy(gameObject);
        }
    }
}
