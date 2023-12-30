using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    Button[] buttons;
    [SerializeField] Sprite lselectLevelLocked;
    [SerializeField] Sprite lselectLevel;

    [SerializeField] GameObject levelButtons;

    void Awake()
    {
        ButtonsToArray();
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            Image image = buttons[i].GetComponent<Image>();
            image.sprite = lselectLevelLocked;
            image.raycastTarget = false;
        }

        for (int i = 0; i < unlockedLevel; i++)
        {
            Image image = buttons[i].GetComponent<Image>();
            image.sprite = lselectLevel;
            image.raycastTarget = true;
        }
    }

    public void OpenLevel(int levelId)
    {
        string levelName = "Level " + levelId;
        SceneManager.LoadScene(levelName);
    }

    void ButtonsToArray() {
        int childCount = levelButtons.transform.childCount;
        buttons = new Button[childCount];
        for (int i = 0; i < childCount; i++)
        {
            buttons[i] = levelButtons.transform.GetChild(i).gameObject.GetComponent<Button>();
        }
    }
}
