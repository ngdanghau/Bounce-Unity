using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] Sprite spriteSoundOn;
    [SerializeField] Sprite spriteSoundOff;
    Button buttonSound;
    private void Awake()
    {
        GameObject gameObjectSound = GameObject.Find("Sound");
        if(gameObjectSound != null)
        {
            buttonSound = gameObjectSound.GetComponent<Button>();
            if (AudioManager.instance.GetSFXVolume())
            {
                buttonSound.image.sprite = spriteSoundOn;
            }
            else
            {
                buttonSound.image.sprite = spriteSoundOff;
            }

        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        TextMeshProUGUI textTMP = pauseMenu.GetComponentInChildren<TextMeshProUGUI>();
        if (textTMP != null)
        {
            textTMP.text = SceneManager.GetActiveScene().name;
        }

        Time.timeScale = 0;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Level Menu");
        Time.timeScale = 1;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Sound()
    {
        if (buttonSound == null) return;
        if (buttonSound.image.sprite == spriteSoundOn)
        {
            buttonSound.image.sprite = spriteSoundOff;
            AudioManager.instance.SetSFXVolume(false);
        }
        else
        {
            buttonSound.image.sprite = spriteSoundOn;
            AudioManager.instance.SetSFXVolume(true);
        }
    }
}
