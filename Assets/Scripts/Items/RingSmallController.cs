using UnityEngine;

public class RingSmallController : MonoBehaviour
{
    BallController playerController;

    SpriteRenderer[] spriteRenderers;
    public Sprite ringSmallUncatchTop, ringSmallCatchedTop, ringSmallUncatchBottom, ringSmallCatchedBottom;
    EdgeCollider2D[] colls;

    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<BallController>();
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        colls = GetComponents<EdgeCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (spriteRenderers.Length != 2)
        {
            return;
        }

        AudioManager.instance.PlaySFX(AudioManager.instance.pickupObstacle);

        spriteRenderers[0].sprite = ringSmallCatchedTop;
        spriteRenderers[1].sprite = ringSmallCatchedBottom;

        playerController.AddScore(GameManager.instance.scoreRing);
        playerController.ChangeRing(-1);
        if (colls.Length > 2)
        {
            colls[2].enabled = false;
        }

    }
}
