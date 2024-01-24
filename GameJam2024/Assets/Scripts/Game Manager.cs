using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class GameManager : MonoBehaviour
{
    // GAME

    public bool isGameOver = false;
    public GameObject gameOverCanvas;
    public NoteSpawner gameSpawner;

    public NoteSpawner spawnerJ1;
    public NoteSpawner spawnerJ2;

    public GameObject LossPanel1;
    public GameObject LossPanel2;

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

    //SliderHealthBar healthbar;
    public Slider sliderJ1;
    public Slider sliderJ2;
    public static int sliderBarJ1;
    public static int sliderBarJ2;

    public QTE_Player playerJ1;
    public QTE_Player playerJ2;

    // Start is called before the first frame update
    void Start()
    {

        // Disable the game over canvas at the beginning
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(false);
        }

        if (LossPanel1 != null)
        {
            LossPanel1 .SetActive(false);
        }
        if (LossPanel2 != null)
        {
            LossPanel2.SetActive(false);
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

        sliderBarJ1 = 3;
        sliderBarJ2 = 3;

        sliderJ1.maxValue = 3;
        sliderJ1.value = 3;
        sliderJ2.maxValue = 3;
        sliderJ2.value = 3;

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
        if (healthJ1 > 0)
        {
            switch (sliderBarJ1)
            {
                case 3:
                    sliderJ1.value = 3;
                    break;
                case 2:
                    sliderJ1.value = 2;
                    break;
                case 1:
                    sliderJ1.value = 1;
                    break;
                case 0:
                    sliderJ1.value = 0;
                    break;
            }
        }
        else
        {
            sliderJ1.value = 0;

        }

        if (healthJ2 > 0)
        {
            switch (sliderBarJ2)
            {
                case 3:
                    sliderJ2.value = 3;
                    break;
                case 2:
                    sliderJ2.value = 2;
                    break;
                case 1:
                    sliderJ2.value = 1;
                    break;
                case 0:
                    sliderJ2.value = 0;
                    break;
            }

        } else
        {
            sliderJ2.value = 0;

        }

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

       if (healthJ1 == 0)
        {
            playerJ1.enabled = false;
            spawnerJ1.StopSpawning();
            LossPanel1.SetActive(true);
        }

        if (healthJ2 == 0)
        {
            playerJ2.enabled = false;
            spawnerJ2.StopSpawning();
            LossPanel2.SetActive(true);
        }


        if (healthJ1 <= 0 && healthJ2 <= 0 && !isGameOver)
        {
            GameOver();
            StopSpawning(); // Stop the spawner when the game is over
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
