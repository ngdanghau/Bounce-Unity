using UnityEngine;

public class LifeItemController : MonoBehaviour
{
    BallController playerController;
    AudioManager audioManager;
    public int scoreEarn = 1000;

    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<BallController>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioManager.PlaySFX(audioManager.pickupItem);
        playerController.AddScore(scoreEarn);
        playerController.ChangeLife(1);
        Destroy(gameObject);
    }
}
