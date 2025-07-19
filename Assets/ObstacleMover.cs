using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
   // public float speed = 5f; // Position where the obstacle will be disabled

    public void MoveObstacle(float speed)
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}
