using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement _playerMove;
    private PlayerAction _playerAction;
    private PlayerInput _playerInput;
    private PlayerMenu _playerMenu;

    private void Awake()
    {
        _playerMove = GetComponent<PlayerMovement>();
        _playerAction = GetComponent<PlayerAction>();
        _playerInput = GetComponent<PlayerInput>();
        _playerMenu = GetComponent<PlayerMenu>();
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
                    if (value.started)
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
                    if (value.started)
                    {
                        _playerAction.TryInteract();
                    }
                    break;
                }
            case "Inventory":
                {
                    if (value.started) 
                    {
                        _playerMenu.ButtonInventoryPress();
                    }
                    break;
                }
        }
    }

    private void OnInteract(InputValue value)
    {
    }
}

