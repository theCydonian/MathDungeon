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
    public int maxRange;
    public int minRange;

    private GameObject MPoint, BPoint, APoint, HPoint, KPoint, PowerPoint;
    private string[] stringVars, values;
    private int[] vars;
    private bool[] varSets;
    private GameObject[] scrollImage;
    private Vector3[] imagePosition;
    private float arrayLength, startIndex, setVarIndex;
    private Text powerOFunc;
    private int signIndex;
    private string[] signArray;

    // Start is called before the first frame update
    void Start()
    {
        MPoint = GameObject.Find("MPoint");
        BPoint = GameObject.Find("BPoint");
        APoint = GameObject.Find("APoint");
        HPoint = GameObject.Find("HPoint");
        KPoint = GameObject.Find("KPoint");
        PowerPoint = GameObject.Find("PowerPoint");
        values = new string[5];
        signArray = new string[3];
        signArray[0] = "+ ";
        signArray[1] = "- ";
        signArray[2] = "+ ";
        vars = new int[5];
        imagePosition = new Vector3[5];
        imagePosition[0] = MPoint.transform.position;
        imagePosition[1] = BPoint.transform.position;
        imagePosition[2] = APoint.transform.position;
        imagePosition[3] = HPoint.transform.position;
        imagePosition[4] = KPoint.transform.position;
        stringVars = new string[5];
        stringVars[0] = "M";
        stringVars[1] = "B";
        stringVars[2] = "A";
        stringVars[3] = "H";
        stringVars[4] = "K";
        varSets = new bool[5];
        for (int k = 0; k < 5; k ++)
        {
            varSets[k] = false;
        }

        if (degree == 1)
        {
            arrayLength = 2;
            startIndex = 0;
        }
        else
        {
            Instantiate(power, PowerPoint.transform.position, Quaternion.Euler(0, 0, 0), gameObject.transform).GetComponent<Text>().text = "" + degree;
            arrayLength = 3;
            startIndex = 2;
        }

        scrollImage = new GameObject[vars.Length];
        for (int i = (int)startIndex; i < startIndex + arrayLength; i++)
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
        Debug.Log(values[0]);
        if (degree == 0)
        {
            GetComponent<Text>().text = "CHANGE DEGREE";
        }
        else if (degree == 1)
        {
            BasicCoef(0);

            ComplexCoef(1, true);

            GetComponent<Text>().text = "F(X) = " + values[0] + " X " + values[1];
        }
        else
        {
            BasicCoef(2);

            ComplexCoef(3, false);

            ComplexCoef(4, true);

            GetComponent<Text>().text = "F(X) = " + values[2] + "(X " + values[3] + ") " + values[4];
        }

        // LUKE SEND GetComponent<Text>().text to your post fix script from here
    }

    public void SetVar(string varName, float amount)
    {
        for (int l = 0; l < 5; l ++)
        {
            if (stringVars[l] == varName)
            {
                setVarIndex = l;
            }
        }
        Debug.Log(setVarIndex);
        vars[(int)setVarIndex] = (int)((amount * (maxRange - minRange)) + minRange);
        varSets[(int)setVarIndex] = true;
    }

    private void BasicCoef(int index)
    {
        if (varSets[index] == false)
        {
            values[index] = stringVars[index];
        }
        else
        {
            values[index] = "" + vars[index];
        }
    }

    private void ComplexCoef(int index, bool positive)
    {
        if (positive)
        {
            signIndex = 0;
        }
        else
        {
            signIndex = 1;
        }

        if (varSets[index] == false)
        {
            values[index] = signArray[signIndex] + stringVars[index];
        }
        else
        {
            if (Mathf.Sign(vars[index]) > 0)
            {
                values[index] = signArray[signIndex] + vars[index];
            }
            else
            {
                values[index] = signArray[signIndex + 1] + Mathf.Abs(vars[index]);
            }
        }
    }
}
