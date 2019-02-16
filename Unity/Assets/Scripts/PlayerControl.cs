using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject pointObject;
    // y - y1 = m(x - x1)
    [Range(-10, 10)]
    public float mSlope = 2.0f;

    private Vector2 playerPosition;
    private Vector3 Y_function;

    private bool changeParams = false;
    public int range;
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
            float d_x = (i + 0.5f) / 5f;

            playerPosition = new Vector2(transform.localPosition.z, transform.localPosition.x);

            float function = mSlope * d_x;

            Y_function.z = d_x - playerPosition.y;
            Y_function.x = -function - playerPosition.x;

            pointGuide[i].transform.localPosition = Y_function;
            
        }
    }

    void Aiming()
    {

    }
}
