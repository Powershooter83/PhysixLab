using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManipulationTab : MonoBehaviour
{
    public static bool _showTracing = true;
    public static float releaseMultiplier = 10f;

    [SerializeField] private Slider _slider;
    [SerializeField] private Slider _gravitySlider;
    [SerializeField] private Toggle positiveGravity;
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private TextMeshProUGUI _textMeshPro2;
    [SerializeField] private TextMeshProUGUI _textMeshPro3;

    [SerializeField] private TextMeshProUGUI _textMeshPro4;
    [SerializeField] private TextMeshProUGUI _textMeshPro5;

    [SerializeField] private TextMeshProUGUI _textMeshPro6;
    [SerializeField] private TextMeshProUGUI _textMeshPro7;

    public void updateShowTracing()
    {
        _showTracing = !_showTracing;
        _textMeshPro4.SetText(_showTracing ? "aktiviert" : "deaktiviert");
        _textMeshPro5.SetText(_showTracing ? "aktiviert" : "deaktiviert");
    }


    public void Start()
    {
        positiveGravity.isOn = false;
        Physics.gravity = new Vector3(0, -9.81f, 0);
        _textMeshPro.SetText(Physics.gravity.y + "m/s2");
        _textMeshPro3.SetText(Physics.gravity.y + "m/s2");
        _slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        _gravitySlider.onValueChanged.AddListener(delegate { ChangeGravity(); });
    }

    public void setToEarth()
    {
        positiveGravity.isOn = false;
        Physics.gravity = new Vector3(0, -9.81f, 0);
        _textMeshPro.SetText(Physics.gravity.y + "m/s2");
        _textMeshPro3.SetText(Physics.gravity.y + "m/s2");
        _textMeshPro2.SetText(positiveGravity.isOn ? "15m/s2" : "-15m/s2");

        _gravitySlider.value = 9.81f;
    }


    public void setToMoon()
    {
        positiveGravity.isOn = false;
        Physics.gravity = new Vector3(0, -1.62f, 0);
        _textMeshPro.SetText(Physics.gravity.y + "m/s2");
        _textMeshPro3.SetText(Physics.gravity.y + "m/s2");
        _textMeshPro2.SetText(positiveGravity.isOn ? "15m/s2" : "-15m/s2");
        _gravitySlider.value = 1.62f;
    }


    public void setToSaturn()
    {
        positiveGravity.isOn = false;
        Physics.gravity = new Vector3(0, -10.44f, 0);
        _textMeshPro.SetText(Physics.gravity.y + "m/s2");
        _textMeshPro3.SetText(Physics.gravity.y + "m/s2");
        _textMeshPro2.SetText(positiveGravity.isOn ? "15m/s2" : "-15m/s2");
        _gravitySlider.value = 10.44f;
    }


    private void ChangeGravity()
    {
        var roundedGravity = positiveGravity.isOn ? _gravitySlider.value : -_gravitySlider.value;
        roundedGravity = (float)Math.Round(roundedGravity, 2);
        Physics.gravity = new Vector3(0, roundedGravity, 0);
        _textMeshPro.SetText(Physics.gravity.y + "m/s2");
        _textMeshPro3.SetText(Physics.gravity.y + "m/s2");
    }

    public void changePositiveGravity()
    {
        Physics.gravity = new Vector3(0, -Physics.gravity.y, 0);
        _textMeshPro.SetText(Physics.gravity.y + "m/s2");
        _textMeshPro3.SetText(Physics.gravity.y + "m/s2");
        _textMeshPro2.SetText(positiveGravity.isOn ? "15m/s2" : "-15m/s2");
    }


    private void ValueChangeCheck()
    {
        releaseMultiplier = (float)Math.Round(_slider.value, 2);
        _textMeshPro6.SetText(releaseMultiplier + "m/s2");
        _textMeshPro7.SetText(releaseMultiplier + "m/s2");
    }
}