using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    [SerializeField] private Material[] materials;

    private Renderer objectRenderer;
    public int currentMaterialIndex;

    private void Start()
    {
        currentMaterialIndex = 0;
        objectRenderer = GetComponent<Renderer>();

        if (materials.Length > 0)
        {
            objectRenderer.material = materials[currentMaterialIndex];
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gate1"))
        {
            if (currentMaterialIndex == 0)
                ChangeMaterial(1);
        }
        else if (other.CompareTag("Gate2"))
        {
            if (currentMaterialIndex == 1)
                ChangeMaterial(2);
        }
        else if (other.CompareTag("Gate3"))
        {
            if (currentMaterialIndex == 2)
                ChangeMaterial(3);
        }
        else if (other.CompareTag("Gate4"))
        {
            if (currentMaterialIndex == 3)
                ChangeMaterial(4);
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
