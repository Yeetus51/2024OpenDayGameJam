using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public List<DoorController> doorControllers;

    [SerializeField] float doorRange = 0.5f; 



    public void Interact(DoorController door, PlayerController player)
    {

        if (player.keys > 0)
        {
            door.OpenDoor();
            player.keys--; 
        }
    }

}
