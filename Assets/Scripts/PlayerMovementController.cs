using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 100f;

    private PlayerInput controls;
    private InputActionMap playerMap;
    private Vector2 moveInput;

    void Awake()
    {
        controls = GetComponent<PlayerInput>();
        playerMap = controls.actions.FindActionMap("Player");
    }

    private void OnEnable()
    {
        playerMap.Enable();
        playerMap.FindAction("Move").performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        playerMap.FindAction("Move").canceled += ctx => moveInput = Vector2.zero;
    }

    private void OnDisable()
    {
        playerMap.Disable();
    }
    void Start()
    {
        
    }

    void Update()
    {
        // Uses local space to move

        Keyboard input = Keyboard.current; // Verify keyboard exists
        if (input == null) { return; }

        Vector3 direction = new Vector3(
            moveInput.x,
            0,
            moveInput.y
        );
        
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        // Get turn direction, about y axis. if both e and q are held, does not turn since it adds to 0
        Vector3 turnDirection =
            Vector3.up * ((input.eKey.isPressed ? 1 : 0) - (input.qKey.isPressed ? 1 : 0));
        
        transform.Rotate(turnDirection * turnSpeed * Time.deltaTime);
    }
}
