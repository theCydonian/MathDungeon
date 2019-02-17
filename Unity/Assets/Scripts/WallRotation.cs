using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WallRotation : MonoBehaviour
{

    public GameObject wall;
    public bool right;
    private float sum = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
          if (right) {
            if (sum < 30)
            {
                wall.transform.Rotate(0, 0, -1.0f);
                sum += 1.0f;
            }
          } else {
            if (sum < 30)
            {
                wall.transform.Rotate(0, 0, 1.0f);
                sum += 1.0f;
            }
          }
        }
      }
