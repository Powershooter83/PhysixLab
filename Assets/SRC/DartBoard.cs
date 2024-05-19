using UnityEngine;

public class DartBoard : MonoBehaviour
{
    [SerializeField] private LevelSystem _levelSystem;

    public AudioSource source;
    
    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        _levelSystem.loadNextLevel();
        source.Play();
    }
}