using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] bool isPlayer; 

    [SerializeField] float speed = 1;

    [SerializeField] Rigidbody rb;

    Vector3 previousPos = Vector3.zero; 

    void Update()
    {






    }

    private void FixedUpdate()
    {

    }

    public void MovePlayer(Vector3 direction)
    {

        float diff = direction.x;
        if (diff > 0 && Mathf.Abs(diff) > 0.01f)
        {
            transform.localScale = new Vector3(0.1f, transform.localScale.y, transform.localScale.z);
        }
        else if (Mathf.Abs(diff) > 0.01f)
        {
            transform.localScale = new Vector3(-0.1f, transform.localScale.y, transform.localScale.z);
        }


        previousPos = transform.position;


        rb.AddForce(direction.normalized * speed * Time.deltaTime, ForceMode.VelocityChange);
    }
    public void ToggleMovement(bool state)
    {
        rb.isKinematic = !state; 

    }


}
