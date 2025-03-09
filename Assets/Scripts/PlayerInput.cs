using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput {
    private PlayerInputActions playerInputActions;
    
    public event Action OnPressedInteract;
    public event Action OnPressedAttack;
    
    public PlayerInput() {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
        playerInputActions.PlayerActionMap.Enable();
        playerInputActions.PlayerActionMap.Interact.performed += PlayerPressedInteract;
        playerInputActions.PlayerActionMap.Attack.performed += PlayerPressedAttack;
    }

    private void PlayerPressedInteract(InputAction.CallbackContext context) {
        OnPressedInteract?.Invoke();
    }
    private void PlayerPressedAttack(InputAction.CallbackContext context) {
        OnPressedAttack?.Invoke();
    }

    public Vector2 GetMovementDirection() {
        return playerInputActions.PlayerActionMap.Movement.ReadValue<Vector2>();
    }
}
