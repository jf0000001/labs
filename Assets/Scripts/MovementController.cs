using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        Keyboard input = Keyboard.current;
        if (input == null) { return; }

        Vector3 direction = new Vector3(
            (input.dKey.isPressed ? 1 : 0) - (input.aKey.isPressed ? 1 : 0),
            0,
            (input.wKey.isPressed ? 1 : 0) - (input.sKey.isPressed ? 1 : 0)
        ); // Get vector representing direction for movement

        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}
