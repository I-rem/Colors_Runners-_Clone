using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    [SerializeField] private Material[] materials;

    public SkinnedMeshRenderer objectRenderer;

    public int currentMaterialIndex;

    private void Start()
    {
        currentMaterialIndex = 0;
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

    private void ChangeMaterial(int materialIndex)
    {
        if (materialIndex >= 0 && materialIndex < materials.Length)
        {
            objectRenderer.material = materials[materialIndex];
            
            currentMaterialIndex = materialIndex;
        }
    }
}
