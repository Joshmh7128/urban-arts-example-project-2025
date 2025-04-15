using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneActor : MonoBehaviour
{
    public Vector3 inputPosition;
    public Vector3 targetPosition;
    public float speed;

    public void CalculateTargetPosition()
    {
        targetPosition = transform.position + inputPosition;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition,  speed * Time.deltaTime);
    }
}
