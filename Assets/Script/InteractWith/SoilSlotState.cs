using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilSlotState : MonoBehaviour
{

    [SerializeField] private GameObject _goodIcon;
    [SerializeField] private GameObject _plantSeedIcon;
    [SerializeField] private GameObject _WaterIcon;
    [SerializeField] private GameObject _plantGrowIcon;
    [SerializeField] private GameObject _seedDiedIcon;


    public void GoodState()
    {
        // Show the good icon for current state
        _goodIcon.SetActive(true);

        // Hide everything else in case
        _plantSeedIcon.SetActive(false);
        _WaterIcon.SetActive(false);
        _plantGrowIcon.SetActive(false);
        _seedDiedIcon.SetActive(false);
    }

    public void PlantSeedState()
    {
        // Show the good icon for current state
        _plantSeedIcon.SetActive(true);

        // Hide everything else in case
        _goodIcon.SetActive(false);
        _WaterIcon.SetActive(false);
        _plantGrowIcon.SetActive(false);
        _seedDiedIcon.SetActive(false);
    }

    public void WaterState()
    {
        // Show the good icon for current state
        _WaterIcon.SetActive(true);

        // Hide everything else in case
        _goodIcon.SetActive(false);
        _plantSeedIcon.SetActive(false);
        _plantGrowIcon.SetActive(false);
        _seedDiedIcon.SetActive(false);
    }

    public void PlantGrowState()
    {
        // Show the good icon for current state
        _plantGrowIcon.SetActive(true);

        // Hide everything else in case
        _goodIcon.SetActive(false);
        _plantSeedIcon.SetActive(false);
        _WaterIcon.SetActive(false);
        _seedDiedIcon.SetActive(false);
    }

    public void SeedDiedState()
    {
        // Show the good icon for current state
        _seedDiedIcon.SetActive(true);

        // Hide everything else in case
        _goodIcon.SetActive(false);
        _plantSeedIcon.SetActive(false);
        _WaterIcon.SetActive(false);
        _plantGrowIcon.SetActive(false);
    }
}
