using UnityEngine;

public class RingSmallController : MonoBehaviour
{
    BallController playerController;
    AudioManager audioManager;

    SpriteRenderer[] spriteRenderers;
    public Sprite ringSmallUncatchTop, ringSmallCatchedTop, ringSmallUncatchBottom, ringSmallCatchedBottom;
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

        spriteRenderers[0].sprite = ringSmallCatchedTop;
        spriteRenderers[1].sprite = ringSmallCatchedBottom;

        playerController.AddScore(500);
        playerController.ChangeRing(-1);
        if (colls.Length > 2)
        {
            colls[2].enabled = false;
        }

    }
}
