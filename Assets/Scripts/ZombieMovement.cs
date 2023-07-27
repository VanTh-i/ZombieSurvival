using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private GameObject player;
    private PlayerHp playerHp;
    private Vector2 moveMent;

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
        float angle = Mathf.Atan2(findPlayer.y, findPlayer.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        moveMent = findPlayer;
    }
    void ZombieMove(Vector2 findPlayer)
    {
        Vector3 distance = player.transform.position - transform.position;
        if (distance.magnitude >= 1)
        {
            rb.MovePosition((Vector2)transform.position + (findPlayer * speed * Time.deltaTime));
        }
        else rb.MovePosition((Vector2)transform.position + (findPlayer * 0 * Time.deltaTime));
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
