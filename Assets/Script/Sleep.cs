using UnityEngine;

public class Sleep : MonoBehaviour
{
    public void Interaction()
    {
        GameManager.Instance.NextDay();
    }
}
