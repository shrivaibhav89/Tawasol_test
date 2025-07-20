using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinRotator : MonoBehaviour
{
   public float rotationSpeed = 200f; // Speed of rotation
    void Update()
    {
        // Rotate the coin around its Y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
