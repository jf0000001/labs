using UnityEngine;
using UnityEngine.InputSystem;

public class CameraZoom : MonoBehaviour
{
    public float zoomSpeed = 10f;
    void Start()
    {
        
    }

    void Update()
    {
        Keyboard input = Keyboard.current; // Verify keyboard is found
        if (input == null) { return; }

        Vector3 zoomDirection = new Vector3(
            0,
            0,
            (input.rKey.isPressed ? 1 : 0) - (input.fKey.isPressed ? 1 : 0)
        );
        
        transform.Translate(zoomDirection * zoomSpeed * Time.deltaTime);
    }
}
