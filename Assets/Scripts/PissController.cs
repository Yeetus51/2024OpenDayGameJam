using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PissController : MonoBehaviour
{
    [SerializeField] ParticleSystem particleSystem; 
    int reductions = 5;
    [SerializeField] AudioSource PissSound;

    public bool RecudePiss(float rate)
    {
        particleSystem.Play();
        PissSound.Play();
        reductions--;
        if(reductions == 0)
        {
            Destroy(gameObject);
            return true; 
        }
        transform.localScale *= rate;

        return false; 
    }

}
