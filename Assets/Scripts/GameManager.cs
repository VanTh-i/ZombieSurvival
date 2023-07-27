using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get => instance; }

    public Text scoreText;
    int score;
    int maxEnemy = 50;
    public bool playerDead  = false;
    public bool victory = false;
    public GameObject player;
    public GameObject youLoseUI;
    public GameObject victoryUI;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        score = maxEnemy;
        scoreText.text = "" + score;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDead();
        Victory();
    }
    public void AddScore(int amount)
    {
        score -= amount;
        scoreText.text = score.ToString();
    }
    public void PlayerDead()
    {
        if (playerDead == true)
        {
            SpawnManager spawnManager = FindObjectOfType<SpawnManager>();
            spawnManager.StopSpawn();
            youLoseUI.SetActive(true);
            player.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.R) && playerDead)
        {
            score = maxEnemy;
            scoreText.text = score.ToString();

            playerDead = false;
            youLoseUI.SetActive(false);
            SpawnManager spawnManager = FindObjectOfType<SpawnManager>();
            spawnManager.Spawn();
            player.SetActive(true);
        }
    }

    public void Victory()
    {
        if (score == 0)
        {
            victory = true;
            victoryUI.SetActive(true);
            SpawnManager spawnManager = FindObjectOfType<SpawnManager>();
            spawnManager.StopSpawn();
            player.SetActive(false);
        }
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Zombie Survival");
    }
}
