using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public FunctionControl fx;
    public GameObject pointObject;
    // y - y1 = m(x - x1)
    [Range(-10, 10)]
    public float mSlope = 2.0f;
    [Range(-10, 10)]
    public float startPos = 0;

    private static Vector2 playerPosition;
    private Vector3 Y_function;

    private bool changeParams = false;
    public int range;
    private int startNum = -10;
    GameObject[] pointGuide;
    public float divider = 0.4f;

    public double yint;

    // Start is called before the first frame update
    void Start()
    {
       pointGuide = new GameObject[range];
       playerPosition = new Vector2(transform.localPosition.z, transform.localPosition.x);

        for (int i = 0; i < range ; i++)
        {
            pointGuide[i] = (GameObject)Instantiate(pointObject);
            pointGuide[i].transform.parent = transform;
            pointGuide[i].transform.position = new Vector3(pointGuide[i].transform.position.x,
                1.5f, pointGuide[i].transform.position.z);
            pointGuide[i].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }

    }

    //
    void Update()
    {
        yint = fx.output(0);
        for (int i = 0; i < range; i++)
        { 
            double xpos = (divider) * (i - (int)(range / 2));
            double ypos = fx.output(xpos);
            if (!(Double.IsNegativeInfinity(ypos) || Double.IsInfinity(ypos) || Double.IsNaN(ypos) || ypos > 100 || ypos < -100))
            {
                pointGuide[i].transform.localPosition = new Vector3((float)ypos, 1.5f, (float)xpos);
            }

        }

    }

    void functions () {

    }

    void Aiming()
    {

    }
}
