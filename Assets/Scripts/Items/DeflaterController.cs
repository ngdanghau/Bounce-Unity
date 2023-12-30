using UnityEngine;

public class DeflaterController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<BallController>().ShrinkBall();
    }
}
