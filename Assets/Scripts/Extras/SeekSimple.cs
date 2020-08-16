using UnityEngine;

public class SeekSimple : MonoBehaviour
{

    public float MaxSpeed = 1f;
    public float MaxForce = 1f;

    Transform target;
    Vector3 velocity;

    void Awake()
    {
        target = GameObject.Find("Target").transform;
    }

    void FixedUpdate()
    {
        Seek();
    }

    void Seek()
    {
        Vector3 desired = target.position - transform.position;
        desired = desired.normalized * MaxSpeed;
        Vector3 steering = desired - velocity;
        steering = Vector3.ClampMagnitude(steering, MaxForce);
        velocity += steering;
        transform.Translate(velocity * Time.fixedDeltaTime);
    }
}
