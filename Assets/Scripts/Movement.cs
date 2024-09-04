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






    }

    public void MovePlayer(Vector3 direction)
    {
        rb.AddForce(direction.normalized * speed * Time.deltaTime, ForceMode.VelocityChange);
    }


    public void ToggleMovement(bool state)
    {
        rb.isKinematic = !state; 

    }


}
