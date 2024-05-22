using UnityEngine;
using UnityEngine.UI;

public class SaveSystem : MonoBehaviour
{
    private void Start()
    {
        if (!PlayerPrefs.GetString("hasLoaded").Equals("")) return;
        PlayerPrefs.SetString("hasLoaded", "true");
        PlayerPrefs.SetFloat("SoundEffectVolume", 1f);
        PlayerPrefs.SetFloat("MusicVolume", 1f);
        PlayerPrefs.Save();
    }

    public void saveSoundEffectVolume(Slider slider)
    {
        PlayerPrefs.SetFloat("SoundEffectVolume", slider.value);
        PlayerPrefs.Save();
    }
    
    public void saveMusicVolume(Slider slider)
    {
        PlayerPrefs.SetFloat("MusicVolume", slider.value);
        PlayerPrefs.Save();
    }


    public float getMusicVolume()
    {
        return PlayerPrefs.GetFloat("MusicVolume");
    }    
    
    public float getSoundVolume()
    {
        return PlayerPrefs.GetFloat("SoundEffectVolume");
    }
    
}
