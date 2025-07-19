using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteSync : MonoBehaviour
{
    private float offsetX=-8f;
    
    public void InitPosition(Vector3 position)
    {
        position.x += offsetX; // Adjust the x position with an offset
        transform.position = position; // Set the initial position
    }
    public void RemotePositionSync(Vector3 position)
    {
        position.x += offsetX; // Adjust the x position with an offset
        transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * 10f);
    }
    
}
