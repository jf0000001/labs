using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class TargetRotation : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform target;
    [SerializeField] private TextMeshProUGUI rotationText;

    [Header("Movement")]
    [SerializeField] private float rotationSpeed = 90f;

    private bool lockOn = false;

    void Update()
    {
        rotationText.text = $"Y Rotation: {transform.eulerAngles.y:F1}°";
        
        Keyboard input = Keyboard.current; // Verify keyboard exists
        if (input == null) { return; }
        if (input.tKey.wasPressedThisFrame) { lockOn = !lockOn; }
        if (!lockOn) { return; }

        Vector3 direction = target.position - transform.position;
        direction.y = 0f;
        if (direction.sqrMagnitude < 0.01f) { return; }

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawLine(
            transform.position,
            transform.position + transform.forward * 3f
        );
    }
}
