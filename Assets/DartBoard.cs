using UnityEngine;

public class DartBoard : MonoBehaviour
{
    [SerializeField] private LevelSystem _levelSystem;
    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        _levelSystem.loadNextLevel();
    }
}