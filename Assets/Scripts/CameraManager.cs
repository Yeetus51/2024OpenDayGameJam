using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public List<Camera> cameras;



    public void Interact(Camera door, PlayerController player)
    {
        if (player.hasCamAccess)
        {
            // Disable cam 
        }
    }

}
