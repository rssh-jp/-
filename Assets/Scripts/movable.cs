using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movable
{
    float velocity = 1f;

    public Vector2 move()
    {
        return new Vector2(1, 1);
    }

    public string ToString()
    {
        return velocity.ToString();
    }
}
