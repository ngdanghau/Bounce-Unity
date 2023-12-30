using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    BallController playerController;
    AudioManager audioManager;

    SpriteRenderer spriteRenderer;
    public Sprite uncatch, catched;
    public int scoreEarn = 200;
    Collider2D coll;

    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<BallController>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spriteRenderer.sprite = catched;
        audioManager.PlaySFX(audioManager.pickupItem);

        playerController.AddScore(scoreEarn);
        playerController.UpdateCheckpoint(transform.position);
        coll.enabled = false;
    }
}
