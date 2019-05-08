using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unit : MonoBehaviour
{
    float velocity = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(0, 1f * Time.deltaTime, 0);
        move();
    }

    void move()
    {
        Vector3 vec = getTranslateValue(transform.position, new System.Numerics.Vector2(1.1f, 1.1f));
        transform.Translate(vec);
    }

    Vector3 getTranslateValue(Vector3 position, System.Numerics.Vector2 point)
    {
        float vel = velocity * Time.deltaTime;
        System.Numerics.Vector2 pos = new System.Numerics.Vector2(position.x, position.y);
        System.Numerics.Vector2 vec = new System.Numerics.Vector2(point.X - pos.X, point.Y - pos.Y);

        if(vec.Length() < vel)
        {
            return new Vector3(vec.X, vec.Y, 0);
        }

        System.Numerics.Vector2 work = vec;

        vec = System.Numerics.Vector2.Normalize(vec);


        vec.X *= velocity * Time.deltaTime;
        vec.Y *= velocity * Time.deltaTime;

        if(vec.X >= work.X || vec.Y >= work.Y)
        {
            vec = work;
        }

        Debug.Log(vec);
        Debug.Log(position);
        return new Vector3(vec.X, vec.Y, 0);
    }
}
