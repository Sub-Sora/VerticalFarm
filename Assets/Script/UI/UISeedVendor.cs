using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIVendor : MonoBehaviour
{
    public Seed_ScriptanbleObj SeedStock;
    [SerializeField] private TextMeshProUGUI SeedName;
    [SerializeField] private TextMeshProUGUI SeedPrice;
    [SerializeField] private Image Logo;

    private void Start()
    {
        SeedName.text = SeedStock.Name;
        SeedPrice.text = "Price : " + SeedStock.Cost;
        if (SeedStock.Icon != null) Logo.sprite = SeedStock.Icon;
    }

    public void BuyItem()
    {
        if (InventoryManager.Instance.Gold >= SeedStock.Cost)
        {
            InventoryManager.Instance.Gold = InventoryManager.Instance.Gold - SeedStock.Cost;
            InventoryManager.Instance.AddSeeds(SeedStock);
            UIManager.Instance.UpdateGold();
        }
    }
}
