using UnityEngine;

[CreateAssetMenu(fileName = "NewSeed", menuName = "Botanical/New Seed", order = 1)]
public class Seed_ScriptanbleObj : ScriptableObject
{
    /// <summary>
    /// Cost of the seed
    /// </summary>
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
}
