using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HandleBonus : MonoBehaviour
{
    public float speed;
    
    private void Start()
    {
        speed = gameObject.GetComponent<PlayerMovement>().speed;
    }
     

    public float damage = 0;

    public void ApplyBonus(float bonus, int type)
    {
        if (type == 0)
        {
            speed += (speed * bonus);
        }
        else if (type == 1)
        {
            damage += bonus;
        }
            
    }
}

