using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistantZombieMove : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private GameObject player;
    private PlayerHp playerHp;
    private Vector2 moveMent;

    public Transform firePoint;
    public GameObject Zombieshoot;
    public float bulletSpeed = 20f;
    private float delayShoot = 2f; // gian cach moi lan quai ban
    float lastShotTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        playerHp = FindObjectOfType<PlayerHp>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.playerDead == false)
        {
            FollowPlayer();
        }

    }
    private void FixedUpdate()
    {
        if (GameManager.Instance.victory || GameManager.Instance.playerDead)
        {
            Destroy(gameObject);
        }
        if (GameManager.Instance.playerDead == false)
        {
            ZombieMove(moveMent);
        }

    }
    void FollowPlayer()
    {
        Vector3 findPlayer = (player.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(findPlayer.y, findPlayer.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        moveMent = findPlayer;
    }
    void ZombieMove(Vector2 findPlayer)
    {
        Vector3 distance = player.transform.position - transform.position;
        if (distance.magnitude >= 12)
        {
            rb.MovePosition((Vector2)transform.position + (findPlayer * speed * Time.deltaTime));
        }
        else
        {
            rb.MovePosition((Vector2)transform.position + (findPlayer * 0 * Time.deltaTime));

            if (Time.time - lastShotTime > delayShoot)
            {
                Shoot();
                lastShotTime = Time.time;
            }    
        } 

    }

    void Shoot()
    {
        GameObject bullet = Instantiate(Zombieshoot, firePoint.position, firePoint.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * speed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //collision.GetComponent<PlayerHp>().HitByEnemy(1);
            playerHp.HitByEnemy(1);
            AudioManager.Instance.PlaySFX("Hit");
        }

    }
}
