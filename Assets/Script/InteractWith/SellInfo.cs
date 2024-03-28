using UnityEngine;

public class SellInfo : MonoBehaviour
{
    /// <summary>
    /// Script needed to interact with
    /// </summary>
    Interact _interact;

    private void Start()
    {
        _interact.GetComponent<Interact>();
        _interact.InteractEvent += ShowSign;
    }
    public void ShowSign()
    {
        
    }
}
