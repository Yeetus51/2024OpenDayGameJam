using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcManager : MonoBehaviour
{
    public List<NpcController> npcs;


    public void Interact(NpcController npc, PlayerController player)
    {

        player.JumpToNpc(npc); 

    }
    
    public void RemoveNpc(NpcController npc)
    {
        npcs.Remove(npc);
    }





}
