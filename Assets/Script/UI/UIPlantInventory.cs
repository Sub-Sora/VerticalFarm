using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPlantInventory : MonoBehaviour
{
    public Plant_ScriptableObj PlantStock;
    private TextMeshProUGUI PlantName;
    private Image Logo;

    private void Start()
    {
        PlantName = GetComponentInChildren<TextMeshProUGUI>();
        Logo = GetComponentInChildren<Image>();
        PlantName.text = PlantStock.Name;
        if (PlantStock.Icon != null) Logo.sprite = PlantStock.Icon;
    }
}
