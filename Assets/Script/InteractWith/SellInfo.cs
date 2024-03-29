using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class SellInfo : MonoBehaviour
{
    /// <summary>
    /// Script needed to interact with
    /// </summary>
    private Interact _interact;

    public Transform _vertical;
    public GameObject _plantInfoPrefab;

    private void Start()
    {
        _interact = GetComponent<Interact>();
        _interact.InteractEvent += ShowSign;

        foreach (Plant_ScriptableObj plants in GameManager.Instance.ListOfPlants)
        {
            GameObject plantAdded = Instantiate(_plantInfoPrefab, _vertical);
            UIPlantSellInfo plantsUI = plantAdded.GetComponent<UIPlantSellInfo>();
            plantsUI.PlantInfo = plants;
        }
    }
    public void ShowSign()
    {
        UIManager.Instance.OpenSellInfo();
    }
}
