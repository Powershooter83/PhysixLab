using System;
using System.Text.RegularExpressions;
using NCalc;
using TMPro;
using UnityEngine;

public class CALC : MonoBehaviour
{
    private String input = "";

    public TextMeshProUGUI ui;
    
    public void select(String i)
    {
        input += i;
        ui.text = input;
    }

    public void removeLastChar()
    {
        if (input.Length <= 0) return;
        input = input.Substring(0, input.Length - 1);
        ui.text = input;
    }


    public void delete()
    {
        input = "";
        ui.text = input;
    }

    public void calculate()
    {
        string pattern = @"(\(.+?\)|\d+)\s*\^\s*(\d+)";
        string replacement = "Pow($1, $2)";
        
        
        Expression e = new Expression(Regex.Replace(input, pattern, replacement));
        ui.text = e.Evaluate().ToString();
    }
}