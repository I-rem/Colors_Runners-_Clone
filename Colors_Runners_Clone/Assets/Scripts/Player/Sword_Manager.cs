using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Manager : MonoBehaviour
{
    public GameObject bladePrefab;
    public GameObject handle; 
    public List<GameObject> swordParts = new List<GameObject>(); 
    public float bladeDistance = 2.0f; 

    private void Start()
    {
        swordParts.Add(handle);
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Blade"))
        {
            //AddBlade(other.transform.position);
            //Destroy(other);
        }
    }*/
    public void AddBlade(Vector3 position)
    {
        GameObject newBlade = Instantiate(bladePrefab, position, Quaternion.identity);
        swordParts.Add(newBlade);
        newBlade.transform.SetParent(swordParts[swordParts.Count - 2].transform);
        
        newBlade.transform.localPosition = new Vector3(0, 0, bladeDistance);
        
        
    }
}
