using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    private Interact _interactWith;
    [SerializeField] private GameObject _buttonInteract;
    private bool _canInteract;
    public void TryInteract()
    {
        if (_canInteract && _interactWith != null)
        {
            _interactWith.Interacted();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _canInteract = true;
        _interactWith = collision.GetComponent<Interact>();
        _buttonInteract.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _canInteract = false;
        _interactWith = null;
        _buttonInteract.SetActive(false);
    }
}
