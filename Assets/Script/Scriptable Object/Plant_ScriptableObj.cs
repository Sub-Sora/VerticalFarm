using UnityEngine;

[CreateAssetMenu(fileName = "NewPlant", menuName = "Botanical/New Plant", order = 2)]
public class Plant_ScriptableObj : ScriptableObject
{
    /// <summary>
    /// Sell of the plant
    /// </summary>
    public int Sell;

    /// <summary>
    /// Name of the plant
    /// </summary>
    public string Name;

    /// <summary>
    /// Icon show in UI
    /// </summary>
    public Sprite Icon;
}
