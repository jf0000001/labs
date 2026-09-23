using TMPro;
using UnityEngine;

public class TargetRotation : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform target;
    [SerializeField] private TextMeshProUGUI rotationText;

    [Header("Movement")]
    [SerializeField] private float rotationSpeed = 90f;

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        direction.y = 0f;
        if (direction.sqrMagnitude < 0.01f) { return; }

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );

        rotationText.text = $"Y Rotation: {transform.eulerAngles.y:F1}°";
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
