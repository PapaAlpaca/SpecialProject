using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private bool moving = false;
    private float dist = 0.0f;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B)) {
            moving = !moving;
        }
        if(moving)
        {
            transform.Translate(0.0f, -0.01f, 0.0f);
            dist += 0.01f;
        }
    }

    public bool isMoving()
    {
        return moving;
    }

    // Works with planes, not with cubes
    public void reset()
    {
        moving = false;
        transform.position = new Vector3(0.0f, 0.0f, -55.0f);
        dist = 0.0f;
    }
}