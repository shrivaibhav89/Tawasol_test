using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteSync : MonoBehaviour
{
    private float offsetX = -8f;

    // imple ment on coincollected listener here 

    private void OnEnable()
    {
        GameManager.Instance.OnCoinCollected += OnCoinCollectedHandler;
    }
    private void OnDisable()
    {
        GameManager.Instance.OnCoinCollected -= OnCoinCollectedHandler;
    }
    private void OnCoinCollectedHandler()
    {
        // Handle coin collected event
        // For example, you can update the remote player's score or perform some action
        Debug.Log("Remote player collected a coin");
        ChecknearbyCoin();
        GameManager.Instance.coinParticalManager.PlayCoinCollectParticle(transform.position);
    }

    private void ChecknearbyCoin()
    { 
        // Check for nearby coins and perform actions if needed
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5f);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Coin"))
            {
                // Perform actions with the nearby coin
                Debug.Log("Nearby coin detected: " + hitCollider.name);
                hitCollider.gameObject.SetActive(false); // Example action: deactivate the coin
            }
        }
    }
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
