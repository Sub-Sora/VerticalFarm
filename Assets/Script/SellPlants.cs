using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellPlants : MonoBehaviour
{
    public void Interaction()
    {
        InventoryManager InvManager = InventoryManager.Instance;
        // Vérifie si il y'a au moins une plante dans l'inventaire
        if (InvManager.PlantPossessed.Count > 0)
        {
            for (int i = 0; i < InvManager.PlantPossessed.Count; i++)
            {
                GameManager.Instance.GoldReceived = GameManager.Instance.GoldReceived + InvManager.PlantPossessed[i].Sell;
            }
            InvManager.RemovePlant();
        }
        
    }
}
