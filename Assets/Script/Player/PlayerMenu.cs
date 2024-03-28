using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenu : MonoBehaviour
{

    public void ButtonInventoryPress()
    {
        if (UIManager.Instance._inventoryOpen == false)
        {
            UIManager.Instance.OpenSeedInventory();
        }
        else
        {
            UIManager.Instance.CloseSeedInventory();
        }
    }
}
