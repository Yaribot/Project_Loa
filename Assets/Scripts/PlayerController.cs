using UnityEngine;
using UnityEngine.InputSystem;
using UnityUtils;

//[RequireComponent(typeof(AnimationController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField, Range(0, 10)] float moveSpeed = 5f;
    [SerializeField] Transform playerModel;
    private Camera mainCamera;
    private Vector2 moveInput;

    public Vector3 GetMovementVelocity() => moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Gamepad gamepad = Gamepad.current;
        if(gamepad == null)
        {
            return;
        }
        moveInput = gamepad.leftStick.ReadValue();

        Move(CalculateMovementDirection());

        Keyboard keybord = Keyboard.current;
        Mouse mouse = Mouse.current;
    }

    private void Move(Vector3 direction)
    {
        if (direction.sqrMagnitude > 0.01f)
        {
            playerModel.rotation = Quaternion.LookRotation(direction);
            transform.position += direction * (Time.deltaTime * moveSpeed);
        }
    }

    private Vector3 CalculateMovementDirection()
    {
        Vector3 cameraForward = mainCamera.transform.forward.With(y: 0);
        Vector3 cameraRight = mainCamera.transform.right.With(y: 0);

        return cameraForward * moveInput.y + cameraRight * moveInput.x;
    }
}
