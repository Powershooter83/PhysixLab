using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackToMenu : MonoBehaviour
{
    public void backToMainMenu()
    {
        SceneManager.LoadScene("Menu");

    }
}