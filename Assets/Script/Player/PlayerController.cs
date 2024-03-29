using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement _playerMove;
    private PlayerAction _playerAction;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerMove = GetComponent<PlayerMovement>();
        _playerAction = GetComponent<PlayerAction>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        _playerInput.onActionTriggered += OnAction;
    }

    private void OnAction(InputAction.CallbackContext value)
    {
        switch (value.action.name)
        {
            case "Move":
                {
                    if (value.started && GameManager.Instance.CanMove)
                    {
                        _playerMove._moveDirection = value.action.ReadValue<Vector2>();
                    }
                    else if (value.canceled)
                    {
                        _playerMove._moveDirection = Vector2.zero;
                    }
                    break;
                }
            case "Interact":
                {
                    if (value.started && GameManager.Instance.CanMove)
                    {
                        _playerAction.TryInteract();
                    }
                    break;
                }
            case "Inventory":
                {
                    if (value.started && GameManager.Instance.CanMove) 
                    {
                        UIManager.Instance.OpenSeedInventory();
                    }
                    break;
                }
            case "PlantInventory":
                {
                    if (value.started && GameManager.Instance.CanMove)
                    {
                        UIManager.Instance.OpenPlantInventory();
                    }
                    break;
                }
        }
    }
}

