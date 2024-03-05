using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hub : MonoBehaviour
{
    public void onSandboxBtn()
    {
        SceneManager.LoadScene("basketballCourt");
    }
    
    public void onExitBtn()
    {
        Application.Quit();
    }
}
