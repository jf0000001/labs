using UnityEngine;

public class DirectionIndicator : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 10f;

    void Update()
    {
        // Local Space
        if (target == null) { return; }

        Vector3 direction = target.position - transform.position;
        if (direction == Vector3.zero) { return; }

        Quaternion targetRot = Quaternion.LookRotation(direction) * Quaternion.Euler(new Vector3(0, 90, 0));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);
    }
}
