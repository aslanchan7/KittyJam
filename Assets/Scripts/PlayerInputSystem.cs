using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerInputSystem : MonoBehaviour
{
    PlayerInputActions playerInputActions;

    void Awake()
    {
        playerInputActions = new();
    }

    void OnEnable()
    {
        playerInputActions.Player.Enable();
        playerInputActions.Player.Left.performed += LeftPressed;
        playerInputActions.Player.Up.performed += UpPressed;
        playerInputActions.Player.Down.performed += DownPressed;
        playerInputActions.Player.Right.performed += RightPressed;
    }

    void OnDisable()
    {
        playerInputActions.Player.Disable();
        playerInputActions.Player.Left.performed -= LeftPressed;
        playerInputActions.Player.Up.performed -= UpPressed;
        playerInputActions.Player.Down.performed -= DownPressed;
        playerInputActions.Player.Right.performed -= RightPressed;
    }

    public void LeftPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Left Button Pressed!");
        }
    }

    public void UpPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Up Button Pressed!");
        }
    }

    public void DownPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Down Button Pressed");
        }
    }

    public void RightPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Right Button Pressed");
        }
    }
}
