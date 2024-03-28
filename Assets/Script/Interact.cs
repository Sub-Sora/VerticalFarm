using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] private SoilSlot _soilInteract;
    [SerializeField] private Vendor _vendorInteract;
    [SerializeField] private SellPlants _sellInteract;
    [SerializeField] private Sleep _sleepInteract;
    public void Interacted()
    {
        if (_soilInteract != null) _soilInteract.Interaction();
        if (_vendorInteract != null) _vendorInteract.Interaction();
        if (_sellInteract != null) _sellInteract.Interaction();
        if (_sleepInteract != null) _sleepInteract.Interaction();
    }
}
