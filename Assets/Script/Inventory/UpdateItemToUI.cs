using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpdateItemToUI : MonoBehaviour
{
    public GameObject UISeedPrefab;
    public GameObject UIPlantPrefab;
    public Transform UIInventorySeedVertical;
    public Transform UIInventoryPlantVertical;
    public void UpdateSeedUI()
    {

        foreach (Transform child in UIInventorySeedVertical)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < InventoryManager.Instance.SeedPossessed.Count; i++)
        {
            Seed_ScriptanbleObj seedObj = InventoryManager.Instance.SeedPossessed[i];
            GameObject seedAdded = Instantiate(UISeedPrefab, UIInventorySeedVertical);
            UISeedInventory seedComponent = seedAdded.GetComponent<UISeedInventory>();
            seedComponent.SeedStock = seedObj;
        }
    }

    public void UpdatePlantUI()
    {

        foreach (Transform child in UIInventoryPlantVertical)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < InventoryManager.Instance.PlantPossessed.Count; i++)
        {
            Plant_ScriptableObj plantObj = InventoryManager.Instance.PlantPossessed[i];
            GameObject plantAdded = Instantiate(UIPlantPrefab, UIInventoryPlantVertical);
            UIPlantInventory plantComponent = plantAdded.GetComponent<UIPlantInventory>();
            plantComponent.PlantStock = plantObj;
        }
    }
}
