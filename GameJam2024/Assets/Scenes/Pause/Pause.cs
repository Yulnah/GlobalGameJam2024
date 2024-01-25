using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Pause"))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                pauseGame();
            }
        }
    }

    public void pauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        
        SceneManager.LoadScene("Menu_Principale");

    }

    public void Restart()
    {
        
        SceneManager.LoadScene("Prototype_QTE_v0");

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
