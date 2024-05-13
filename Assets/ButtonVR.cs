using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UltimateXR.Manipulation.Helpers;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{
    public GameObject button;
    public UnityEvent whileHold;
    public UnityEvent launch;
    private GameObject presser;
    private AudioSource sound;
    private bool isPressed;



    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private GameObject sphere;
    [SerializeField] private GameObject rotateObj;
    [SerializeField] private GameObject rotateObjCompressor;
    [SerializeField] private GameObject launchDirection;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;
    }


    private void Update()
    {
        if (isPressed)
        {
            whileHold.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isPressed) return;
        button.transform.localPosition = new Vector3(0, 0.003f, 0);
        presser = other.gameObject;
        whileHold.Invoke();
        launch.Invoke();
        sound.Play();
        isPressed = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject != presser) return;
        button.transform.localPosition = new Vector3(0, 0.015f, 0);
        isPressed = false;
    }

    public void rotateRight()
    {
        rotateObj.transform.Rotate(Vector3.up * (20f * Time.deltaTime));
    }

    public void rotateLeft()
    {
        rotateObj.transform.Rotate(Vector3.up * (-20f * Time.deltaTime));
    }

    public void rotateUp()
    {
        rotateObjCompressor.transform.Rotate(Vector3.right * (-20f * Time.deltaTime));
        float currentAngle = rotateObjCompressor.transform.rotation.eulerAngles.x;
        _textMeshPro.text = currentAngle.ToString("F1") + "\u00b0\nAbschusswinkel";
    }

    public void rotateDown()
    {
        rotateObjCompressor.transform.Rotate(Vector3.right * (+20f * Time.deltaTime));
        float currentAngle = rotateObjCompressor.transform.rotation.eulerAngles.x;
        _textMeshPro.text = currentAngle.ToString("F1") + "\u00b0\nAbschusswinkel";
    }

    public Transform launchpoint;
    
    public void launchObject()
    {
        var _projectile = Instantiate(sphere, launchpoint.position, launchpoint.rotation);
        _projectile.GetComponent<Rigidbody>().velocity = launchpoint.forward * 5f;



        // var sphereInstance = Instantiate(sphere, this.launchDirection.transform.position, Quaternion.identity);
        // var sphereRigidbody = sphereInstance.GetComponent<Rigidbody>();
        // if (sphereRigidbody == null) return;
        //
        // var launchDirection = this.launchDirection.transform.forward;
        //
        // // Berechnung der Rotation zwischen der Up-Richtung und der Launch-Richtung
        // var launchRotation = Quaternion.FromToRotation(Vector3.up, launchDirection);
        //
        // // Extrahieren des Winkels aus der berechneten Rotation
        // var launchAngle = launchRotation.eulerAngles.x;
        //
        // // Konvertieren des Winkels in den Bereich von -90 bis 90 Grad
        // if (launchAngle > 180) launchAngle -= 360;
        //
        // // Konvertieren des Winkels von Grad in Bogenmaß
        // var launchAngleRad = launchAngle * Mathf.Deg2Rad;
        //
        // var launchSpeed = 4;
        // var launchSpeedX = launchSpeed * Mathf.Sin(launchAngleRad);
        // var launchSpeedY = launchSpeed * Mathf.Cos(launchAngleRad);
        //
        // var launchForce = launchDirection * launchSpeedX;
        // launchForce.y = launchSpeedY;
        //
        // sphereRigidbody.AddForce(launchForce, ForceMode.VelocityChange);
    }



}