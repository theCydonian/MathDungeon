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
    private int i = 0;
    private int l = 0;

    // Start is called before the first frame update
    void Start()
    {
      if (right) {
        wall.transform.Rotate(Vector3.forward * 50);
      } else {
        wall.transform.Rotate(Vector3.forward * -50);
      }
    }

    // Update is called once per frame
    void Update()
    {
      if (l % 2 == 0) {
        if (i < 10) {
          if (right) {
            wall.transform.Rotate(Vector3.forward * -(10 - i));
          } else {
            wall.transform.Rotate(Vector3.forward * (10 - i));
          }
          i += 1;
        }
      }
      l += 1;
    }
}
