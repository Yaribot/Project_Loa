using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static PlayerControlAction;

public interface IInputReader
{
    Vector2 Direction { get; }
    void EnablePlayerAction();
    void DisablePlayerAction();
}

[CreateAssetMenu(fileName = "InputReader", menuName = "Scriptable Objects/InputReader")]
public class InputReader : ScriptableObject, IPlayerActions, IInputReader
{
    public event UnityAction<Vector2> Move = delegate { };
    public event UnityAction<bool> Dash = delegate { };
    public event UnityAction<bool> Attack = delegate { };

    public PlayerControlAction inputAction;
    public Vector2 Direction => inputAction.Player.Move.ReadValue<Vector2>();
    public bool IsDashKeyPressed => inputAction.Player.Dash.IsPressed();

    public void DisablePlayerAction()
    {
        if (inputAction == null)
        {
            inputAction = new PlayerControlAction();
            inputAction.Player.SetCallbacks(this);
        }
        inputAction.Disable();
    }

    public void EnablePlayerAction()
    {
        if(inputAction == null)
        {
            inputAction = new PlayerControlAction();
            inputAction.Player.SetCallbacks(this);
        }
        inputAction.Enable();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                Attack.Invoke(true);
                break;
            case InputActionPhase.Canceled:
                Attack.Invoke(false);
                break;
        }
    }

    public void OnCast(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                Dash.Invoke(true);
                break;
            case InputActionPhase.Canceled:
                Dash.Invoke(false);
                break;
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Move.Invoke(context.ReadValue<Vector2>());
    }

    public void OnNext(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnPrevious(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnSpecialAttack(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
}
