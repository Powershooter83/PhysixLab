using UnityEngine;

public class DartBoard : MonoBehaviour
{
    [SerializeField] private LevelSystem _levelSystem;

    public AudioSource source;

    private SaveSystem _saveSystem;
    
    public void Start()
    {
        _saveSystem = GameObject.Find("SAVE_SYSTEM").GetComponent<SaveSystem>();
        source.volume = _saveSystem.getSoundVolume();
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        _levelSystem.loadNextLevel();
        source.Play();
    }
}