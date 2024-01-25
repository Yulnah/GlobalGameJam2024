using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // PANNEL FUNCTION
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game!");
    }

    public void StarGame()
    {
        SceneManager.LoadScene("Prototype_QTE_v0");
    }    
    
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu_Principale");
    }

}
