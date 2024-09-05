using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] bool isPlayer; 

    [SerializeField] float speed = 1;

    [SerializeField] Rigidbody rb;

    [SerializeField] SpriteRenderer sprite;

    [SerializeField] Animator animator;

    Vector3 previousPos = Vector3.zero; 

    void Update()
    {






    }

    private void FixedUpdate()
    {

    }

    public void MovePlayer(Vector3 direction, bool running = false)
    {

        if (direction.magnitude > 0)
        {
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }

        float diff = direction.x;
        if (diff > 0 && Mathf.Abs(diff) > 0.01f)
        {
            sprite.flipX = false; 
        }
        else if (Mathf.Abs(diff) > 0.01f)
        {
            sprite.flipX = true;
        }


        previousPos = transform.position;


        rb.AddForce(direction.normalized * speed * (running? 1.5f:1) * Time.deltaTime, ForceMode.VelocityChange);
    }
    public void ToggleMovement(bool state)
    {
        rb.isKinematic = !state; 

    }


}
