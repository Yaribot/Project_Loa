using UnityEngine;
using UnityEngine.InputSystem;
using UnityUtils;

//[RequireComponent(typeof(AnimationController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField, Range(0, 10)] float moveSpeed = 5f;
    [SerializeField, Range(0, 10)] float dashDistance = 5f;
    [SerializeField] Transform playerModel;
    [SerializeField] LayerMask boundaryMask;
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
        //Gamepad gamepad = Gamepad.current;
        //if(gamepad == null)
        //{
        //    return;
        //}
        //moveInput = gamepad.leftStick.ReadValue();

        Move(CalculateMovementDirection());

        //Keyboard keybord = Keyboard.current;
        //Mouse mouse = Mouse.current;
    }

    public void Moving(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    public void Dashing(InputAction.CallbackContext context)
    {
        if (context.action.WasPressedThisFrame())
        {
            Dash();
        }
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

    private void Dash()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(CalculateMovementDirection().normalized), out hit, dashDistance, boundaryMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(CalculateMovementDirection().normalized) * hit.distance, Color.red);
            Debug.Log("Did Hit");
            GetPlayerToAPosition(hit.point);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(CalculateMovementDirection().normalized) * dashDistance, Color.green);
            Debug.Log("Did not Hit");
            
            GetPlayerToAPosition(transform.TransformDirection(CalculateMovementDirection().normalized) * dashDistance);
        }
    }
    private void GetPlayerToAPosition(Vector3 DestinationPoint)
    {
        transform.position = DestinationPoint;
    }

}
