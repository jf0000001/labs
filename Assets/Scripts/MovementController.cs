using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    public float speed = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.isPressed)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
