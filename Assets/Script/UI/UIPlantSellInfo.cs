using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIPlantSellInfo : MonoBehaviour
{
    public Plant_ScriptableObj PlantInfo;
    [SerializeField] private TextMeshProUGUI _plantName;
    [SerializeField] private TextMeshProUGUI _plantPrice;
    [SerializeField] private Image _logo;

    private void Start()
    {
        _plantName.text = PlantInfo.Name;
        _plantPrice.text = "Sell price : " + PlantInfo.Sell;
        if (PlantInfo.Icon != null) _logo.sprite = PlantInfo.Icon;
    }
}
