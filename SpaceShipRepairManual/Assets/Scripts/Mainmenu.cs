using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Project");
    }
    public void Options()
    {
        SceneManager.LoadScene("BrokenOptions");
    }
    // Update is called once per frame
    public void QuitGame()
    {
        Application.Quit();
    }
}
