using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gate : MonoBehaviour
{
    public GameObject canvas;
    LevelManager levelManager;

    public int bonusIncreaseRate = 1;
    public float bonusMulitplyRate = 1f;
    public float currentSpeed = 1;
    public float currentDamage = 0;
    public int gateType; // 0: Speed 1: Damage
    
    private string[] gates = { "Speed", "Damage" };
    private string[] speedNames = {"Slow", "Little", "Fast", "Thunder", "Lightning", "Flash", "Shadow", "Invincible"};
    private string[] damageNames = {"Pick", "Knife", "Sword", "Calibur","Slayer", "Monster", "Destroyer", "God"};
    HandleBonus handleBonus;
    public GameObject player;

    public TextMeshPro textMeshPro;
    public TextMeshPro _name;
    int nameIndex = 0;
    private void Start()
    {
        levelManager = canvas.GetComponent<LevelManager>();
        if (gateType == 0)
            _name.text = speedNames[nameIndex];
        else
            _name.text = damageNames[nameIndex];
        handleBonus = player.GetComponent<HandleBonus>();
        if (gateType == 0)
            textMeshPro.text = $"<color=blue>{gates[gateType]}" + $" <color=blue>\n{currentSpeed}</color>";
        else
            textMeshPro.text = $"<color=red>{gates[gateType]}" + $"<color=red>\n{currentDamage}</color>";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SwordBlade"))
        {
            
            if (other && gateType == 0 && other.GetComponent<MaterialChanger>().currentMaterialIndex == 4)
            {
                handleBonus.ApplyBonus(bonusMulitplyRate, gateType);
                currentSpeed += (currentSpeed*bonusMulitplyRate);
                textMeshPro.text = $"<color=blue>{gates[gateType]}" + $" <color=blue>\n{currentSpeed}</color>";
                nameIndex++;
                _name.text = speedNames[nameIndex];
            }
            else if (other && gateType == 1 && other.GetComponent<MaterialChanger>().currentMaterialIndex == 4)
            {
                handleBonus.ApplyBonus(bonusIncreaseRate, gateType);
                currentDamage += bonusIncreaseRate;
                textMeshPro.text = $"<color=red>{gates[gateType]}" + $"<color=red>\n{currentDamage}</color>";
                nameIndex++;
                _name.text = damageNames[nameIndex];
            }
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            levelManager.FinishLevel();
        }
            

    }
}
