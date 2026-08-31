using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float speed = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
