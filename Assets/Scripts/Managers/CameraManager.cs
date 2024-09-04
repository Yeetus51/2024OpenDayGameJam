using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public List<Camera> cameras;



    public void Interact(Camera cam, PlayerController player)
    {
        Debug.Log("Bruh");
        if (player.hasCamAccess)
        {
            cam.KillCam(); 
        }
    }

}
