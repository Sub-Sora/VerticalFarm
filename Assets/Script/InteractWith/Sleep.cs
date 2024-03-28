using UnityEngine;

public class Sleep : MonoBehaviour
{
    /// <summary>
    /// Script needed to interact with
    /// </summary>
    Interact _interact;

    private void Start()
    {
        _interact = GetComponent<Interact>();
        _interact.InteractEvent += Interaction;
    }

    public void Interaction()
    {
        GameManager.Instance.NextDay();
    }
}
