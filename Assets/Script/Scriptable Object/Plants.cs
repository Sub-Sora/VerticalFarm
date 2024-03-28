using UnityEngine;

public class Plants : MonoBehaviour
{
    /// <summary>
    /// Sell of the plant
    /// </summary>
    [Header("Stats", order = 1)]
    public int Sell;

    /// <summary>
    /// Name of the plant
    /// </summary>
    public string Name;

    /// <summary>
    /// Icon show in UI
    /// </summary>
    public Sprite Icon;

    [Header("Scriptable Object Use", order = 2)]
    public Plant_ScriptableObj ActPlant;

    private void Start()
    {
        Sell = ActPlant.Sell;
        Name = ActPlant.Name;
        Icon = ActPlant.Icon;
    }
}
