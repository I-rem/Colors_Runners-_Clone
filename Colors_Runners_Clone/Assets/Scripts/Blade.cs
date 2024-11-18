using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public GameObject Sword;
    Sword_Manager swordManager;
    Collider myCollider;
    Transform myTransform;

    private void Start()
    {
       swordManager = Sword.GetComponent<Sword_Manager>();
       myTransform = transform;
        //myCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {  
        if (other.CompareTag("Player") || other.CompareTag("SwordBlade"))
        {
            //Physics.IgnoreCollision(myCollider, other);
                if (gameObject.CompareTag("Blade"))
                {
                    Destroy(gameObject);
                    swordManager.AddBlade(myTransform.position); 
                }
        }
        if (other.CompareTag("Obstacle") && gameObject.CompareTag("SwordBlade"))
            Destroy(this.gameObject);
    }
}
