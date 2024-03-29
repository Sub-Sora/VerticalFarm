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

    [Header("Plants Sell Info")]
    public GameObject SellInfo;

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
        GameManager.Instance.CanMove = false;

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
        GameManager.Instance.CanMove = true;

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
        ShowCursorEvent?.Invoke();
        GameManager.Instance.CanMove = false;

        // Hide Seed Inventory just in case
        SeedInv.SetActive(false);
    }

    public void ClosePlantInventory()
    {
        Inventory.SetActive(false);
        PlantInv.SetActive(false);
        HideCursorEvent?.Invoke();
        GameManager.Instance.CanMove = true;
    }

    /// <summary>
    /// Open vendor UI
    /// </summary>
    public void OpenVendorUI()
    {
        VendorUI.SetActive(true);
        ShowCursorEvent?.Invoke();
        GameManager.Instance.CanMove = false;
    }

    /// <summary>
    /// Close vendor UI
    /// </summary>
    public void CloseVendorInventory()
    {
        VendorUI.SetActive(false);
        HideCursorEvent?.Invoke();
        GameManager.Instance.CanMove = true;
    }

    public void OpenSellInfo()
    {
        SellInfo.SetActive(true);
        ShowCursorEvent?.Invoke();
    }

    public void CloseSellInfo()
    {
        SellInfo.SetActive(false);
        HideCursorEvent?.Invoke();
    }


    /// <summary>
    /// Update Gold UI
    /// </summary>
    public void UpdateGold()
    {
        Golds.text = "Golds : " + InventoryManager.Instance.Gold.ToString();
    }
}
