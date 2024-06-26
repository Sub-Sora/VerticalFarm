﻿using UnityEngine;

public class UpdateItemToUI : MonoBehaviour
{
    [Header ("Seed UI")]
    public GameObject UISeedPrefab;
    public Transform UIInventorySeedVertical;
    [Header ("Plant UI")]
    public GameObject UIPlantPrefab;
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
