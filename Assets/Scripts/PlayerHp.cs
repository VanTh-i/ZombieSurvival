using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    public Slider playerHitPoints;
    public int maxHP = 20;
    //public int currentHP;
    // Start is called before the first frame update
    void Start()
    {
        playerHitPoints.maxValue = maxHP;
        playerHitPoints.value = maxHP;
        playerHitPoints.fillRect.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.playerDead == false && maxHP <= 0)
        {
            maxHP = 20;
            playerHitPoints.maxValue = maxHP;
            playerHitPoints.value = maxHP;
        }
    }
    public void HitByEnemy(int amount)
    {
        maxHP -= amount;
        playerHitPoints.fillRect.gameObject.SetActive(true);
        playerHitPoints.value = maxHP;
        if (maxHP <= 0)
        {
            
            GameManager.Instance.playerDead = true;
        }
    }
}
