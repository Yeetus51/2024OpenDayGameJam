using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [SerializeField] List<DoorController> doorControllers;

    [SerializeField] float doorRange = 0.5f; 



    public void Interact(PlayerController player) 
    {

        foreach (var door in doorControllers)
        {
            if((player.transform.position - door.transform.position).magnitude <= doorRange)
            {
                if (player.hasKey)
                {
                    door.OpenDoor();
                    break; 
                }
            }

        }

    }


}
