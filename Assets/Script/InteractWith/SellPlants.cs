using UnityEngine;

public class SellPlants : MonoBehaviour
{
    /// <summary>
    /// Script needed to interact with
    /// </summary>
    private Interact _interact;
    [SerializeField] private GameObject _canvaAnim;

    private void Start()
    {
        _interact = GetComponent<Interact>();
        _interact.InteractEvent += Interaction;
    }

    /// <summary>
    /// Sell all plant of the player inventory
    /// </summary>
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
            _canvaAnim.SetActive(true);
        }
    }
}
