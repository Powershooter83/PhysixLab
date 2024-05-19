using System;
using TMPro;
using UnityEngine;

public class Calculator : MonoBehaviour
{
    private String input = "";
    [SerializeField] private TextMeshProUGUI _textMeshPro;

    private LevelSystem _levelSystem;

    public void Start()
    {
        _levelSystem = gameObject.GetComponent<LevelSystem>();
    }


    public void SelectNumber(String input)
    {
        if (input.Equals(",") && this.input.Contains(',') || this.input.Length > 10)
        {
            return;
        }

        
        
        this.input += input;
        
        // switch (_levelSystem.getActiveLevel().levelType)
        // {
        //     case LevelType.Abschussgeschwindigkeit:
        //         this.input += "m/s\u00b2";
        //         break;
        //     case LevelType.Abschusshoehe:
        //         this.input += "m";
        //         break;
        //     case LevelType.Abschusswinkel:
        //         this.input += "\u00b0";
        //         break;
        //     case LevelType.TargetVerschieben:
        //         this.input += "m";
        //         break;
        // }
        _textMeshPro.text = this.input;
      
    }

    public void reset()
    {
        input = "";
        _textMeshPro.text = input;
    }
}