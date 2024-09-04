using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] bool isPlayer = true;

    [SerializeField] float speed = 5f;

    [SerializeField] Rigidbody rb;

    // FixedUpdate is called at a fixed interval, suitable for physics calculations
    void FixedUpdate()
    {
        if (isPlayer)
        {
            Vector3 direction = GetInputDirection();
            MovePlayer(direction);
        }
    }

    // This method captures player input and returns a direction vector
    private Vector3 GetInputDirection()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            direction += Vector3.forward;  // Forward direction
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            direction += -Vector3.forward; // Backward direction
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction += -Vector3.right;  // Left direction
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction += Vector3.right;   // Right direction
        }

        return direction.normalized; // Ensures direction has a magnitude of 1
    }

    // Applies force to the Rigidbody to move the player
    public void MovePlayer(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            rb.velocity = direction * speed;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}
