using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Menu : MonoBehaviour
{ 

    [SerializeField] AudioSource HitSound;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Jouer()
    {
        SceneManager.LoadScene("Prototype_QTE_v0");
    }

    //Button Menu Quitter
    public void Quitter()
    {
        Application.Quit();

    }


}
