using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public GameObject Sword;
    Sword_Manager swordManager;
    Collider myCollider;
    Transform myTransform;
    MaterialChanger materialChanger1;
    MaterialChanger materialChanger2;
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
            materialChanger1 = other.GetComponent<MaterialChanger>();
            materialChanger2 = gameObject.GetComponent<MaterialChanger>();
            //Physics.IgnoreCollision(myCollider, other);
                if (gameObject.CompareTag("Blade") && materialChanger1.correct_color == materialChanger2.correct_color)
                {
                    swordManager.AddBlade(myTransform.position); 
                    Destroy(gameObject);
                    
                }
        }
        if (other.CompareTag("Obstacle") && gameObject.CompareTag("SwordBlade"))
            Destroy(this.gameObject);
    }
}
