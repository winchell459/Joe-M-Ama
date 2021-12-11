using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("Chess");
    }
    public void SettingsButton()
    {
        SceneManager.LoadScene("Settings");
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene("Credits");
    }

    public void StartGomokuButton()
    {
        SceneManager.LoadScene("Gomoku");
    }
}
