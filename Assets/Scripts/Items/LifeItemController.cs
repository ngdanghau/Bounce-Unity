using UnityEngine;

public class LifeItemController : MonoBehaviour
{
    BallController playerController;

    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<BallController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.pickupItem);
        playerController.AddScore(GameManager.instance.scoreLife);
        playerController.ChangeLife(1);
        Destroy(gameObject);
    }
}
