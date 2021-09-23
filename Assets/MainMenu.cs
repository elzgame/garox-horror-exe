using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Main()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }

    public void Donasi()
    {
        Application.OpenURL("https://saweria.co/suryaelidanto");
    }
}
