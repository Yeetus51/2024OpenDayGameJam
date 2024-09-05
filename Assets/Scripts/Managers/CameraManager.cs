using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public List<Camera> cameras;



    public void Interact(Camera cam, PlayerController player)
    {
        if (player.hasCamAccess)
        {
            player.targetNpc.completedTask = true; 
            cam.KillCam(); 
        }
    }

}
