using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcManager : MonoBehaviour
{
    public List<NpcController> npcs;

    [SerializeField] Movement npcMovement; 





    public void Interact(NpcController npc, PlayerController player)
    {

        player.JumpToNpc(npc); 



    }






}
