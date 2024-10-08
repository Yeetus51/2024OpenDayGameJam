using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    public Movement npcMovement;

    public bool enableNpc; 
    public bool stopNpc;

    Vector3[] directions = { new Vector3(1,0,0), new Vector3(-1, 0, 0), new Vector3(0, 1, 0), new Vector3(0, -1, 0), new Vector3(0, 0, 0)};

    Vector3 movementDirection = Vector3.zero;

    float timer;

    float minDuration = 1; 
    float maxDuration = 2;

    public GameObject mountPoint;


    public bool completedTask = false;


    [SerializeField] ParticleSystem deathBlood; 




    private void Update()
    {

        if (stopNpc)
        {
            StopNpc();
            stopNpc = !stopNpc;
        }


        if (enableNpc)
        {
            NpcMovement();
            enableNpc = !enableNpc; 
        }

        if(timer > 0)
        {
            npcMovement.MovePlayer(movementDirection);
            timer -= Time.deltaTime;
            if (timer <= 0) NpcMovement();
        }


    }

    void NpcMovement()
    {
        int rand = Random.Range(0, 5); 
        Vector3 direction = directions[rand];
        if(Random.Range(0, 2) == 0 && direction.magnitude > 0)
        {
            int xy = Random.Range(0, 2);
            direction += xy == 0 ? Vector3.up : -Vector3.up;
        }

        float duration = Random.Range(minDuration, maxDuration);

        movementDirection = direction;
        timer = duration; 


    }

    public void Kill()
    {
        deathBlood.Play();
        deathBlood.transform.parent = null;
        npcMovement.enabled = false;
        gameObject.SetActive(false); 
        

    }

    void StopNpc()
    {
        timer = 0;
        movementDirection = Vector3.zero;
    }



}
