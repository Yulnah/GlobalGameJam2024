using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    // GAME
    public bool isGameOver = false;
    public GameObject gameOverCanvas;
    public NoteSpawner gameSpawner;

    // SCORE
    public TextMeshProUGUI J1_scoreText;
    private int J1_score;

    public TextMeshProUGUI J2_scoreText;
    private int J2_score;

    // HEALTH
    public GameObject heartJ1_0, heartJ1_1, heartJ1_2;
    public GameObject heartJ2_0, heartJ2_1, heartJ2_2;
    public static int healthJ1;
    public static int healthJ2;


    // Start is called before the first frame update
    void Start()
    {
        // Disable the game over canvas at the beginning
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(false);
        }


        // SCORE MANAGER J1
        J1_score = 0;
        UpdateScore(J1_score, "J1");

        // SCORE MANAGER J2
        J2_score = 0;
        UpdateScore(J2_score, "J2");

        // HEALTH MANAGER
        healthJ1 = 3;
        healthJ2 = 3;

        heartJ1_0.gameObject.SetActive(true);
        heartJ1_1.gameObject.SetActive(true);
        heartJ1_2.gameObject.SetActive(true);

        heartJ2_0.gameObject.SetActive(true);
        heartJ2_1.gameObject.SetActive(true);
        heartJ2_2.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        switch (healthJ1)
        {
            case 3:
                heartJ1_0.gameObject.SetActive(true);
                heartJ1_1.gameObject.SetActive(true);
                heartJ1_2.gameObject.SetActive(true);
                break;
            case 2:
                heartJ1_0.gameObject.SetActive(true);
                heartJ1_1.gameObject.SetActive(true);
                heartJ1_2.gameObject.SetActive(false);
                break;
            case 1:
                heartJ1_0.gameObject.SetActive(true);
                heartJ1_1.gameObject.SetActive(false);
                heartJ1_2.gameObject.SetActive(false);
                break;
            case 0:
                heartJ1_0.gameObject.SetActive(false);
                heartJ1_1.gameObject.SetActive(false);
                heartJ1_2.gameObject.SetActive(false);
                break;

        }

        switch (healthJ2)
        {
            case 3:
                heartJ2_0.gameObject.SetActive(true);
                heartJ2_1.gameObject.SetActive(true);
                heartJ2_2.gameObject.SetActive(true);
                break;
            case 2:
                heartJ2_0.gameObject.SetActive(true);
                heartJ2_1.gameObject.SetActive(true);
                heartJ2_2.gameObject.SetActive(false);
                break;
            case 1:
                heartJ2_0.gameObject.SetActive(true);
                heartJ2_1.gameObject.SetActive(false);
                heartJ2_2.gameObject.SetActive(false);
                break;
            case 0:
                heartJ2_0.gameObject.SetActive(false);
                heartJ2_1.gameObject.SetActive(false);
                heartJ2_2.gameObject.SetActive(false);
                break;

        }

        if (healthJ1 == 0 || healthJ2 == 0)
        {
            //GameOver();
            //StopSpawning(); // Stop the spawner when the game is over
        }

    }



    public void GameOver()
    {
        // Set the game over state
        isGameOver = true;

        // Display the game over canvas
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
        }
    }
    void StopSpawning()
    {
        if (gameSpawner != null)
        {
            gameSpawner.StopSpawning();
        }
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
