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

    public AudioSource MissedAudio;
    public AudioSource HitAudio;
    public AudioSource WrongAudio;

    // VFX
    public GameObject vfxHit;
    public GameObject vfxSuccess;  

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {



        // PLAYER INPUT VERIFY
        //CheckButtonInput();

        // Play MissedAudio every time a button is pressed and there is no collision
        AudioFailSound();
        



        // PLAYER INPUT AND COLLIDER
        if (((Input.GetButtonDown("QTE_A_P" + PlayerNum)) ||
         (Input.GetButtonDown("QTE_B_P" + PlayerNum)) ||
         (Input.GetButtonDown("QTE_X_P" + PlayerNum)) ||
         (Input.GetButtonDown("QTE_Y_P" + PlayerNum))) &&
         (collidedObject != null))

        {
            CheckButtonInput();
            QTE_input = collidedObject.GetComponent<QTE>(); // Retrieve the letter from QTE.cs

            if (QTE_input != null)
            {
                string qteLetter = QTE_input.QTE_letter;
                Debug.Log("Retrieved QTE Letter: " + qteLetter);


                if (qteLetter == PlayerInput)
                {
                    HitAudio.Play();
                    VFXhitShowSuccess();
                    Invoke("VFXhitHideSuccess", 0.2f);
                    Destroy(collidedObject); // Destroy the object with the QTE_Game tag*



                    gameManager.UpdateScore(5, "J" + PlayerNum); // Gain score

                    Debug.Log("The right input has been made: deleting QTE_Game object");
                    Debug.Log("------------------------------------------------");

                    // Reset the flag when a correct input is made
                }
                else
                {
                    Debug.Log("Wrong input");
                    Debug.Log("------------------------------------------------");
                    WrongAudio.Play();
                }

            }
            
        }

    }

    void VFXhitShow()
    {
        vfxHit.SetActive(true);
    }
    void VFXhitHide()
    {
        vfxHit.SetActive(false);
    }

    void VFXhitShowSuccess()
    {
        vfxSuccess.SetActive(true);
    }
    void VFXhitHideSuccess()
    {
        vfxSuccess.SetActive(false);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "QTE_Game") // tag note
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
            //Debug.Log("Player " + PlayerNum + " has pressed" + PlayerInput);
            //Debug.Log("------------------------------------------------");
        }
        else if (Input.GetButtonDown("QTE_B_P" + PlayerNum))
        {
            PlayerInput = "B";
            //Debug.Log("Player " + PlayerNum + " has pressed" + PlayerInput);
            //Debug.Log("------------------------------------------------");
        }
        else if (Input.GetButtonDown("QTE_X_P" + PlayerNum))
        {
            PlayerInput = "X";
            //Debug.Log("Player " + PlayerNum + " has pressed" + PlayerInput);
            //Debug.Log("------------------------------------------------");
        }
        else if (Input.GetButtonDown("QTE_Y_P" + PlayerNum))
        {
            PlayerInput = "Y";
            //Debug.Log("Player " + PlayerNum + " has pressed" + PlayerInput);
            //Debug.Log("------------------------------------------------");
        }
    }

    void AudioFailSound()
    {
        // Check individual button presses and play sound
        if ((Input.GetButtonDown("QTE_A_P" + PlayerNum)) ||
            (Input.GetButtonDown("QTE_B_P" + PlayerNum)) ||
            (Input.GetButtonDown("QTE_X_P" + PlayerNum)) ||
            (Input.GetButtonDown("QTE_Y_P" + PlayerNum)))
        {
            MissedAudio.Play();
            VFXhitShow();
            Invoke("VFXhitHide", 0.2f);
        }
    }

}

