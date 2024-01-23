using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE_Player : MonoBehaviour
{
    private GameObject collidedObject; // Store the collided object
    private string PlayerInput; // Get the player's button ABXY

    public int PlayerNum; // Get the player 1 or 2

    QTE QTE_input;
    public GameManager gameManager; // Get score points


    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();


    }

    // Update is called once per frame
    void Update()
    {



        // PLAYER INPUT VERIFY
        CheckButtonInput();
        //if (Input.GetButtonDown("QTE_" + PlayerInput + "_P" + PlayerNum)) 
        //{
        //   Debug.Log("Player "+ PlayerNum + " has pressed " + PlayerInput);
        //   Debug.Log("------------------------------------------------");
        //}




        // PLAYER INPUT AND COLLIDER
        //if ((Input.GetButtonDown("QTE_" + PlayerInput + "_P" + PlayerNum) && collidedObject != null))
        if ((Input.GetButtonDown("QTE_A_P" + PlayerNum) ||
        Input.GetButtonDown("QTE_B_P" + PlayerNum)) &&
        collidedObject != null)

        {
            CheckButtonInput();
            QTE_input = collidedObject.GetComponent<QTE>(); // Retrieve the letter from QTE.cs

            if (QTE_input != null)
            {
                string qteLetter = QTE_input.QTE_letter;
                Debug.Log("Retrieved QTE Letter: " + qteLetter);


                if (qteLetter == PlayerInput)
                {
                    Destroy(collidedObject); // Destroy the object with the QTE_Game tag
                    gameManager.UpdateScore(5, "J" + PlayerNum); // Gain score

                    Debug.Log("The right input has been made: deleting QTE_Game object");
                    Debug.Log("------------------------------------------------");
                }
                else
                {
                    Debug.Log("Wrong input");
                    Debug.Log("------------------------------------------------");
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "QTE_Game")
        {
            //Debug.Log("OnCollisionEnter2D");
            collidedObject = collision.gameObject; // Store the collided object
        }
    }

    void CheckButtonInput()
    {
        // Check individual button presses and update PlayerInput accordingly
        if (Input.GetButtonDown("QTE_A_P" + PlayerNum))
        {
            PlayerInput = "A";
            Debug.Log("Player " + PlayerNum + " has pressed" + PlayerInput);
            Debug.Log("------------------------------------------------");
        }
        else if (Input.GetButtonDown("QTE_B_P" + PlayerNum))
        {
            PlayerInput = "B";
            Debug.Log("Player " + PlayerNum + " has pressed" + PlayerInput);
            Debug.Log("------------------------------------------------");
        }
    }
}

