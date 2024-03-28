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

    public void PlantSeed()
    {
        if (GameManager.Instance.SoilAct != null)
        {
            SoilSlot actSoil = GameManager.Instance.SoilAct;
            actSoil.PlantSeed(SeedStock);
            InventoryManager.Instance.RemoveSeed(SeedStock);
            UIManager.Instance.CloseSeedInventory();
            GameManager.Instance.SoilAct = null;
        }
    }
}
