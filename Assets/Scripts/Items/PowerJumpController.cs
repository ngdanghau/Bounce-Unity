using UnityEngine;
using UnityEngine.UI;

public class PowerJumpController : MonoBehaviour
{
    private float remainingTime;

    PlayerMovement playerMovement;
    GameObject timerCanvas;
    Image timerImage;
    private void Start()
    {
        GameObject ballObject = GameObject.FindGameObjectWithTag("Player");
        playerMovement = ballObject.GetComponent<PlayerMovement>();

        timerCanvas = ballObject.GetComponent<BallController>().timerCanvas;
        timerImage = timerCanvas.GetComponent<Image>();
    }

    private void Update()
    {
        if (!playerMovement.isPowerJump) return;

        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else
        {
            remainingTime = 0;
            playerMovement.ChangePowerJump(false);
            timerCanvas.SetActive(false);
            return;
        }

        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerImage.fillAmount = seconds / GameManager.instance.timeForPowerUp;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // active and set default with for timer image
        timerCanvas.SetActive(true);
        timerImage.fillAmount = 1;

        // check collision, set default time
        remainingTime = GameManager.instance.timeForPowerUp;

        // change state for player
        playerMovement.ChangePowerJump(true);
    }
}
