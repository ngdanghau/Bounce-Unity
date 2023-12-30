using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteController : MonoBehaviour
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

    public void Next()
    {
        SceneController.instance.NextLevel();
    }
}
