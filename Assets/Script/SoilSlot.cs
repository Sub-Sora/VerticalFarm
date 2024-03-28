using Unity.VisualScripting;
using UnityEngine;

public class SoilSlot : MonoBehaviour
{
    /// <summary>
    /// Seed planted on the slot
    /// </summary>
    private Seed_ScriptanbleObj _seedPlanted;

    /// <summary>
    /// Verify if the slot is watered
    /// </summary>
    private bool _isWatered;

    /// <summary>
    /// Is the plant is Wilted after some days configure on the GameManager
    /// </summary>
    private bool _isWilted;

    /// <summary>
    /// When sleep, if not watered, add to verify after if is wilted
    /// </summary>
    private int _noWateredDay;

    /// <summary>
    /// Actual phase of the seed grow
    /// </summary>
    private int _actGrow;

    /// <summary>
    /// Plant seed if soil is empty
    /// </summary>
    /// <param name="seed">The seed to plant</param>
    private void PlantSeed(Seed_ScriptanbleObj seed)
    {
        _seedPlanted = seed;
    }

    /// <summary>
    /// Watered the soil if isn't already
    /// </summary>
    private void WateredSoil()
    {
        _isWatered = true;
    }

    /// <summary>
    /// Gather the soil and get the plant
    /// </summary>
    private void Gather()
    {
        InventoryManager.Instance.AddPlant(_seedPlanted.PlantGet);
        ResetSoil();
    }

    /// <summary>
    /// Cut the soil
    /// </summary>
    private void Cut()
    {
        ResetSoil();
    }

    /// <summary>
    /// Call when the player sleep
    /// </summary>
    public void DayPassed()
    {
        if (_seedPlanted != null)
        {
            if (_isWatered)
            {
                _actGrow++;
                _isWatered = false;
            }
            else
            {
                _noWateredDay++;
                if (_noWateredDay == GameManager.Instance.BeforeWilted)
                {
                    _isWilted = true;
                }
            }
        }
    }

    /// <summary>
    /// Reset the soilslot stats when being empty
    /// </summary>
    private void ResetSoil()
    {
        _seedPlanted = null;
        _isWatered = false;
        _isWilted = false;
        _noWateredDay = 0;
        _actGrow = 0;
    }

    public void Interaction()
    {
        if (_seedPlanted != null)
        {
            if (!_isWilted)
            {
                // If plant grow, then car gather it
                if (_actGrow == _seedPlanted.GrowTime)
                {
                    Gather();
                }
                // If the soil isn't watered, then can Watered it
                if (!_isWatered)
                {
                    WateredSoil();
                }
            }
            else Cut();
        }
        //else | Mettre ici l'accès à la fonction qui ouvrira la fenêtre de choix des graines, et qui la plantera avec la fonction PlantSeed
    }
}
