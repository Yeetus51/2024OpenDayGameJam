using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] bool open;
    [SerializeField] bool close;
    [SerializeField] ParticleSystem SmokeP;

    private void Update()
    {

        if (open)
        {
            animator.SetTrigger("Open"); 
            open = !open;
        }



        if (close)
        {
            animator.SetTrigger("Close");
            close = !close;
        }
    }

    public void OpenDoor()
    {
        open = true;
        Instantiate(SmokeP, transform.position, Quaternion.Euler(-90, 0, -50));
    }

}
