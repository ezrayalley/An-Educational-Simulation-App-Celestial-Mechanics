using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadEclipseScene()
    {
        SceneManager.LoadScene("EclipseScene");
    }

    public void LoadDayNightScene()
    {
        SceneManager.LoadScene("DayNightScene");
    }

    // You can add more if needed:
    // public void LoadMainMenuScene()
    // {
    //     SceneManager.LoadScene("MainMenu");
    // }
}
