using UnityEngine;

public class Seeds : MonoBehaviour
{
    /// <summary>
    /// Cost of the seed
    /// </summary>
    [Header("Stats", order = 1)]
    public int Cost;

    /// <summary>
    /// Name of the seed
    /// </summary>
    public string Name;

    /// <summary>
    /// How many day necessary to the seed for being grow
    /// </summary>
    public int GrowTime;

    /// <summary>
    /// Icon show in UI
    /// </summary>
    public Sprite Icon;

    /// <summary>
    /// List of sprites show in game on actual grow
    /// </summary>
    public Sprite[] GrowSprite;

    /// <summary>
    /// The plant that get when grow up
    /// </summary>
    public Plant_ScriptableObj PlantGet;

    [Header("Scriptable Object Use", order = 2)]
    public Seed_ScriptanbleObj ActSeed;

    private void Start()
    {
        Cost = ActSeed.Cost;
        Name = ActSeed.Name;
        GrowTime = ActSeed.GrowTime;
        Icon = ActSeed.Icon;
        GrowSprite = ActSeed.GrowSprite;
        PlantGet = ActSeed.PlantGet;
    }
}
