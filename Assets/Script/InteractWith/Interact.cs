using UnityEngine;

public class Interact : MonoBehaviour
{
    public delegate void InteractedDelegate();
    public event InteractedDelegate InteractEvent;

    public void Interacted()
    {
        InteractEvent?.Invoke();
    }
}
