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

    void Start()
    {
        
    }

    void Update()
    {
        //WORLD SPACE
        Vector3 direction = target.position - player.position;
        Vector3 normalizedDirection = direction.normalized;

        float distance = Vector3.Distance(player.position, target.position);
        float angle = Vector3.Angle(player.forward, direction);

        lineRenderer.SetPosition(0, player.position - new Vector3(0, 0.5f, 0)); //lower so its visible
        lineRenderer.SetPosition(1, target.position);

        distanceText.text = $"Distance to target: {distance:f2}";
        directionText.text = $"Direction: {direction}";
        normalizedText.text = $"Normalized: {normalizedDirection}";
        angleText.text = $"Angle to target: {angle:f1}°";
    }

    private void OnDrawGizmos()
    {
        if (player == null || target == null)
        {
            return;
        }

        Gizmos.color = Color.green;
        
        Gizmos.DrawLine(player.position, target.position);
    }
}
