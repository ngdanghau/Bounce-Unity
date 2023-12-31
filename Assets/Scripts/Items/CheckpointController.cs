using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    BallController playerController;

    SpriteRenderer spriteRenderer;
    public Sprite uncatch, catched;
    Collider2D coll;

    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<BallController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spriteRenderer.sprite = catched;
        AudioManager.instance.PlaySFX(AudioManager.instance.pickupItem);

        playerController.AddScore(GameManager.instance.scoreCheckpoint);
        playerController.UpdateCheckpoint(transform.position);
        coll.enabled = false;
    }
}
