using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class FunctionControl : MonoBehaviour
{

    public string function;
    public double sensitivity;

    // Use this for initialization
    void Start()
    {
        function = preProcess(function);
        function = postFix(function);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Reset()
    {
        function = preProcess(function);
        function = postFix(function);
    }
    public double output(double a)
    {
        string functionDupe = function.Replace("x", Convert.ToString(a));
        return eval(functionDupe);
    }
    private double eval(string input)
    {

        string[] array = input.Split(' ');
        Stack<double> eval = new Stack<double>();

        for (int i = 0; i < array.Length; i++)
        {
            string current = array[i];
            if ("+-*/^".Contains(current))
            {
                double t1;
                double t2;
                switch (current)
                {
                    case "+":
                        eval.Push(eval.Pop() + eval.Pop());
                        break;
                    case "-":
                        t1 = eval.Pop();
                        t2 = eval.Pop();
                        eval.Push(t2 - t1);
                        break;
                    case "*":
                        eval.Push(eval.Pop() * eval.Pop());
                        break;
                    case "/":
                        t1 = eval.Pop();
                        t2 = eval.Pop();
                        eval.Push(t2 / t1);
                        break;
                    case "^":
                        t1 = eval.Pop();
                        t2 = eval.Pop();
                        eval.Push(Mathf.Pow((float)(t2), (float)(t1 / sensitivity)));
                        break;
                }
            }
            else
            {
                eval.Push(Convert.ToDouble(current) * sensitivity);
            }
        }
        return eval.Pop();
    }
    private string postFix(string str)
    {
        string a = str; //copy of input
        a = '(' + str + ')'; //surround in parentheses for later
        char[] input = a.ToCharArray();
        string output = "";
        Stack<char> stack = new Stack<char>();
        for (int i = 0; i < input.Length; i++)
        {
            char current = input[i];
            if (current == '(')
            {
                stack.Push(current);
            }
            else if (current == ')')
            {
                char popped = ' ';
                while (popped != '(')
                {
                    if (popped == '+' || popped == '-' || popped == '*' || popped == '/' || popped == '^')
                    {
                        output = output + " " + popped;
                    }
                    popped = stack.Pop();
                }
            }
            else if (current == '+' || current == '-' || current == '*' || current == '/' || current == '^')
            {
                if (isHigher(stack.Peek(), current))
                {
                    output = output + " " + stack.Pop();
                }
                stack.Push(current);
                output = output + " ";
            }
            else
            {
                output = output + current;
            }
        }
        return output;
    }
    private bool isHigher(char a, char b)
    {
        int aint = 0;
        int bint = 0;

        switch (a)
        {
            case '+':
                aint = 1;
                break;
            case '-':
                aint = 1;
                break;
            case '*':
                aint = 2;
                break;
            case '/':
                aint = 2;
                break;
            case '^':
                aint = 3;
                break;
        }
        switch (b)
        {
            case '+':
                bint = 1;
                break;
            case '-':
                bint = 1;
                break;
            case '*':
                bint = 2;
                break;
            case '/':
                bint = 2;
                break;
            case '^':
                bint = 3;
                break;
        }
        return aint > bint;
    }
    string preProcess(string input)
    {
        char[] charify = input.ToCharArray();
        char prev = 'я';
        int i2 = 0;
        for (int i = 0; i < charify.Length; i++)
        {
            if (charify[i] == ' ')
            {
                input = input.Remove(i2, 1);
                i2 -= 1;
            }
            else if (charify[i] == 'x' && "0123456789".Contains(prev.ToString()))
            {
                input = input.Insert(i2, "*");
                i2++;
            }
            else if (charify[i] == '(' && !"я(+-*/^".Contains(prev.ToString()))
            {
                print(prev.ToString());
                input = input.Insert(i2, "*");
                i2++;
            }
            prev = input[i2];
            i2++;
        }
        return input;
    }
}