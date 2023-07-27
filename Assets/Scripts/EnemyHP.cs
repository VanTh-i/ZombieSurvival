using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public Slider enemyHitPoints;
    public int maxHP;
    //public int currentHP;
    // Start is called before the first frame update
    void Start()
    {
        enemyHitPoints.maxValue = maxHP;
        enemyHitPoints.value = maxHP;
        enemyHitPoints.fillRect.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void HitEnemy(int amount)
    {
        maxHP -= amount;
        enemyHitPoints.fillRect.gameObject.SetActive(true);
        enemyHitPoints.value = maxHP;
        if (maxHP == 0)
        {
            Destroy(gameObject);
            GameManager.Instance.AddScore(1);
        }
    }
}
