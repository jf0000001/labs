using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileMotion : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float friction = 3.5f;

    [Header("UI")]
    [SerializeField] private Slider angleSlider;
    [SerializeField] private Slider speedSlider;
    [SerializeField] private Button launchButton;
    [SerializeField] private Button resetButton;
    [SerializeField] private TextMeshProUGUI velocityText;
    [SerializeField] private TextMeshProUGUI positionText;
    
    private Vector3 velocity;
    
    private float groundHeight;

    void Start()
    {
        groundHeight = 0f + (transform.localScale.y / 2);
        if (launchButton != null)
        {
            launchButton.onClick.AddListener(onLaunchPressed);
        }
        if (resetButton != null)
        {
            resetButton.onClick.AddListener(onResetPressed);
        }
    }

    void onLaunchPressed()
    {
        float angleRadians = angleSlider.value * Mathf.Deg2Rad;

        velocity = new Vector3(
            speedSlider.value * Mathf.Cos(angleRadians),
            speedSlider.value * Mathf.Sign(angleRadians),
            0f
        );
    }

    void onResetPressed()
    {
        velocity = Vector3.zero;
        transform.position = new Vector3(0f, 1f, 0f);
    }

    void Update()
    {
        velocity.y += gravity * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

        if (transform.position.y <= groundHeight)
        {
            transform.position = new Vector3(
                transform.position.x,
                groundHeight,
                transform.position.z
            );

            velocity.y = -velocity.y / 2f; // bouncy projectile !!
            velocity.x = Mathf.Lerp(velocity.x, 0f, friction * Time.deltaTime); // friction so it slows down
            velocity.z = Mathf.Lerp(velocity.z, 0f, friction * Time.deltaTime);
        }

        velocityText.text = $"Velocity: {velocity}";
        positionText.text = $"Position: {transform.position}";
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(
            transform.position,
            transform.position + velocity * 0.25f
        );
    }
}
