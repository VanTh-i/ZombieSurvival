using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistantZombie : ZombieMovement
{
    public Transform firePoint;
    public GameObject Zombieshoot;
    public float bulletSpeed = 20f;
    private float delayShoot = 2f; // gian cach moi lan quai ban
    float lastShotTime;
    float distantRange = 12;

    protected override void FollowPlayer()
    {
        Vector3 findPlayer = (player.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(findPlayer.y, findPlayer.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        moveMent = findPlayer;
    }

    protected override void ZombieMove(Vector2 findPlayer)
    {
        Vector3 distance = player.transform.position - transform.position;
        if (distance.magnitude >= distantRange)
        {
            rb.MovePosition((Vector2)transform.position + (findPlayer * speed * Time.deltaTime));
        }
        else
        {
            rb.MovePosition((Vector2)transform.position + (findPlayer * 0 * Time.deltaTime));

            if (Time.time - lastShotTime > delayShoot)
            {
                Invoke("Shoot", 0.1f);
                //Shoot();
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
}
