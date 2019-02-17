using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUIToText : MonoBehaviour
{
    public GameObject Type;
    public Slider ASlider;
    public Slider BSlider;
    public Slider HSlider;
    public Slider KSlider;
    public Slider mSlider;

    private int AValue;
    private int BValue;
    private int HValue;
    private int KValue;
    private int MValue;

    private string AString;
    private string BString;
    private string HString;
    private string KString;
    private string MString;

    private string GUIString;

    string GUIString1 = "";

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if (Type.name == "Linear") {
        MValue = Mathf.RoundToInt(mSlider.value * 20f) - 10;
        if (MValue < 0) {
          MString = "(0 - " + Mathf.Abs(MValue) + ")";
        } else {
          MString = "" + MValue;
        }
        BValue = Mathf.RoundToInt(BSlider.value * 20f) - 10;
        if (BValue < 0) {
          BString = "(0 - " + Mathf.Abs(BValue) + ")";
        } else {
          BString = "" + BValue;
        }
        Debug.Log(mSlider.value);
        GUIString = "(" + MString + " * (x)) + " + BString;
      } else if (Type.name == "Quadratic") {
        AValue = Mathf.RoundToInt(ASlider.value * 20f) - 10;
        if (AValue < 0) {
          AString = "(0 - " + Mathf.Abs(AValue) + ")";
        } else {
          AString = "" + AValue;
        }
        HValue = Mathf.RoundToInt(HSlider.value * 20f) - 10;
        if (HValue < 0) {
          HString = "(0 - " + Mathf.Abs(HValue) + ")";
        } else {
          HString = "" + HValue;
        }
        KValue = Mathf.RoundToInt(KSlider.value * 20f) - 10;
        if (KValue < 0) {
          KString = "(0 - " + Mathf.Abs(KValue) + ")";
        } else {
          KString = "" + KValue;
        }
        GUIString = "(" + AString + " * ((x - " + HString + ")^2)) + " + KString;
      } else if (Type.name == "Cubic") {
        AValue = Mathf.RoundToInt(ASlider.value * 20f) - 10;
        if (AValue < 0) {
          AString = "(0 - " + Mathf.Abs(AValue) + ")";
        } else {
          AString = "" + AValue;
        }
        HValue = Mathf.RoundToInt(HSlider.value * 20f) - 10;
        if (HValue < 0) {
          HString = "(0 - " + Mathf.Abs(HValue) + ")";
        } else {
          HString = "" + HValue;
        }
        KValue = Mathf.RoundToInt(KSlider.value * 20f) - 10;
        if (KValue < 0) {
          KString = "(0 - " + Mathf.Abs(KValue) + ")";
        } else {
          KString = "" + KValue;
        }
        GUIString = "(" + AString + " * ((x - " + HString + ")^3)) + " + KString;
      }
      GUIString1 = GUIString;
      Debug.Log(GUIString1);
    }
}
