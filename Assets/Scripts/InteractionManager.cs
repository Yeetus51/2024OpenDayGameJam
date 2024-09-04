using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] DoorManager doorManager;
    [SerializeField] NpcManager npcManager;
    [SerializeField] CameraManager cameraManager; 


    [SerializeField] float interactionRange = 0.5f;


    
    public void InteractNpc(PlayerController player)
    {
        if (player.isPossessingNpc())
        {
            player.DismountNpc(); 
            return; 
        }




        float closestNpcDist = float.MaxValue;
        NpcController closestNpc = null;

        foreach (var npc in npcManager.npcs)
        {
            float dist = (player.transform.position - npc.transform.position).magnitude;
            if (dist < closestNpcDist)
            {
                closestNpcDist = dist;
                closestNpc = npc;
            }
        }
        if (closestNpcDist <= interactionRange)
        {
            npcManager.Interact(closestNpc, player);
        }

    }

    public void Interact(PlayerController player)
    {

        float closestDoorDist = float.MaxValue;
        float closestCamDist = float.MaxValue;
        DoorController closestDoor = null; 
        Camera closestCam = null;

        foreach (var door in doorManager.doorControllers)
        {
            float dist = (player.transform.position - door.transform.position).magnitude;
            if (dist < closestDoorDist) 
            {
                closestDoorDist = dist;
                closestDoor = door; 
            }
        }
        foreach (var cam in cameraManager.cameras)
        {
            float dist = (player.transform.position - cam.transform.position).magnitude;
            if (dist < closestCamDist)
            {
                closestCamDist = dist;
                closestCam = cam;
            }
        }

        if (closestCamDist < closestDoorDist && closestCamDist <= interactionRange)
        {
            cameraManager.Interact(closestCam, player); 
        } else if (closestDoorDist <= interactionRange)
        {
            doorManager.Interact(closestDoor, player);
        }



    }


}
