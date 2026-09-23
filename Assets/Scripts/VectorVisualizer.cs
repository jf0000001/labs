using TMPro;
using UnityEngine;

public class VectorVisualizer : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform player;
    [SerializeField] private Transform target;

    [Header("Visualization")]
    [SerializeField] private LineRenderer lineRenderer;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI distanceText;
    [SerializeField] private TextMeshProUGUI directionText;
    [SerializeField] private TextMeshProUGUI normalizedText;
    [SerializeField] private TextMeshProUGUI angleText;
    [SerializeField] private TextMeshProUGUI deltaText;
    [SerializeField] private TextMeshProUGUI horizontalDistanceText;
    [SerializeField] private TextMeshProUGUI bearingText;
    [SerializeField] private TextMeshProUGUI elevationText;

    void Update()
    {
        //WORLD SPACE
        Vector3 direction = target.position - player.position;
        Vector3 normalizedDirection = direction.normalized;

        float distance = Vector3.Distance(player.position, target.position);
        float angle = Vector3.Angle(player.forward, direction);

        Vector3 delta = target.position - player.position;
        float deltaX = delta.x; float deltaY = delta.y; float deltaZ = delta.z;

        float horizontalDistance = Mathf.Sqrt(deltaX*deltaX + deltaZ*deltaZ);

        float bearingRadians = Mathf.Atan2(deltaX, deltaZ);
        float bearingDegrees = bearingRadians * Mathf.Rad2Deg;

        float elevationRadians = Mathf.Atan2(deltaY, horizontalDistance);
        float elevationDegrees = elevationRadians * Mathf.Rad2Deg;

        lineRenderer.SetPosition(0, player.position - new Vector3(0, 0.5f, 0)); //lower so its visible
        lineRenderer.SetPosition(1, target.position);

        distanceText.text = $"Distance to target: {distance:f2}";
        directionText.text = $"Direction: {direction}";
        normalizedText.text = $"Normalized: {normalizedDirection}";
        angleText.text = $"Angle to target: {angle:f1}°";
        deltaText.text = $"Δx:{deltaX:f2} Δy:{deltaY:f2} Δz:{deltaZ:f2}";
        horizontalDistanceText.text = $"Horizontal Distance: {horizontalDistance:f2}";
        bearingText.text = $"Bearing: {bearingDegrees:f1}°";
        elevationText.text = $"Elevation: {elevationDegrees:f1}°";
    }

    private void OnDrawGizmos()
    {
        if (player == null || target == null) { return; }

        Gizmos.color = Color.green;
        
        Gizmos.DrawLine(player.position, target.position);

        Vector3 horizontalTarget = new Vector3(target.position.x, player.position.y, target.position.z);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(player.position, horizontalTarget);
    }
}
