using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 100f;

    void Start()
    {
        
    }

    void Update()
    {
        // Uses local space to move

        Keyboard input = Keyboard.current; // Verify keyboard exists
        if (input == null) { return; }

        /*
        Creates a direction vector based on keys being pressed.
        Checks if a key is pressed, and if it is, it is set to 1, otherwise, 0.
        So, if d is pressed, and a is pressed, it is 1 - 1, so the player does not move
        */
        Vector3 direction = new Vector3(
            (input.dKey.isPressed ? 1 : 0) - (input.aKey.isPressed ? 1 : 0),
            0,
            (input.wKey.isPressed ? 1 : 0) - (input.sKey.isPressed ? 1 : 0)
        );
        
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        // Get turn direction, about y axis. if both e and q are held, does not turn since it adds to 0
        Vector3 turnDirection =
            Vector3.up * ((input.eKey.isPressed ? 1 : 0) - (input.qKey.isPressed ? 1 : 0));
        
        transform.Rotate(turnDirection * turnSpeed * Time.deltaTime);
    }
}
