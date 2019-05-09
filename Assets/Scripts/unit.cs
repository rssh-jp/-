using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unit : MonoBehaviour
{
    float velocity = 1f;
    int count = 0;
    Vector3 destination = new Vector3(0, 0, 0);

    movable mov;
    // Start is called before the first frame update
    void Start()
    {
        mov = new movable();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(0, 1f * Time.deltaTime, 0);
        transform.Rotate(new Vector3(0, 0, 1), 1f);
        move();
    }

    void move()
    {
        switch (count)
        {
            case 100:
                destination.Set(2f, 2f, 0);
                break;
            case 200:
                destination.Set(-2f, -2f, 0);
                break;
            case 300:
                destination.Set(2f, -2f, 0);
                break;
        }
        Vector3 vec = getTranslateValue(transform.position, destination);
        transform.Translate(vec, Space.World);

        count++;
    }

    Vector3 getTranslateValue(Vector3 position, Vector3 point)
    {
        Debug.Log("++++++++++++++++");
        Debug.Log(string.Join(":", position.ToString(), point.ToString(), mov.ToString()));
        float vel = velocity * Time.deltaTime;
        Vector2 pos = new Vector2(position.x, position.y);
        Vector2 vec = new Vector2(point.x - pos.x, point.y - pos.y);

        if(Mathf.Abs(vec.magnitude) < vel)
        {
            return new Vector3(vec.x, vec.y, 0);
        }

        Vector2 work = vec;

        vec.Normalize();

        vec.x *= vel;
        vec.y *= vel;

        if(Mathf.Abs(vec.x) >= Mathf.Abs(work.x) || Mathf.Abs(vec.y) >= Mathf.Abs(work.y))
        {
            vec = work;
        }

        return new Vector3(vec.x, vec.y, 0);
    }
}
