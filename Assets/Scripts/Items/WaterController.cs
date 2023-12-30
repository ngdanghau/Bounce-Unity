using UnityEngine;

public class WaterController : MonoBehaviour
{
    BuoyancyEffector2D buoyancyEffector2D;

    private void Awake()
    {
        buoyancyEffector2D = GetComponent<BuoyancyEffector2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        buoyancyEffector2D.enabled = collision.gameObject.GetComponent<BallController>().ballState == BallState.Big;
    }
}
