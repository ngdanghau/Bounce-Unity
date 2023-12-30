using UnityEngine;

public class RingBigController : MonoBehaviour
{
    BallController playerController;
    AudioManager audioManager;

    SpriteRenderer[] spriteRenderers;
    public Sprite ringBigUncatchTop, ringBigCatchedTop, ringBigUncatchBottom, ringBigCatchedBottom;
    EdgeCollider2D[] colls;

    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<BallController>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        colls = GetComponents<EdgeCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (spriteRenderers.Length != 2)
        {
            return;
        }

        audioManager.PlaySFX(audioManager.pickupObstacle);

        spriteRenderers[0].sprite = ringBigCatchedTop;
        spriteRenderers[1].sprite = ringBigCatchedBottom;

        playerController.AddScore(500);
        playerController.ChangeRing(-1);
        if (colls.Length > 2)
        {
            colls[2].enabled = false;
        }

    }
}
