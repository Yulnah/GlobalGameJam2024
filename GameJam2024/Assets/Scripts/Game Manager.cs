using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI J1_scoreText;
    private int J1_score;

    public TextMeshProUGUI J2_scoreText;
    private int J2_score;

    // Start is called before the first frame update
    void Start()
    {
        // SCORE MANAGER J1
        J1_score = 0;
        UpdateScore(J1_score, "J1");

        // SCORE MANAGER J2
        J2_score = 0;
        UpdateScore(J2_score, "J2");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScore(int scoreToAdd, string player)
    {
        if (player == "J1")
        {
            J1_score += scoreToAdd;
            J1_scoreText.text = "Score J1: " + J1_score;
        }
        else if (player == "J2")
        {
            J2_score += scoreToAdd;
            J2_scoreText.text = "Score J2: " + J2_score;
        }
    }
}
