using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Movement playerMovement;
    [SerializeField] InteractionManager interactionManager;

    [SerializeField] Animator animator; 

    bool canMoveSelf = true;
    bool canMoveNpc = true;

    public bool hasKey = false;
    public bool hasCamAccess = false;
    public bool canCleanPiss = false;

    NpcController targetNpc;
    bool jumpingToNpc = false;
    [SerializeField] float jumpSpeed;

    [SerializeField] float minDistanceToNpc = 0.1f;

    [SerializeField] BoxCollider boxCollider;


    bool isDismounting = false;
    Vector3 dismountingPosition; 






    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            interactionManager.InteractNpc(this); 
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            interactionManager.Interact(this);
        }


        Vector3 direction = Vector3.zero;

        if (canMoveSelf || canMoveNpc)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                direction += Vector3.up;
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                direction += -Vector3.up;
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                direction += -Vector3.right;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                direction += Vector3.right;
            }

            if (canMoveSelf)
            {
                if(direction.magnitude > 0)
                {
                    playerMovement.MovePlayer(direction);
                    animator.SetBool("Walking", true);
                }
                else
                {
                    animator.SetBool("Walking", false);
                }
            }
            else if (targetNpc) targetNpc.npcMovement.MovePlayer(direction); 
                 
        }
    }


    public void JumpToNpc(NpcController npc)
    {
        targetNpc = npc;
        jumpingToNpc = true;
        playerMovement.ToggleMovement(false);
        canMoveSelf = false; 
        boxCollider.isTrigger = true; 
    }
    public void DismountNpc()
    {


        dismountingPosition =  CheckArea() + transform.position;
        isDismounting = true;
        canMoveNpc = false;


    }

    Vector3 CheckArea()
    {
        float maxDistance = 1.5f; 
        Vector3 direction = new Vector3(1,0,0);


        for (int i = 0; i < 4; i++)
        {
            direction = Quaternion.Euler(0, 0, 90 * i) * direction;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction, out hit, maxDistance)) { }
            else
            {
                return direction;
            }
            Debug.DrawRay(transform.position, direction * maxDistance, Color.red);

        }

        return Vector3.zero; 
    }


    private void FixedUpdate()
    {

        if (jumpingToNpc)
        {
            Vector3 direction = (targetNpc.transform.position - transform.position);
            float distance = direction.magnitude;
            transform.position = transform.position + direction.normalized * jumpSpeed; 

            if(distance < minDistanceToNpc)
            {
                jumpingToNpc = false;
                transform.position = targetNpc.transform.position;
                transform.SetParent(targetNpc.transform, true);

                targetNpc.stopNpc = true;
                canMoveNpc = true;
                float xScale = targetNpc.transform.localScale.x > 0 ? 1 : -1;
                transform.localScale = new Vector3(xScale, 1, 1); 
                tag = "NpcPlayer";

                if (targetNpc.tag == "Guard")
                {
                    hasKey = true;
                }

                if (targetNpc.tag == "Engineer")
                {
                    hasCamAccess = true;
                }
                if (targetNpc.tag == "Cleaner")
                {
                    canCleanPiss = true;
                }
            }
        }

        if (isDismounting)
        {
            Vector3 direction = (dismountingPosition - transform.position);
            float distance = direction.magnitude;
            transform.position = transform.position + direction.normalized * jumpSpeed;

            if (distance < minDistanceToNpc)
            {
                isDismounting = false;
                transform.parent = null;

                playerMovement.ToggleMovement(true);
                canMoveSelf = true; 
                boxCollider.isTrigger = false;
                targetNpc.enableNpc = true;
                tag = "Player";
                if (targetNpc.tag == "Guard")
                {
                    hasKey = false;
                }
                if (targetNpc.tag == "Engineer")
                {
                    hasCamAccess = false;
                }
                if (targetNpc.tag == "Cleaner")
                {
                    canCleanPiss = false;
                }

                targetNpc = null;
            }
        }
    }

    public bool isPossessingNpc()
    {
        return targetNpc ? true : false; 
    }

}
