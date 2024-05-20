using System;
using UnityEngine;
using UnityEngine.Events;

public class InputBtn_CALC : MonoBehaviour
{
    public GameObject button;
    public UnityEvent whileHold;
    private GameObject presser;
    private AudioSource sound;
    private bool isPressed;

    [SerializeField] private CALC calculate;
    private SaveSystem _saveSystem;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;
        
        _saveSystem = GameObject.Find("SAVE_SYSTEM").GetComponent<SaveSystem>();
        sound.volume = _saveSystem.getSoundVolume();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (isPressed) return;
        button.transform.localPosition = new Vector3(0, 0.003f, 0);
        presser = other.gameObject;
        whileHold.Invoke();
        sound.Play();
        isPressed = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject != presser) return;
        button.transform.localPosition = new Vector3(0, 0.0099f, 0);
        isPressed = false;
    }
    
    public void SelectNumber(String input)
    {
        calculate.select(input);
    }

    public void delete()
    {
        calculate.delete();
    }

    public void calculateResult()
    {
        calculate.calculate();
    }

    public void removeLastChar()
    {
        calculate.removeLastChar();
    }
    
}