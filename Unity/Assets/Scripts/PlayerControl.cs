using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject pointObject;
    // y - y1 = m(x - x1)
    [Range(-10, 10)]
    public float mSlope = 2.0f;
    [Range(-10, 10)]
    public float startPos = 0;

    private Vector2 playerPosition;
    private Vector3 Y_function;

    private bool changeParams = false;
    public int range;
    private int startNum = -10;
    GameObject[] pointGuide;
    // Start is called before the first frame update
    void Start()
    {
       pointGuide = new GameObject[range];

        for (int i = 0; i < range ; i++)
        {
            pointGuide[i] = (GameObject)Instantiate(pointObject);
            pointGuide[i].transform.parent = null;
        }

    }

    //
    void Update()
    {
        for (int i = 0; i < range; i++)
        {
            float divider = 5f;
            float t = (i + startNum)/divider;

            float function = t * t;

            playerPosition = new Vector2(transform.localPosition.z, transform.localPosition.x);

            Y_function.z = t - playerPosition.y;
            Y_function.x = function - playerPosition.x;

            Y_function.z += (range/2)/divider;
            Y_function.x -= ((range/2)/divider) * ((range/2)/divider);
            pointGuide[i].transform.localPosition = Y_function;

        }

    }

    void functions () {

    }

    void Aiming()
    {

    }
}
