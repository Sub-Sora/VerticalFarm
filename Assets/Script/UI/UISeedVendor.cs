using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIVendor : MonoBehaviour
{
    public Seed_ScriptanbleObj SeedStock;
    [SerializeField] private TextMeshProUGUI _seedName;
    [SerializeField] private TextMeshProUGUI _seedPrice;
    [SerializeField] private Image _logo;

    private void Start()
    {
        _seedName.text = SeedStock.Name;
        _seedPrice.text = "Price : " + SeedStock.Cost;
        if (SeedStock.Icon != null) _logo.sprite = SeedStock.Icon;
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
