using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InteractionManager interactionManager;

    public bool hasKey; 



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            interactionManager.Interact(this); 
        }
    }

}
