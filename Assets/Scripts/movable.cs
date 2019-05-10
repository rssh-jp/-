using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movable
{
    float velocity = 1f;
    Vector3 destination = new Vector3(0, 0, 0);
    public Vector3 position;
    public float angle;

    public Vector2 move()
    {
        return new Vector2(1, 1);
    }

    public void Update(float deltaTime)
    {

    }

    public string ToString()
    {
        return velocity.ToString();
    }
}
