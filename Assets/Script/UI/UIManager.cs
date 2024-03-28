using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Player Inventory")]
    public GameObject Inventory;
    public GameObject SeedInv;
    public GameObject PlantInv;

    [Header("Player Golds")]
    public TextMeshProUGUI Golds;

    [Header("Vendor UI")]
    public GameObject VendorUI;

    public bool _inventoryOpen;

    public delegate void ShowCursorDelegate();
    public event ShowCursorDelegate ShowCursorEvent, HideCursorEvent;

    //Singleton
    private static UIManager _instance = null;
    private UIManager() { }
    public static UIManager Instance => _instance;
    //

    private void Awake()
    {
        //Singleton
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            _instance = this;
        }
        //
        _inventoryOpen = false;
    }

    private void Start()
    {
        Inventory.SetActive(false);
        SeedInv.SetActive(false);
        PlantInv.SetActive(false);
        Golds.text = "Golds : " + GameManager.Instance.StartGold.ToString();
    }

    /// <summary>
    /// Open UI Seed Inventory
    /// </summary>
    public void OpenSeedInventory()
    {
        Inventory.SetActive(true);
        SeedInv.SetActive(true);
        ShowCursorEvent?.Invoke();
        _inventoryOpen = true;

        // Hide Plant just in case
        PlantInv.SetActive(false);
    }

    /// <summary>
    /// Hide UI Seed Inventory
    /// </summary>
    public void CloseSeedInventory()
    {
        SeedInv.SetActive(false);
        Inventory.SetActive(false);
        HideCursorEvent?.Invoke();
        _inventoryOpen = false;

        // Just in case
        if (GameManager.Instance.SoilAct != null) GameManager.Instance.SoilAct = null;
    }

    /// <summary>
    /// Show UI Plant Inventory
    /// </summary>
    public void OpenPlantInventory()
    {
        Inventory.SetActive(true);
        PlantInv.SetActive(true);

        // Hide Seed Inventory just in case
        SeedInv.SetActive(false);
    }

    /// <summary>
    /// Open vendor UI
    /// </summary>
    public void OpenVendorUI()
    {
        VendorUI.SetActive(true);
    }

    /// <summary>
    /// Close vendor UI
    /// </summary>
    public void CloseVendorInventory()
    {
        VendorUI.SetActive(false);
    }

    /// <summary>
    /// Update Gold UI
    /// </summary>
    public void UpdateGold()
    {
        Golds.text = "Golds : " + InventoryManager.Instance.Gold.ToString();
    }
}
