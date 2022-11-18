using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputHandeler : MonoBehaviour, PlayerInput.IKeyboardActions
{
    MoveDirectionCalculator mdc;
    PlayerInput playerInput;
    
    public UnityEvent onJump;
    public UnityEvent onUse;
    public UnityEvent onMove;

    public Vector2 moveInput;
    public Vector3 moveDirection;

    private void Start()
    {
        SetUpValues();
        StartCallBack();
    }
    void StartCallBack()
    {
        playerInput = new PlayerInput();
        playerInput.Keyboard.SetCallbacks(this);
        playerInput.Keyboard.Enable();
    }
    void SetUpValues()
    {
        moveInput = Vector2.zero;
        moveDirection = Vector3.zero;
        TryGetComponent<MoveDirectionCalculator>(out mdc);
        if(mdc == null) throw new System.Exception("Can't find MoveDirectionCalculator");
    }
    void PlayerInput.IKeyboardActions.OnJump(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        onJump?.Invoke();
    }
    void PlayerInput.IKeyboardActions.OnUse(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        onUse?.Invoke();
    }
    void PlayerInput.IKeyboardActions.OnMove(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (!context.performed)
        {
            moveInput = Vector2.zero;
            moveDirection = Vector2.zero;
            return;
        }
       moveInput = context.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        if (moveInput != Vector2.zero)
        {
            mdc.TrySetMove();
            if(moveDirection != Vector3.zero)onMove?.Invoke();
        }
    }

}
