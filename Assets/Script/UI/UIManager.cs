using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject Inventory;
    public GameObject SeedInv;
    public GameObject PlantInv;

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

    public void OpenSeedInventory()
    {

    }

    public void CloseSeedInventory()
    {

    }

    public void OpenVendorUI()
    {

    }

    public void CloseVendorInventory()
    {

    }
}
