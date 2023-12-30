using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    GameObject nextMenu;
    public int scoreEarn = 5000;

    BallController playerController;
    AudioManager audioManager;
    Animator animator;

    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<BallController>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        animator = GetComponent<Animator>();

        nextMenu = playerController.nextMenuCanvas;
    }

    private void Update()
    {
        OpenPortal();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (playerController.numRings != playerController.totalNumRings)
        {
            return;
        }

        audioManager.PlaySFX(audioManager.pickupItem);
        playerController.AddScore(scoreEarn);
        

        nextMenu.GetComponentInChildren<TextMeshProUGUI>().text = "test";
        nextMenu.SetActive(true);
        UnlockNewLevel();
    }

    void OpenPortal()
    {
        if (playerController.numRings != playerController.totalNumRings)
        {
            return;
        }

        bool PortalOpen = animator.GetBool("PortalOpen");

        if (PortalOpen)
        {
            return;
        }

        animator.SetBool("PortalOpen", true);
    }


    void UnlockNewLevel()
    {
        int buidIndex = SceneManager.GetActiveScene().buildIndex;
        if (buidIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", buidIndex);

            int unlockedLevel = PlayerPrefs.GetInt("unlockedLevel", 1);
            PlayerPrefs.SetInt("UnlockedLevel", unlockedLevel + 1);
            PlayerPrefs.Save();
        }
    }
}
