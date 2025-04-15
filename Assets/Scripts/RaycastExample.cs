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
        hit2D = Physics2D.Raycast((Vector2)transform.position + offset, Vector2.right, distance, Physics.AllLayers, 0, 0);
        hit2D = Physics2D.Raycast((Vector2)transform.position + offset, Vector2.up, distance, Physics.AllLayers, 0, 0);
        hit2D = Physics2D.Raycast((Vector2)transform.position + offset, Vector2.down, distance, Physics.AllLayers, 0, 0);
    }

    List<Vector2> dirs = new List<Vector2> { Vector2.up, Vector2.down, Vector2.right, Vector2.left };

    private void OnDrawGizmos()
    {
        if (hit2D.collider == null)
            Gizmos.color = Color.red;
        else
            Gizmos.color = Color.green;

        for (int i = 0; i < dirs.Count; i++)
        {
            Gizmos.DrawSphere((Vector2)transform.position + offset, 0.1f);
            Gizmos.DrawSphere((Vector2)transform.position + ((dirs[i] * distance) + offset), 0.1f);
            Gizmos.DrawLine((Vector2)transform.position + offset, (Vector2)transform.position + ((dirs[i] * distance) + offset));
        }
    }
}
