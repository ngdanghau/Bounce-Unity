using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI lifeText;

    public int numLives = 3;
    public int numRings = 0;

    public int totalNumRings = 0;
    private int score = 0;

    public BallState ballState = BallState.Small;
    private BallState ballStateSaved;

    [SerializeField] private GameObject FailedPanel;

    public GameObject timerCanvas;
    public GameObject nextMenuCanvas;
    private Animator anim;

    Vector2 checkpointPos;
    AudioManager audioManager;

    private bool isCheat = false;
    public bool isInvincible = false;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        totalNumRings = GameObject.FindGameObjectsWithTag("Ring").Length;
        anim = GetComponent<Animator>();

        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<TextMeshProUGUI>();
        lifeText = GameObject.FindGameObjectWithTag("LifeText").GetComponent<TextMeshProUGUI>();

        ballStateSaved = ballState;
        anim.SetBool("IsBigBall", ballState == BallState.Big);
    }

    public void EnlargeBall()
    {
        ballState = BallState.Big;
        anim.SetBool("IsBigBall", true);
    }

    public void ShrinkBall()
    {
        ballState = BallState.Small;
        anim.SetBool("IsBigBall", false);
    }

    void Start()
    {
        checkpointPos = transform.position;
        Time.timeScale = 1;
    }

    void Update()
    {
        SetText();
    }
    public void UpdateCheckpoint(Vector2 pos)
    {
        checkpointPos = pos;
        ballStateSaved = ballState;
    }

    public void AddScore(int value)
    {
        score += value;
    }

    public void ChangeLife(int value)
    {
        if (numLives > 4) return;
        numLives += value;
    }

    void SetText()
    {
        lifeText.text = $"X{numLives}";
        scoreText.text = score.ToString("D7");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Thorn") && !isInvincible)
        {
            bool IsDie = anim.GetBool("IsDie");
            if (IsDie)
            {
                return;
            }
            StartCoroutine(Die());
        }

        Debug.Log("item: " + collision.gameObject.tag);
    }

    public void ChangeRing(int value)
    {
        numRings += value;
    }

    void StartGame()
    {
        anim.SetBool("IsDie", false);
        Time.timeScale = 1;
        transform.position = checkpointPos;
        ballState = ballStateSaved;
        anim.SetBool("IsBigBall", ballState == BallState.Big);
    }
    
    IEnumerator Die()
    {
        anim.SetBool("IsDie", true);
        gameObject.transform.rotation = Quaternion.identity;

        audioManager.PlaySFX(audioManager.characterPop);
        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(0.50f);
        if (numLives > 0)
        {
            numLives -= 1;
            StartGame();
        }
        else
        {
            FailedPanel.SetActive(true);
        }
    }
}
