using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject credits_text;

    [SerializeField] private GameObject playBtn;
    [SerializeField] private GameObject tutorialBtn;
    [SerializeField] private GameObject creditsBtn;
    [SerializeField] private GameObject settingsBtn;
    [SerializeField] private GameObject exitBtn;

    [SerializeField] private GameObject settings;

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
        tutorialBtn.SetActive(false);
        creditsBtn.SetActive(false);
        settingsBtn.SetActive(false);
        settings.SetActive(true);
    }

    public void closeSettings()
    {
        playBtn.SetActive(true);
        tutorialBtn.SetActive(true);
        creditsBtn.SetActive(true);
        settingsBtn.SetActive(true);
        settings.SetActive(false);
    }
    
    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(20);   //Wait one frame
   
        playBtn.SetActive(true);
        tutorialBtn.SetActive(true);
        creditsBtn.SetActive(true);
        settingsBtn.SetActive(true);
        exitBtn.SetActive(true);
        
        credits_text.SetActive(false);
    }
    
    public void playCredits()
    {
        playBtn.SetActive(false);
        tutorialBtn.SetActive(false);
        creditsBtn.SetActive(false);
        settingsBtn.SetActive(false);
        exitBtn.SetActive(false);

        credits_text.SetActive(true);
        StartCoroutine(MyCoroutine());
    }
}