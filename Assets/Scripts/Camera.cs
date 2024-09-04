using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Camera : MonoBehaviour
{

    [SerializeField] float angleChange;
    [SerializeField] float periodDuration;


    [SerializeField] float FOV;
    [SerializeField] int resolution;
    [SerializeField] float DOF;
    [SerializeField] float rotation;

    [SerializeField] Light2D light; 


    [SerializeField] bool active; 


    float timer;
    int mult = 1;

    public void KillCam()
    {
        active = false;
        light.intensity = 0; 
    }

    private void Update()
    {
        if (!active) return; 


        timer += Time.deltaTime * mult;
        if (timer > periodDuration) mult = -1;
        else if (timer < periodDuration * mult) mult = 1;

        transform.Rotate(Vector3.forward, angleChange * Time.deltaTime * (timer > 0? 1 : -1));


        for (int i = 0; i < resolution; i++)
        {
            Vector3 direction = -transform.up;
            direction = Quaternion.Euler(0, 0, -FOV / resolution + FOV * i + rotation) * direction;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction, out hit, DOF)) 
            {
                if(hit.transform.tag == "Player")
                {
                    Debug.Log("Game OVER!"); 
                }
            }

            Debug.DrawRay(transform.position, direction * DOF, Color.red);

        }
    }
}
