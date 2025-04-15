using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += move * Time.deltaTime * 5;
    }

    public void MovePlayer(float x)
    {
        move.x = x;
    }
}
