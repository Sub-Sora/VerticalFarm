using UnityEngine;

public class Sleep : MonoBehaviour
{
    /// <summary>
    /// Script needed to interact with
    /// </summary>
    private Interact _interact;

    [SerializeField] private GameObject _canvaAnim;

    private void Start()
    {
        _interact = GetComponent<Interact>();
        _interact.InteractEvent += Interaction;
    }

    public void Interaction()
    {
        GameManager.Instance.NextDay();
        _canvaAnim.SetActive(true);
    }
}
