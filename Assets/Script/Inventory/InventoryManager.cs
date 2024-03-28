using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    UpdateItemToUI _updateItemToUI;

    /// <summary>
    /// Seed on the player inventory
    /// </summary>
    public List<Seed_ScriptanbleObj> SeedPossessed = new List<Seed_ScriptanbleObj>();

    /// <summary>
    /// Plant on the player inventory
    /// </summary>
    public List<Plant_ScriptableObj> PlantPossessed = new List<Plant_ScriptableObj> ();

    /// <summary>
    /// Gold of the player
    /// </summary>
    public int Gold;

    //Singleton
    private static InventoryManager _instance = null;
    private InventoryManager() { }
    public static InventoryManager Instance => _instance;
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
        _updateItemToUI = GetComponent<UpdateItemToUI>();
    }

    private void Start()
    {
        Gold = GameManager.Instance.StartGold;
    }

    /// <summary>
    /// Add seed to the inventory then sort it
    /// </summary>
    /// <param name="SeedAdd"> the seed to add</param>
    public void AddSeeds(Seed_ScriptanbleObj SeedAdd)
    {
        SeedPossessed.Add(SeedAdd);
        SortInventory();
        _updateItemToUI.UpdateSeedUI();
    }

    /// <summary>
    /// Add plant to the inventory then sort it
    /// </summary>
    /// <param name="PlantAdd"> the plant to add</param>
    public void AddPlant(Plant_ScriptableObj PlantAdd)
    {
        PlantPossessed.Add(PlantAdd);
        SortInventory();
        _updateItemToUI.UpdatePlantUI();
    }

    /// <summary>
    /// Will remove a seed of the list after use it
    /// </summary>
    /// <param name="SeedRemove">The seed to remove</param>
    public void RemoveSeed(Seed_ScriptanbleObj SeedRemove)
    {
        for (int i = 0; i < SeedPossessed.Count; ++i)
        {
            var seed = SeedPossessed[i];
            if (seed.name == SeedRemove.name)
            {
                SeedPossessed.Remove(seed);
                break;
            }
        }
        _updateItemToUI.UpdateSeedUI();
    }

    /// <summary>
    /// Will remove the plant that we'll be sell
    /// </summary>
    /// <param name="PlantRemove">The plant to remove</param>
    public void RemovePlant()
    {
        PlantPossessed.Clear();
        _updateItemToUI.UpdatePlantUI();
    }

    /// <summary>
    /// Sort the inventory
    /// </summary>
    private void SortInventory()
    {
        if (SeedPossessed != null) SeedPossessed = SeedPossessed.OrderBy(s => s.Name).ToList();
        if (PlantPossessed != null) PlantPossessed = PlantPossessed.OrderBy(p => p.Name).ToList();
    }
}
