using UnityEngine;

public class Vendor : MonoBehaviour
{
    /// <summary>
    /// Script needed to interact with
    /// </summary>
    Interact _interact;

    public Transform _vertical;
    public GameObject _seedVendorPrefab;

    private void Start()
    {
        _interact = GetComponent<Interact>();
        _interact.InteractEvent += Interaction;

        foreach (Seed_ScriptanbleObj seeds in GameManager.Instance.ListOfSeeds)
        {
            GameObject seedAdded = Instantiate(_seedVendorPrefab, _vertical);
            UIVendor uiVendor = seedAdded.GetComponent<UIVendor>();
            uiVendor.SeedStock = seeds;
        }
    }
    public void Interaction()
    {
        UIManager.Instance.OpenVendorUI();
    }
}
