using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scorekeeper : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreboardText;
    private float score;
    private int penalty = 40;
    public static Scorekeeper Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(this);
    }

    public void AddToScore(float inputFromPlayer)
    {
        // Calculate the score increase using an exponential function
        float scoreIncrease = Mathf.Pow(inputFromPlayer, 3) * 0.35f; // Adjust the function as needed

        // Add the score increase to the current score
        score += scoreIncrease;

        // Call the DisplayScore method to update the UI
        DisplayScore();
    }

    public void SubtractFromScore()
    {
        // Subtract the penalty from the score, ensuring it doesn't go below zero
        score = Mathf.Max(0, score - penalty);

        // Call the DisplayScore method to update the UI
        DisplayScore();
    }

    public void DisplayScore()
    {
        // Round the score to the nearest integer
        int roundedScore = Mathf.RoundToInt(score);

        // Update the TextMeshProUGUI text with the current score
        scoreboardText.text = "Score: " + roundedScore.ToString();
    }
}
