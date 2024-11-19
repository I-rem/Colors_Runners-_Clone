using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    [SerializeField] private Material[] materials;

    public SkinnedMeshRenderer objectRenderer;

    public int currentMaterialIndex = 0;

    int correct_color = 0;

    private void Start()
    {
       // currentMaterialIndex = 0;
      //  objectRenderer = GetComponent<SkinnedMeshRenderer>();
       
        if (materials.Length > 0)
        {
            objectRenderer.material = materials[currentMaterialIndex];
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Gate":
                Set_Correct_Color(other);
                break;
            case "Red":
                ChangeMaterial(1);
                break;
            case "Orange":
                ChangeMaterial(2);
                break;
            case "Blue":
                ChangeMaterial(3);
                break;
            case "Green":
                ChangeMaterial(4);
                break;
            default:
                break;
        }
    }

    private void Set_Correct_Color(Collider gate)
    {
        switch (gate.tag)
        {
            case "Red":
                correct_color = 1;
                break;
            case "Orange":
                correct_color = 2;
                break;
            case "Blue":
                correct_color = 3;
                break;
            case "Green":
                correct_color = 4;
                break;
            default:
                break;
        }
    }

    private void ChangeMaterial(int materialIndex)
    {
        if (materialIndex >= 0 && materialIndex < materials.Length)
        {
            if (materialIndex == correct_color)
            {
                objectRenderer.material = materials[materialIndex];
                currentMaterialIndex = materialIndex;
            }
            else
            {
                Destroy(this.gameObject);
            }
            
        }
    }
}
