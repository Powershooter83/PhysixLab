using TMPro;
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
        if (_levelSystem.getActiveLevel().levelType == LevelType.Abschusswinkel)
        {
            
            var xAngle = float.Parse(information.text.Replace(',', '.'));
            var xAngleRad = xAngle * Mathf.Deg2Rad;
            var initialDirection = new Vector3(Mathf.Cos(xAngleRad), Mathf.Sin(xAngleRad), 0);
            var rotatedDirection = Quaternion.Euler(0, -90, 0) * initialDirection; 
            var _projectile = Instantiate(sphere, launchpoint.position, launchpoint.rotation);
            _projectile.GetComponent<Rigidbody>().velocity = rotatedDirection * _levelSystem.getActiveLevel().launchSpeed;
            
        }

        if (_levelSystem.getActiveLevel().levelType == LevelType.Abschussgeschwindigkeit)
        {
            var launchSpeed = float.Parse(information.text.Replace(',', '.'));
            var xAngleRad = _levelSystem.getActiveLevel().launchAngle * Mathf.Deg2Rad;
            var initialDirection = new Vector3(Mathf.Cos(xAngleRad), Mathf.Sin(xAngleRad), 0);
            var rotatedDirection = Quaternion.Euler(0, -90, 0) * initialDirection;
            var _projectile = Instantiate(sphere, launchpoint.position, launchpoint.rotation);
            _projectile.GetComponent<Rigidbody>().velocity = rotatedDirection * launchSpeed;
        }

        if (_levelSystem.getActiveLevel().levelType == LevelType.Abschusshoehe)
        {
            var portalHeight = float.Parse(information.text.Replace(',', '.'));
            _levelSystem.movePortal(portalHeight);

            var xAngleRad = _levelSystem.getActiveLevel().launchAngle * Mathf.Deg2Rad;
            var initialDirection = new Vector3(Mathf.Cos(xAngleRad), Mathf.Sin(xAngleRad), 0);
            var rotatedDirection = Quaternion.Euler(0, -90, 0) * initialDirection;
            var _projectile = Instantiate(sphere, launchpoint.position, launchpoint.rotation);
            _projectile.GetComponent<Rigidbody>().velocity =
                rotatedDirection * _levelSystem.getActiveLevel().launchSpeed;
        }

        if (_levelSystem.getActiveLevel().levelType == LevelType.TargetVerschieben)
        {
            var targetLocation = float.Parse(information.text.Replace(',', '.'));
            _levelSystem.moveTarget(targetLocation);

            var xAngleRad = _levelSystem.getActiveLevel().launchAngle * Mathf.Deg2Rad;
            var initialDirection = new Vector3(Mathf.Cos(xAngleRad), Mathf.Sin(xAngleRad), 0);
            var rotatedDirection = Quaternion.Euler(0, -90, 0) * initialDirection;
            var _projectile = Instantiate(sphere, launchpoint.position, launchpoint.rotation);
            _projectile.GetComponent<Rigidbody>().velocity =
                rotatedDirection * _levelSystem.getActiveLevel().launchSpeed;
        }
    }
}