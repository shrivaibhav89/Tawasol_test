using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public coinRotator[] coinRotators;
    // public float speed = 5f; // Position where the obstacle will be disabled
    private void OnEnable()
    {
        foreach (coinRotator rotator in coinRotators)
        {
            rotator.gameObject.SetActive(true);
        }
    }
    public void MoveObstacle(float speed)
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}
