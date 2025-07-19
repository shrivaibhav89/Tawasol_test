using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public float jumpForce;
    private Rigidbody rb;
    private bool isplayerMoving = false;
    private float xMovement = 0f;
    public bool isGrounded = true;
    private float moveSpeed = 5f;
    public RemoteSync remotePlayer;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // rb.isKinematic = true; // Ensure the Rigidbody is not kinematic
        isGrounded = true; // Initialize grounded state
        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found on the player object.");
        }
    }
    private void MovePlayer()
    {
        Vector3 movement = new Vector3(xMovement, 0, 0);
        movement = transform.position + movement * Time.fixedDeltaTime * moveSpeed;
        float clampedX = Mathf.Clamp(movement.x, -2f, 2f); // Clamp the x position to a range
        movement = new Vector3(clampedX, movement.y, movement.z);
        rb.MovePosition(movement);
    }

    public void Jump()
    {
        if (!isGrounded) return; // Prevent jumping if not grounded
                                 // rb.isKinematic = false; // Ensure the Rigidbody is not kinematic before jumping
                                 // Set grounded state to false when jumping
        rb.velocity = Vector3.zero; // Reset velocity to prevent double jumping
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            isplayerMoving = true;
            xMovement = Input.GetAxis("Horizontal");
            //MovePlayer(xMovement);
        }
        else
        {
            isplayerMoving = false;
        }
        remotePlayer.RemotePositionSync(transform.position);
    }

    void FixedUpdate()
    {
        if (transform.position.y < 1f && !isGrounded) // Check if player is below a certain height
        {
            // rb.isKinematic = true; // Reset Rigidbody to kinematic state
            isGrounded = true; // Reset grounded state
            transform.position = new Vector3(transform.position.x, 1f, transform.position.z); // Reset position to a safe height
        }
        else if (transform.position.y > 1f)
        {
            isGrounded = false; // Set grounded state to true if player is above the ground
        }
        if (isplayerMoving && isGrounded)
        {
            MovePlayer();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Collided with obstacle");
        }
    }
}
