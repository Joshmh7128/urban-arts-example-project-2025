using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FrictionExample : MonoBehaviour
{
    // you should in fact comment things with serializefield
    [SerializeField] private float speed = 1, movespeed = 0.1f;
    [SerializeField] float coefficient = 0.065f;
    [SerializeField] float normalCo = 0.065f;
    [SerializeField] float strongCo = 0.065f;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Slowdown")
        {
            coefficient = strongCo;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Slowdown")
        {
            coefficient = normalCo;
        }
    }

    // Fixed update is called 50 times per second
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            speed = movespeed;
            speed += (-1 * Mathf.Sign(speed)) * Mathf.Abs(speed * coefficient * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            speed = -movespeed;
            speed += (-1 * Mathf.Sign(speed)) * Mathf.Abs(speed * coefficient * Time.deltaTime);
        }

        transform.position += new Vector3(speed, 0, 0);
        speed += (-1 * Mathf.Sign(speed)) * Mathf.Abs(speed * coefficient * Time.fixedDeltaTime);

        if (Mathf.Sign(speed) == 1 && speed < 0.001)
            speed = 0;
        if (Mathf.Sign(speed) == -1 && speed > -0.001)
            speed = 0;
    }
}
