using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetScore();
    }

    public void SetScore()
    {
        score += 10;
        scoreText.text = "Score: " + score.ToString();
    }
}
