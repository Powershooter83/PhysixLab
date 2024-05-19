using System;
using TMPro;
using UltimateXR.Avatar;
using UltimateXR.Core;
using UltimateXR.Devices;
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

    [SerializeField] private GameObject sphere;
    [SerializeField] private TextMeshProUGUI information;
    [SerializeField] private LevelSystem _levelSystem;

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

        if (UxrAvatar.LocalAvatarInput.GetButtonsPressDown(UxrHandSide.Right, UxrInputButtons.Button1))
        {
            launchObject();
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

    public Transform launchpoint;

    public void launchObject()
    {
        if (_levelSystem.isBlocked())
        {
            return;
        }

        if (_levelSystem.getActiveLevel().levelType == LevelType.Abschusswinkel)
        {
            var xAngle = float.Parse(information.text.Replace(',', '.'));
            LaunchNewProjectile(
                _levelSystem.getActiveLevel().launchSpeed,
                xAngle);
        }

        if (_levelSystem.getActiveLevel().levelType == LevelType.Abschussgeschwindigkeit)
        {
            var launchSpeed = float.Parse(information.text.Replace(',', '.'));
            LaunchNewProjectile(
                launchSpeed,
                _levelSystem.getActiveLevel().launchAngle);
        }

        if (_levelSystem.getActiveLevel().levelType == LevelType.Abschusshoehe)
        {
            var portalHeight = float.Parse(information.text.Replace(',', '.'));
            _levelSystem.movePortal(portalHeight);

            LaunchNewProjectile(
                _levelSystem.getActiveLevel().launchSpeed,
                _levelSystem.getActiveLevel().launchAngle);
        }

        if (_levelSystem.getActiveLevel().levelType == LevelType.TargetVerschieben)
        {
            var targetLocation = float.Parse(information.text.Replace(',', '.'));
            _levelSystem.moveTarget(targetLocation);

            LaunchNewProjectile(
                _levelSystem.getActiveLevel().launchSpeed,
                _levelSystem.getActiveLevel().launchAngle);
        }
    }

    void LaunchNewProjectile(float launchVelocity, float launchAngle)
    {
        GameObject newSphere = Instantiate(sphere, launchpoint.position, Quaternion.identity);
        ProjectileMotion projectileMotion = newSphere.GetComponent<ProjectileMotion>();
        projectileMotion.Launch(launchAngle, launchVelocity);
    }
}