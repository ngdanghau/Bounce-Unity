using UnityEngine;

public class GameManager: MonoBehaviour
{
    public Sprite gbarRing;
    public Vector2 size = new(16.56201f, 40.48602f);
    public Vector2 position = new(8.281006f, -19.74298f);

    public readonly int scoreRing = 500;
    public readonly int scoreLife = 1000;
    public readonly int scorePortal = 5000;
    public readonly int scoreCheckpoint = 200;

    public float defaultSpeed = 7f;
    public float jumpingPower = 16.5f;
    public float jumpingPowerBig = 17f;
    public float defaultJumpOffset = 0.5f;

    public float timeForPowerUp = 12f; // 11s

    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
