using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverArea : MonoBehaviour
{
    public TextMeshProUGUI countdownText;

    private bool vegetableInside;
    private float timeInside;
    private float countdownDuration = 3f;
    private bool countingDown = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (IsVegetable(other.gameObject))
        {
            vegetableInside = true;
            StartCountdown();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (IsVegetable(other.gameObject))
        {
            vegetableInside = false;
            ResetCountdown();
        }
    }

    void Update()
    {
        if (countingDown)
        {
            timeInside += Time.deltaTime;
            UpdateCountdownDisplay(countdownDuration - timeInside);

            if (timeInside >= countdownDuration)
            {
                EndCountdown();
                TeleportToGameOverScene();
            }
        }
    }

    void StartCountdown()
    {
        countingDown = true;
        timeInside = 0f;
        countdownText.gameObject.SetActive(true);
    }

    void ResetCountdown()
    {
        countingDown = false;
        countdownText.gameObject.SetActive(false);
        countdownText.text = "";
    }

    void UpdateCountdownDisplay(float remainingTime)
    {
        int displayTime = Mathf.CeilToInt(remainingTime);
        countdownText.text = displayTime.ToString();
    }

    void EndCountdown()
    {
        countingDown = false;
        countdownText.gameObject.SetActive(false);
    }

    void TeleportToGameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }

    bool IsVegetable(GameObject obj)
    {
        return obj.CompareTag("turnip") || obj.CompareTag("white") || obj.CompareTag("kalafjor") || obj.CompareTag("garlic") || obj.CompareTag("potato") || obj.CompareTag("shroom") || obj.CompareTag("paprika") || obj.CompareTag("avocado") || obj.CompareTag("pumpkin") || obj.CompareTag("tomato");
    }
}