using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;

    public float speed = 5;
    public float obstaclePushbackDistance = 2;
    public Rigidbody rb;

    float horizontalMultiplier = 2;
    float horizontalInput;

    // Define the boundaries within which the player can move
    public float minX = -5f;
    public float maxX = 5f;

    private bool obstacleCollisionDetected = false;
    private void FixedUpdate()
    {
        if (!alive) return;

        if (!obstacleCollisionDetected)
        {
            // Regular movement logic
            Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
            Vector3 horizontalMove = transform.right * horizontalInput * speed * horizontalMultiplier * Time.fixedDeltaTime;
            Vector3 newPosition = rb.position + forwardMove + horizontalMove;

            // Clamp the player's position within the specified range
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

            rb.MovePosition(newPosition);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            obstacleCollisionDetected = true;

            // Adjust the player's position immediately upon collision
            Vector3 awayFromObstacle = -transform.forward; // Move backward along local z-axis
            Vector3 newPosition = rb.position + awayFromObstacle * obstaclePushbackDistance;

            rb.MovePosition(newPosition);
            obstacleCollisionDetected = false;
        }
    }

    void Update()
    {
         if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            horizontalInput = touch.position.x / Screen.width * 2 - 1;
        }
        else if (Input.GetMouseButton(0))  // Mouse input
        {
            // Simulate touch by using mouse position
            horizontalInput = (Input.mousePosition.x / Screen.width) * 2 - 1;  // Range -1 to 1 based on horizontal mouse position
        }
        else
        {
            // Handle keyboard input
            horizontalInput = Input.GetAxis("Horizontal");  // -1 to 1 based on arrow keys or A/D
        }

      //  if (transform.position.y < -5)
      //      Die();
    }

    /*
    public void Die()
    {
        alive = false;

        Invoke("Restart", 2);
    }
    */
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
