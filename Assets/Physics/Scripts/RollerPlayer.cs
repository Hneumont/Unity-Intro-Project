using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]

public class RollerPlayer : MonoBehaviour
{
    [SerializeField, Range(0, 10)] float moveForce = 3;
    [SerializeField, Range(0, 10)] float jumpForce = 3;
    [SerializeField] Transform view;

    [Header("Ground Collision")]
    [SerializeField, Range(0, 5)] float rayLength = 1;
    [SerializeField] LayerMask groundLayerMask = Physics.AllLayers;

    Rigidbody theMeat;
    Vector2 inputMovement;

    InputAction moveAction;
    InputAction jumpAction;

    void Awake() // september has ended
    {       //if null, assign
        view ??= Camera.main.transform;

        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");

        theMeat = GetComponent<Rigidbody>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable()
    {
        moveAction.performed += onMove;
        moveAction.canceled += onMove;
        jumpAction.started += onJump;

        //InputSystem.actions.FindActionMap("Player").enable;
        //InputSystem.actions.FindActionMap("UI").enable;
    }

    private void OnDisable()
    {
        moveAction.performed -= onMove;
        moveAction.canceled -= onMove;
        jumpAction.started -= onJump;
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, Vector3.down*rayLength, Color.purple);
    }

    private void FixedUpdate()
    {
        // Convert controller space to world space
        Vector3 movement = new Vector3(inputMovement.x, 0, inputMovement.y);
        movement = Quaternion.AngleAxis(view.rotation.eulerAngles.y, Vector3.up)* movement;
        theMeat.AddForce(movement * moveForce, ForceMode.Force);
    }

    private void onMove(InputAction.CallbackContext ctx)
    {
        inputMovement = ctx.ReadValue<Vector2>();
    }

    private void onJump(InputAction.CallbackContext ctx)
    {
        if (!OnGround()) return;
        theMeat.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
    }

    bool OnGround()
    {
        return Physics.Raycast(transform.position, Vector3.down, rayLength, groundLayerMask);
    }
}
