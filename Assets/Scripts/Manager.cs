using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    Camera camera;

    List<GameObject> objs;
    List<Unit> objScripts;

    private float backDist = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        GameObject prefab = Resources.Load<GameObject>("unit");
        objs = new List<GameObject>();
        objScripts = new List<Unit>();


        int num = Random.Range(10, 20);
        for(int i=0; i<num; i++)
        {
            objs.Add(Instantiate(prefab, new Vector3(Random.Range(-2f, 2f), Random.Range(-3f, 3f), 0), Quaternion.identity));
            objScripts.Add(objs[i].GetComponent<Unit>());
            objScripts[i].velocity = Random.Range(0.5f, 2f);
            objScripts[i].anglePerSecond = Random.Range(60, 120);
        }
        camera = GameObject.FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 offset = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z)) - transform.position;
            for(int i=0; i<objScripts.Count; i++)
            {
                objScripts[i].Move(offset);
            }
        }

        float wheel = Input.GetAxis("Mouse ScrollWheel");
        if(wheel != 0)
        {
            setOrthographicSize(1 - wheel);
        }

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 offset = Camera.main.ScreenToWorldPoint(new Vector3 (touch.position.x, Input.mousePosition.y, screenPoint.z)) - transform.position;
            for(int i=0; i<objScripts.Count; i++)
            {
                objScripts[i].Move(offset);
            }
        }

        if(Input.touchCount >= 2)
        {
            Touch t1 = Input.GetTouch(0);
            Touch t2 = Input.GetTouch(1);

            if(t2.phase == TouchPhase.Began)
            {
                backDist = Vector2.Distance (t1.position, t2.position);
            }
            else if (t1.phase == TouchPhase.Moved && t2.phase == TouchPhase.Moved)
            {
                // タッチ位置の移動後、長さを再測し、前回の距離からの相対値を取る。
                float newDist = Vector2.Distance (t1.position, t2.position);
                float dist = (backDist - newDist) / 1000;
                setOrthographicSize(1 + dist);
                backDist = newDist;
            }
        }
    }

    void setOrthographicSize(float ratio)
    {
        camera.orthographicSize *= ratio;
        if(camera.orthographicSize < 3)
        {
            camera.orthographicSize = 3;
        }
        if(camera.orthographicSize > 20)
        {
            camera.orthographicSize = 20;
        }
    }
}
