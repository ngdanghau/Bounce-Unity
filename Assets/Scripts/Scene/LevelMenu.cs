using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    GameObject[] buttons;
    [SerializeField] Sprite lselectLevelLocked;
    [SerializeField] Sprite lselectLevel;

    [SerializeField] GameObject levelButtons;

    void Awake()
    {
        ButtonsToArray();
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            Button button = buttons[i].GetComponent<Button>();
            Image image = button.GetComponent<Image>();
            image.sprite = lselectLevelLocked;
            image.raycastTarget = false;

            buttons[i].transform.GetChild(0).gameObject.SetActive(false);
        }

        for (int i = 0; i < unlockedLevel; i++)
        {
            Button button = buttons[i].GetComponent<Button>();
            Image image = button.GetComponent<Image>();
            image.sprite = lselectLevel;
            image.raycastTarget = true;

            buttons[i].transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void OpenLevel(int levelId)
    {
        string levelName = "Level " + levelId;
        SceneManager.LoadScene(levelName);
    }

    void ButtonsToArray() {
        int childCount = levelButtons.transform.childCount;
        buttons = new GameObject[childCount];
        for (int i = 0; i < childCount; i++)
        {
            buttons[i] = levelButtons.transform.GetChild(i).gameObject;
        }
    }
}
