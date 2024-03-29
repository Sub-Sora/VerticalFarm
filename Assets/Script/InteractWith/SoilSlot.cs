using UnityEngine;

public class SoilSlot : MonoBehaviour
{
    /// <summary>
    /// Script needed to interact with
    /// </summary>
    private Interact _interact;

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

    /// <summary>
    /// The seed Object to view when seed plant
    /// </summary>
    [SerializeField] private GameObject _seedPlanted;

    /// <summary>
    /// The seed object when the seed was wilted
    /// </summary>
    [SerializeField] private GameObject _seedWilted;

    /// <summary>
    /// The plant object when the seed was grow
    /// </summary>
    [SerializeField] private GameObject _plantGrow;

    private SoilSlotState _soilStateIcon;

    private void Start()
    {
        _interact = GetComponent<Interact>();
        _soilStateIcon = GetComponent<SoilSlotState>();
        _interact.InteractEvent += Interaction;
        _seed = GetComponent<Seeds>();
        ResetSoil();
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
        _seedPlanted.SetActive(true);
        _soilStateIcon.WaterState();
    }

    /// <summary>
    /// Watered the soil if isn't already
    /// </summary>
    private void WateredSoil()
    {
        _isWatered = true;
        _soilStateIcon.GoodState();
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
                _soilStateIcon.WaterState();
                if (_actGrow >= _seed.GrowTime)
                {
                    _seedPlanted.SetActive(false);
                    _plantGrow.SetActive(true);
                    _soilStateIcon.PlantGrowState();
                }
            }
            else
            {
                _noWateredDay++;
                if (_noWateredDay == GameManager.Instance.BeforeWilted)
                {
                    _isWilted = true;
                    _seedPlanted.SetActive(false);
                    _seedWilted.SetActive(true);
                    _soilStateIcon.SeedDiedState();
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
        _seedPlanted.SetActive(false);
        _seedWilted.SetActive(false);
        _plantGrow.SetActive(false);
        _soilStateIcon.PlantSeedState();
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
                else if (!_isWatered)
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
