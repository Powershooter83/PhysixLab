using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMusicHandler : MonoBehaviour
{

    public SaveSystem _SaveSystem;
    public AudioSource audio;
    
    void Start()
    {

        audio.volume = _SaveSystem.getMusicVolume();
        audio.Play();

    }
    
}
