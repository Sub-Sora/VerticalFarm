using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISeedInventory : MonoBehaviour
{
    public Seed_ScriptanbleObj SeedStock;
    private TextMeshProUGUI SeedName;
    private Image Logo;

    private void Start()
    {
        SeedName = GetComponentInChildren<TextMeshProUGUI>();
        Logo = GetComponentInChildren<Image>();
        SeedName.text = SeedStock.Name;
        if (SeedStock.Icon != null) Logo.sprite = SeedStock.Icon;
    }
}
