using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerFunction : MonoBehaviour
{
    public GameObject input;
    private string function;
    private string prev;
    public FunctionControl fx;
    // Start is called before the first frame update
    void Start()
    {
        function = "";
        prev = "";
    }

    // Update is called once per frame
    void Update()
    {
        function = input.GetComponent<GUIToText>().GUIString1;
        if (!prev.Equals(function)) {
            fx.function = function;
            fx.Reset();
        }
        prev = function;
    }
}
