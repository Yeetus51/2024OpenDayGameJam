using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] DoorManager doorManager; 


    public void Interact(PlayerController player)
    {
        doorManager.Interact(player); 
    }









}
