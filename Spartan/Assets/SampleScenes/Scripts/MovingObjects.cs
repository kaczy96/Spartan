using UnityEngine;

public class MovingObjects : MonoBehaviour
{
    [SerializeField]
    private Transform platform;

    [SerializeField]
    private Transform startTransform;

    [SerializeField]
    private Transform endTransform;

    [SerializeField]
    private float platformSpeed;

    private Vector3 direction;
    private Transform destination;

    private void Start()
    {
        SetDestination(startTransform);
    }

    private void FixedUpdate()
    {
        platform.GetComponent<Rigidbody2D>().MovePosition(platform.position + direction * platformSpeed * Time.fixedDeltaTime);

        if (Vector3.Distance(platform.position, destination.position) < platformSpeed * Time.fixedDeltaTime)
        {
            SetDestination(destination == startTransform ? endTransform : startTransform);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(startTransform.position, platform.localScale);

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(endTransform.position, platform.localScale);
    }

    private void SetDestination(Transform dest)
    {
        destination = dest;
        direction = (destination.position - platform.position).normalized;
    }
}