using UnityEngine;

public class PumperController : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<BallController>().EnlargeBall();
    }
}
