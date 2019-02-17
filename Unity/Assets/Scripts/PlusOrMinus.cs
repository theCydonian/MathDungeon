using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlusOrMinus : MonoBehaviour
{
  public Slider mainSlider1;
  public Text mainText1;
  public bool plus = true;

    // Start is called before the first frame update
    void Start()
    {
      if (plus) {
        mainText1.text = "+";
      } else {
        mainText1.text = "-";
      }
    }

    // Update is called once per frame
    void Update()
    {
      if (plus) {
        if (mainSlider1.value >= 0.5) {
          mainText1.text = "+";
        } else {
          mainText1.text = "-";
        }
      } else {
        if (mainSlider1.value >= 0.5) {
          mainText1.text = "-";
        } else {
          mainText1.text = "+";
        }
      }
    }
}
