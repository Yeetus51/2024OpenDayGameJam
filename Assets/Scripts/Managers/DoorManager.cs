using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public List<DoorController> doorControllers;

    [SerializeField] float doorRange = 0.5f; 



    public void Interact(DoorController door, PlayerController player)
    {

        if (player.hasKey)
        {
            door.OpenDoor();
        }
    }

}
