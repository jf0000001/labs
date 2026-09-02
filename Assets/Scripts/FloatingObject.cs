using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public float height = 1f;
    public float speed = 2f;
    
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;   
    }

    void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * height;
        transform.position = new Vector3(
            startPosition.x,
            newY,
            startPosition.z
        );
    }
}
