using UnityEngine;

public class SoilSlot : MonoBehaviour
{
    /// <summary>
    /// Script needed to interact with
    /// </summary>
    Interact _interact;

    /// <summary>
    /// Seed planted on the slot
    /// </summary>
    private Seeds _seed;

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

    private void Start()
    {
        _interact = GetComponent<Interact>();
        _interact.InteractEvent += Interaction;
        _seed = GetComponent<Seeds>();
        GameManager.Instance.SleepEvent += DayPassed;
    }

    /// <summary>
    /// Plant seed if soil is empty
    /// </summary>
    /// <param name="seed">The seed to plant</param>
    public void PlantSeed(Seed_ScriptanbleObj seed)
    {
        _seed.ActSeed = seed;
        _seed.UpdateSeed();
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
        InventoryManager.Instance.AddPlant(_seed.PlantGet);
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
        if (_seed.ActSeed != null && _actGrow < _seed.GrowTime)
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
        _seed.ActSeed = null;
        _isWatered = false;
        _isWilted = false;
        _noWateredDay = 0;
        _actGrow = 0;
    }

    public void Interaction()
    {
        // Verify if a seed was planted
        if (_seed.ActSeed != null)
        {
            // Verify if a seed wasn't Wilted
            if (!_isWilted)
            {
                // If plant grow, then car gather it
                if (_actGrow == _seed.GrowTime)
                {
                    Gather();
                }
                // If the soil isn't watered, then can Watered it
                if (!_isWatered)
                {
                    WateredSoil();
                }
            }
            // Cut the Seed if Wilted
            else Cut();
        }
        // Plant a seed if no seed already planted
        else
        {
            GameManager.Instance.SoilAct = this;
            UIManager.Instance.OpenSeedInventory();
        }
    }
}
