using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFailedController : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene("Level Menu");
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
