using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// List of all seeds needed for the merchant
    /// </summary>
    public Seed_ScriptanbleObj[] ListOfSeeds;

    /// <summary>
    /// List of all plants needed for the sign of sells
    /// </summary>
    public Plant_ScriptableObj[] ListOfPlants;

    /// <summary>
    /// How many day necessary before a seed can be wilted withour be watered
    /// </summary>
    public int BeforeWilted;

    /// <summary>
    /// How Many gold you will receive at the end of the day
    /// </summary>
    public int GoldReceived;

    /// <summary>
    /// How many gold the player start with
    /// </summary>
    public int StartGold;

    /// <summary>
    /// Actual SoilSlot Interacted
    /// </summary>
    public SoilSlot SoilAct;

    public bool CanMove;

    public delegate void SleepDelegate();
    public SleepDelegate SleepEvent;

    //Singleton
    private static GameManager _instance = null;
    private GameManager() { }
    public static GameManager Instance => _instance;
    //

    private void Awake()
    {
        //Singleton
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            _instance = this;
        }
        //
        CanMove = true;
        SoilAct = null;
        if (ListOfSeeds != null) ListOfSeeds = ListOfSeeds.OrderBy(s => s.Name).ToArray();
        if (ListOfPlants != null) ListOfPlants = ListOfPlants.OrderBy(p => p.Name).ToArray();
    }

    public void NextDay()
    {
        InventoryManager.Instance.Gold = InventoryManager.Instance.Gold + GoldReceived;
        GoldReceived = 0;
        UIManager.Instance.UpdateGold();
        SleepEvent?.Invoke();
    }
}
