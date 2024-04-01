using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void quit()
    {
        Application.Quit();
    }

    public void openMapSelection()
    {
        SceneManager.LoadScene("playground");
    }
}