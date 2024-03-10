using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TMP_Text scoreText;

    void Start()
    {
        
        int score = VegetableCollision.score;

       
        scoreText.text = "Score: " + score.ToString();
    }
}