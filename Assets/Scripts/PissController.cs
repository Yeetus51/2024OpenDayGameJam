using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PissController : MonoBehaviour
{

    int reductions = 5; 

    public bool RecudePiss(float rate)
    {
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
