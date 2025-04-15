using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class NormalExample : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        FireRaycast();
    }
    Vector3 hitPoint, hitNormal;

    void FireRaycast()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity);
        hitPoint = hit.point;
        hitNormal = hit.normal;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, 0.25f);
        Gizmos.DrawLine(transform.position, hitPoint);
        // draw hit point and hit normal
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(hitPoint, 0.25f);
        // draw the normals
        Gizmos.color = Color.green;
        Gizmos.DrawLine(hitPoint, hitPoint + new Vector3(0, hitNormal.normalized.y * 3, 0));
        Gizmos.DrawSphere(hitPoint + new Vector3(0, hitNormal.normalized.y * 3, 0), 0.1f);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(hitPoint, hitPoint + new Vector3(hitNormal.normalized.x * 3, 0, 0));
        Gizmos.DrawSphere(hitPoint + new Vector3(hitNormal.normalized.x * 3, 0, 0), 0.1f);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(hitPoint, hitPoint + new Vector3(0, 0, hitNormal.normalized.z * 3));
        Gizmos.DrawSphere(hitPoint + new Vector3(0, 0, hitNormal.normalized.z * 3), 0.1f);
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(hitPoint, hitPoint + (hitNormal * 3));
        Gizmos.DrawSphere(hitPoint + (hitNormal * 3), 0.1f);
    }
}
