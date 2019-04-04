// LUKE GO TO LINE 168
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatedGUIToText : MonoBehaviour
{
    public float degree;
    public Vector2 size = new Vector2(65, 80);
    public Material invisible;
    public GameObject button;
    public Text power;
    public Vector2 range;

    private GameObject MPoint, BPoint, APoint, HPoint, KPoint, PowerPoint;
    private int m, b, a, h, k;
    private string[] stringVars;
    private int[] vars;
    private bool[] varSets;
    private GameObject[] scrollImage;
    private Vector3[] imagePosition;
    private float minRange;
    private float maxRange;
    private Text powerOFunc;
    private string mValue, bValue, aValue, hValue, kValue;

    // Start is called before the first frame update
    void Start()
    {
        MPoint = GameObject.Find("MPoint");
        BPoint = GameObject.Find("BPoint");
        APoint = GameObject.Find("APoint");
        HPoint = GameObject.Find("HPoint");
        KPoint = GameObject.Find("KPoint");
        PowerPoint = GameObject.Find("PowerPoint");
        minRange = range.x;
        maxRange = range.y;

        if (degree == 1)
        {
            vars = new int[2];
            vars[0] = m;
            vars[1] = b;
            imagePosition = new Vector3[2];
            imagePosition[0] = MPoint.transform.position;
            imagePosition[1] = BPoint.transform.position;
            stringVars = new string[2];
            stringVars[0] = "M";
            stringVars[1] = "B";
            varSets = new bool[2];
            varSets[0] = false;
            varSets[1] = false;
        }
        else
        {
            powerOFunc = Instantiate(power, PowerPoint.transform.position, Quaternion.Euler(0, 0, 0), gameObject.transform);
            powerOFunc.GetComponent<Text>().text = "" + degree;
            vars = new int[3];
            vars[0] = a;
            vars[1] = h;
            vars[2] = k;
            imagePosition = new Vector3[3];
            imagePosition[0] = APoint.transform.position;
            imagePosition[1] = HPoint.transform.position;
            imagePosition[2] = KPoint.transform.position;
            stringVars = new string[3];
            stringVars[0] = "A";
            stringVars[1] = "H";
            stringVars[2] = "K";
            varSets = new bool[3];
            varSets[0] = false;
            varSets[1] = false;
            varSets[2] = false;
        }

        scrollImage = new GameObject[vars.Length];
        for (int i = 0; i < vars.Length; i++)
        {
            scrollImage[i] = Instantiate(button, imagePosition[i], Quaternion.Euler(0, 0, 0), gameObject.transform);
            scrollImage[i].GetComponent<RectTransform>().sizeDelta = size;
            scrollImage[i].gameObject.name = stringVars[i];
            scrollImage[i].GetComponent<Image>().material = invisible;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (degree == 0)
        {
            GetComponent<Text>().text = "CHANGE DEGREE";
        }
        else if (degree == 1)
        {
            if (varSets[0] == false)
            {
                mValue = "M";
            }
            else
            {
                mValue = "" + m;
            }

            if (varSets[1] == false)
            {
                bValue = "+ B";
            }
            else
            {
                if (Mathf.Sign(b) > 0)
                {
                    bValue = "+ " + b;
                }
                else
                {
                    bValue = "- " + Mathf.Abs(b);
                }
            }

            GetComponent<Text>().text = "F(X) = " + mValue + " X " + bValue;
        }
        else
        {
            if (varSets[0] == false)
            {
                aValue = "A";
            }
            else
            {
                aValue = "" + a;
            }

            if (varSets[1] == false)
            {
                hValue = "- H";
            }
            else
            {
                if (Mathf.Sign(h) > 0)
                {
                    hValue = "- " + h;
                }
                else
                {
                    hValue = "+ " + Mathf.Abs(h);
                }
            }

            if (varSets[2] == false)
            {
                kValue = "+ K";
            }
            else
            {
                if (Mathf.Sign(k) > 0)
                {
                    kValue = "+ " + k;
                }
                else
                {
                    kValue = "- " + Mathf.Abs(k);
                }
            }
            GetComponent<Text>().text = "F(X) = " + aValue + "(X " + hValue + ") " + kValue;
        }

        // LUKE SEND GetComponent<Text>().text to your post fix script from here
    }

    public void SetVar(string varName, float amount)
    {
        if (varName == "M")
        {
            m = (int)((amount * (maxRange - minRange)) + minRange);
            varSets[0] = true;
        }
        if (varName == "B")
        {
            b = (int)((amount * (maxRange - minRange)) + minRange);
            varSets[1] = true;
        }
        if (varName == "A")
        {
            a = (int)((amount * (maxRange - minRange)) + minRange);
            varSets[0] = true;
        }
        if (varName == "H")
        {
            h = (int)((amount * (maxRange - minRange)) + minRange);
            varSets[1] = true;
        }
        if (varName == "K")
        {
            k = (int)((amount * (maxRange - minRange)) + minRange);
            varSets[2] = true;
        }
    }
}
