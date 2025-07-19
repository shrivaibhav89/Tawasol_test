using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public float moveSpeed = 5f; // Speed of the obstacles
    public int score = 0;

    public LevelSpawner levelSpawner;
    public LevelSpawner LevelSpawnerRemote;
    public PlayerControll playerController;
    public bool isGameOver = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void StartGame()
    {
        isGameOver = false; // Reset game over state
        levelSpawner.StartSpawner();
        LevelSpawnerRemote.StartSpawner();
        playerController.ResetPlayer(); // Reset player position
        UIManager.Instance.SetScore(score); // Initialize score display
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UIManager.Instance.SetScore(score);
    }


    public void ResetGame()
    {
        score = 0;
        UIManager.Instance.SetScore(score);
        levelSpawner.ResetSpawner();
        LevelSpawnerRemote.ResetSpawner();
        playerController.ResetPlayer(); // Reset player position
        isGameOver = false;
    }
    public void GameOver()
    {
        UIManager.Instance.ShowGameOverPanel();
        isGameOver = true;
    }
}
