using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject credits_text;

    [SerializeField] private GameObject playBtn;
    [SerializeField] private GameObject creditsBtn;
    [SerializeField] private GameObject settingsBtn;
    [SerializeField] private GameObject exitBtn;

    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject levelsBtn;
    [SerializeField] private Slider _slider;
    [SerializeField] private Slider _slider2;
    [SerializeField] private SaveSystem _saveSystem;

    public void quit()
    {
        Application.Quit();
    }

    public void openMapSelection()
    {
        SceneManager.LoadScene("playground");
    }

    public void openSettings()
    {
        playBtn.SetActive(false);
        creditsBtn.SetActive(false);
        settingsBtn.SetActive(false);
        settings.SetActive(true);
        levelsBtn.SetActive(false);
        exitBtn.SetActive(false);

        _slider.value = _saveSystem.getMusicVolume();
        _slider2.value = _saveSystem.getSoundVolume();
    }

    public void openLevel()
    {
        SceneManager.LoadScene("Level");
    }

    public void closeSettings()
    {
        playBtn.SetActive(true);
        creditsBtn.SetActive(true);
        settingsBtn.SetActive(true);
        settings.SetActive(false);
        levelsBtn.SetActive(true);
        exitBtn.SetActive(true);
    }
    
    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(70); 
   
        playBtn.SetActive(true);
        creditsBtn.SetActive(true);
        settingsBtn.SetActive(true);
        levelsBtn.SetActive(true);
        exitBtn.SetActive(true);
        
        credits_text.SetActive(false);
    }
    
    public void playCredits()
    {
        playBtn.SetActive(false);
        creditsBtn.SetActive(false);
        settingsBtn.SetActive(false);
        levelsBtn.SetActive(false);
        exitBtn.SetActive(false);

        credits_text.SetActive(true);
        StartCoroutine(MyCoroutine());
    }
}