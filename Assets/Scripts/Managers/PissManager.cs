using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PissManager : MonoBehaviour
{
    public List<PissController> pisses;

    [SerializeField] float pissReductionRate; 


    public void Interact(PissController piss, PlayerController player)
    {
        if (player.canCleanPiss)
        {
            if (piss.RecudePiss(pissReductionRate))
            {
                pisses.Remove(piss); 
            }
        }
        

    }
}
