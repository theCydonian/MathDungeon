using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScrollBar : MonoBehaviour
{
    public Slider mainSlider;
    public Text mainText;
    public String letter;
    public bool AbsValue = false;

    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
      mainSlider.value = 0.5f;
      mainText.text = letter;
    }

    // Update is called once per frame
    void Update()
    {
      if (mainSlider.value != 0.5f || i > 0) {
        if (AbsValue) {
          mainText.text = "" + Mathf.Abs(Mathf.Round(mainSlider.value * 20f) - 10f);
          Debug.Log("true");
          i = 1;
        } else {
          mainText.text = "" + (Mathf.Round(mainSlider.value * 20f) - 10);
          i = 1;
        }
      }
    }
}
