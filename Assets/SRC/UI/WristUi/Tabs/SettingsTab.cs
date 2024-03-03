using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsTab : MonoBehaviour
{
    public void quitGame()
    {
        Application.Quit();
    }

    public void openSettings()
    {
        //TODO: Load Scene
    }

    public void openMainMenu()
    {
        SceneManager.LoadScene("Hub");
    }
}