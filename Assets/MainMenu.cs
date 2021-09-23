using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Main()
    {
        SceneManager.LoadScene("Game");
    }

    public void Donasi()
    {
        Application.OpenURL("https://saweria.co/suryaelidanto");
    }
}
