using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackToMenu : MonoBehaviour
{
    public void backToMainMenu()
    {
        Debug.Log("YEAH");
        SceneManager.LoadScene("Menu");
    }
}