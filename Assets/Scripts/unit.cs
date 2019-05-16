using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    static readonly Vector2 vecAngle0 = new Vector2(1, 0);

    public float velocity = 1f;

    public float anglePerSecond = 90;

    Vector3 destination = new Vector3(0, 0, 0);
    bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        if (!isMoving)
        {
            Move(new Vector2(Random.Range(-2f, 2f), Random.Range(-3f, 3f)));
            return;
        }

        moveTank();
    }

    void moveTank()
    {
        Vector3 vec = destination - transform.position;
        float angle = Vector3.Angle(vec, vecAngle0);

        if(Vector3.Cross(vec.normalized, vecAngle0).z > 0)
        {
            angle = 360 - angle;
        }

        transform.Rotate(Vector3.forward, getRotateAngle(transform.localEulerAngles.z, angle));

        if(Mathf.Abs(transform.localEulerAngles.z - angle) > 10)
        {
            return;
        }

        //move(destination);
        transform.Translate(getTranslateValue(transform.position, destination), Space.World);

        if(transform.position == destination)
        {
            isMoving = false;
        }
    }

    void moveCar()
    {
        Vector3 vec = destination - transform.position;
        float angle = Vector3.Angle(vec, vecAngle0);

        if(Vector3.Cross(vec.normalized, vecAngle0).z > 0)
        {
            angle = 360 - angle;
        }

        transform.Rotate(Vector3.forward, getRotateAngle(transform.localEulerAngles.z, angle));

        if(Mathf.Abs(transform.localEulerAngles.z - angle) > 10)
        {
            return;
        }

        //move(destination);
        transform.Translate(getTranslateValue(transform.position, destination), Space.World);

        if(transform.position == destination)
        {
            isMoving = false;
        }
    }

    Vector3 getTranslateValue(Vector3 pos, Vector3 point)
    {
        float vel = velocity * Time.deltaTime;

        Vector3 vec = point - pos;// new Vector3(point.x - pos.x, point.y - pos.y);

        if(Mathf.Abs(vec.magnitude) < vel)
        {
            return new Vector3(vec.x, vec.y, 0);
        }

        Vector3 work = vec;

        vec.Normalize();
        vec *= vel;

        if(Mathf.Abs(vec.x) >= Mathf.Abs(work.x) || Mathf.Abs(vec.y) >= Mathf.Abs(work.y))
        {
            vec = work;
        }

        return new Vector3(vec.x, vec.y, 0);
    }

    float getRotateAngle(float src, float dest)
    {
        float angle = dest - src;
        float signed = 1;

        if(angle > 180)
        {
            angle = Mathf.Abs(angle - 360);
            signed = -1;
        }
        else if(angle < 0)
        {
            angle = Mathf.Abs(angle);
            signed = -1;
        }

        float ret = anglePerSecond * Time.deltaTime;
        if (angle < ret)
        {
            ret = angle;
        }

        return ret * signed;
    }

    public void Move(Vector2 pos)
    {
        destination.Set(pos.x, pos.y, 0);
        isMoving = true;
    }

}
