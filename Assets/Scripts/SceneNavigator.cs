using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Celestial"); // Loads the main menu scene
    }
}
