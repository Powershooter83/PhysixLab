using UnityEngine;

public class ProjectileMotion : MonoBehaviour
{
    public float gravity = -9.81f; // Schwerkraft
    private Vector3 initialVelocity;
    private Vector3 startPosition;
    private Vector3 currentVelocity;
    private Vector3 currentPosition;
    private float timeElapsed;
    private bool isLaunched = false;

    void Update()
    {
        if (isLaunched)
        {
            timeElapsed += Time.deltaTime;
            
            // Berechne die neue Position
            currentPosition.x = startPosition.x + initialVelocity.x * timeElapsed;
            currentPosition.y = startPosition.y + initialVelocity.y * timeElapsed + 0.5f * gravity * timeElapsed * timeElapsed;
            currentPosition.z = startPosition.z + initialVelocity.z * timeElapsed;

            // Aktualisiere die Position des Objekts
            transform.position = currentPosition;

            // Aktualisiere die Geschwindigkeit des Projektils
            currentVelocity.y = initialVelocity.y + gravity * timeElapsed;
        }
    }

    public void Launch(float launchAngle, float velocity)
    {
        startPosition = transform.position;
        timeElapsed = 0f;

        // Berechne die Anfangsgeschwindigkeit aus Winkel und Geschwindigkeit
        float radianAngle = launchAngle * Mathf.Deg2Rad;
        Vector3 velocityVector = new Vector3(
            velocity * Mathf.Cos(radianAngle),
            velocity * Mathf.Sin(radianAngle),
            0 // Für einen 2D-Wurf, wenn 3D benötigt wird, kann dies angepasst werden
        );

        initialVelocity = Quaternion.Euler(0, -90, 0) * velocityVector;
        
        currentVelocity = initialVelocity;
        currentPosition = startPosition;
        isLaunched = true;
    }
}