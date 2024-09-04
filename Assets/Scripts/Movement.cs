using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] bool isPlayer; 

    [SerializeField] float speed = 1;

    [SerializeField] Rigidbody rb; 


    // Update is called once per frame
    void Update()
    {

        Vector3 direction = Vector3.zero;

        if (isPlayer)
        {
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                direction += -Vector3.forward;
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                direction += Vector3.forward;
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                direction += Vector3.right;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                direction += -Vector3.right; 
            }
        }

        MovePlayer(direction); 

    }

    public void MovePlayer(Vector3 direction)
    {
        rb.AddForce(direction.normalized * speed * Time.deltaTime, ForceMode.VelocityChange);
    }


}
