using UnityEngine;
using UnityEngine.UI;

public class SaveSystem : MonoBehaviour
{
    
    public void saveSoundEffectVolume(Slider slider)
    {
        PlayerPrefs.SetFloat("SoundEffectVolume", slider.value);
    }
    
    public void saveMusicVolume(Slider slider)
    {
        PlayerPrefs.SetFloat("MusicVolume", slider.value);
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
