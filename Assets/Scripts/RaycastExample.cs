using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastExample : MonoBehaviour
{
    RaycastHit2D hit2D;
    [SerializeField] float distance = 1f;
    [SerializeField] Vector2 offset = new Vector2(0, 0);

    // Update is called once per frame
    void FixedUpdate()
    {
        ShootRaycast();
    }

    void ShootRaycast()
    {
        hit2D = Physics2D.Raycast((Vector2)transform.position + offset, Vector2.left, distance, Physics.AllLayers, 0, 0);
    }

    private void OnDrawGizmos()
    {
        if (hit2D.collider == null)
            Gizmos.color = Color.red;
        else
            Gizmos.color = Color.green;
        Gizmos.DrawSphere((Vector2)transform.position + offset, 0.1f);
        Gizmos.DrawSphere((Vector2)transform.position + ((Vector2.left * distance) + offset), 0.1f);
        Gizmos.DrawLine((Vector2)transform.position + offset, (Vector2)transform.position + ((Vector2.left * distance) + offset));
    }
}
