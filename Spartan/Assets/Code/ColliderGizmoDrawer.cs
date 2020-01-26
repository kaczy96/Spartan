using UnityEngine;

public class ColliderGizmoDrawer:MonoBehaviour {
    BoxCollider2D collider;

    void Awake() {
        Init();
    }

    void Init() {
        collider = GetComponent<BoxCollider2D>();
    }

    public void OnDrawGizmos() {
        if(collider == null)
            Init();
        var center = new Vector3(collider.transform.position.x + collider.offset.x,
            collider.transform.position.y + collider.offset.y, collider.transform.position.z);
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(center, collider.size);
    }
}