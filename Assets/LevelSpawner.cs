using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public ObstacleMover ObstaceleGroup;
    public int numberOfObstacles = 10;
    public Queue<ObstacleMover> obstaclePool = new Queue<ObstacleMover>();

    private Queue<ObstacleMover> obstacleQueue = new Queue<ObstacleMover>();
    private float resetPositionZ = -10f; // Position where the obstacle will be disabled
    private float spanPositionZ = 89;
    private float moveSpeed = 5;
    int totalSpawncount = 0;
    private int targetSpawnCount = 5;
    public void Start()
    {
        CreateObstaclePool(numberOfObstacles);

    }
    public void StartSpawner()
    {
        StartCoroutine(SpawnObstacleRoutine());
    }
    // create pool of ibstacles
    public void CreateObstaclePool(int numberOfObstacles)
    {
        for (int i = 0; i < numberOfObstacles; i++)
        {
            ObstacleMover obstacle = Instantiate(ObstaceleGroup);
            obstacle.gameObject.SetActive(false);
            obstacle.transform.parent = this.transform;
            obstaclePool.Enqueue(obstacle);
        }
    }

    // i want to spawn one after another and then create endless obstacles
    private IEnumerator SpawnObstacleRoutine()
    {
        while (true)
        {
            ObstacleMover obstacle = SpawnObstacle();
            if (totalSpawncount > targetSpawnCount)
            {
                ChangeMoveSpeed();
                targetSpawnCount = targetSpawnCount + 5;
            }
            yield return new WaitUntil(() => obstacle.transform.localPosition.z <= 60);
        }
    }

    private ObstacleMover SpawnObstacle()
    {
        if (obstaclePool.Count > 0)
        {
            ObstacleMover obstacle = obstaclePool.Dequeue();
            obstacle.gameObject.SetActive(true);
            obstacle.transform.localPosition = new Vector3(0, 0, spanPositionZ); // Random spawn position
            obstacleQueue.Enqueue(obstacle);
            totalSpawncount++;
            return obstacle;
        }
        else
        {
            Debug.LogWarning("No obstacles available in the pool to spawn.");
            return null;
        }
    }

    private void Update()
    {
        if (GameManager.Instance.isGameOver)
        {
            return; // Do not process if the game is over
        }
        if (obstacleQueue.Count > 0)
        {
            MoveObstacles();
        }

    }

    private void ChangeMoveSpeed()
    {
        moveSpeed++;
    }

    private void MoveObstacles()
    {
        foreach (ObstacleMover obstacle in obstacleQueue)
        {
            if (obstacle != null && obstacle.gameObject.activeInHierarchy)
            {
                obstacle.MoveObstacle(moveSpeed);
                if (obstacle.transform.localPosition.z < resetPositionZ)
                {
                    obstacle.gameObject.SetActive(false);
                    obstacleQueue.Dequeue();
                    obstaclePool.Enqueue(obstacle);
                    break; // Exit the loop after deactivating the obstacle

                }
            }
        }
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }
    public void ResetSpawner()
    {
        foreach (ObstacleMover obstacle in obstacleQueue)
        {
            if (obstacle != null)
            {
                obstacle.gameObject.SetActive(false);
                obstaclePool.Enqueue(obstacle);
            }
        }
        obstacleQueue.Clear();
        totalSpawncount = 0;
        targetSpawnCount = 5;
        moveSpeed = 5;
        StopAllCoroutines();
        StartCoroutine(SpawnObstacleRoutine());
    }

    public void OnGameOver()
    {
        StopAllCoroutines();
    }

}
